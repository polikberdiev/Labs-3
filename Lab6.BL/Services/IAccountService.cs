using System;
using System.Threading.Tasks;
using Lab6.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab6.BL.Services
{
    public interface IAccountService
    {
        Task<IPagedList<AccountModel>> GetAccountsAsync(int pageId);

        Task<AccountModel> GetAccountAsync(Guid accountId);

        Task<AccountModel> AddAccountAsync(AccountModel accountModel);

        Task AddFundsAsync(Guid accountId, decimal balanceValue);

        Task RemoveAccountAsync(Guid accountId);
    }
}