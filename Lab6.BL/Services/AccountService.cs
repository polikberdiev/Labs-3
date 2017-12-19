using System;
using System.Threading.Tasks;
using Lab6.BL.Helpers;
using Lab6.Domain.Exceptions;
using Lab6.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab6.BL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBonusCalculator _bonusCalculator;


        public AccountService(IUnitOfWork unitOfWork, IBonusCalculator bonusCalculator)
        {
            _unitOfWork = unitOfWork;
            _bonusCalculator = bonusCalculator;
        }


        public async Task<IPagedList<AccountModel>> GetAccountsAsync(int pageId)
        {
            var accountRepository = _unitOfWork.GetRepository<AccountModel>();
            var accounts = await accountRepository.GetPagedListAsync(
                include: q => q.Include(a => a.OwnerUser), 
                pageIndex: pageId,
                pageSize: Constants.PageSize);

            return accounts;
        }

        public async Task<AccountModel> GetAccountAsync(Guid accountId)
        {
            var accountRepository = _unitOfWork.GetRepository<AccountModel>();
            var account = await accountRepository.GetFirstOrDefaultAsync(
                predicate: a => a.Id == accountId,
                include: q => q.Include(a => a.OwnerUser).Include(a => a.AccountType));
            EntityNotFoundException.ThrowIfNull(account, accountId);

            return account;
        }

        public async Task<AccountModel> AddAccountAsync(AccountModel accountModel)
        {
            var accountRepository = _unitOfWork.GetRepository<AccountModel>();
            await accountRepository.InsertAsync(accountModel);

            await _unitOfWork.SaveChangesAsync();

            return accountModel;
        }

        public async Task RemoveAccountAsync(Guid accountId)
        {
            var accountRepository = _unitOfWork.GetRepository<AccountModel>();
            var removingEntity = await accountRepository.FindAsync(accountId);
            EntityNotFoundException.ThrowIfNull(removingEntity, accountId);

            accountRepository.Delete(removingEntity);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AddFundsAsync(Guid accountId, decimal balanceValue)
        {
            var accountRepository = _unitOfWork.GetRepository<AccountModel>();
            var account = await accountRepository.GetFirstOrDefaultAsync(
                predicate: a => a.Id == accountId,
                include: q => q.Include(a => a.AccountType));
            EntityNotFoundException.ThrowIfNull(account, accountId);

            var bonusValue = _bonusCalculator.Calculate(account, balanceValue);
            account.Balance += balanceValue;
            account.Bonus += bonusValue;

            accountRepository.Update(account);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}