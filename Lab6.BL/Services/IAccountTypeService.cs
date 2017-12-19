using System.Collections.Generic;
using System.Threading.Tasks;
using Lab6.Domain.Models;

namespace Lab6.BL.Services
{
    public interface IAccountTypeService
    {
        Task<IEnumerable<AccountTypeModel>> GetAccountTypesAsync();
    }
}