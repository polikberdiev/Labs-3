using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab6.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab6.BL.Services
{
    public class AccountTypeService : IAccountTypeService
    {
        private readonly IUnitOfWork _unitOfWork;


        public AccountTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<AccountTypeModel>> GetAccountTypesAsync()
        {
            var accountTypesRepository = _unitOfWork.GetRepository<AccountTypeModel>();
            var accountTypes = await accountTypesRepository.GetPagedListAsync(pageSize: Int32.MaxValue);

            return accountTypes.Items;
        }
    }
}