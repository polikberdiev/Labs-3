using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab6.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab6.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;


        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            var usersRepository = _unitOfWork.GetRepository<UserModel>();
            var users = await usersRepository.GetPagedListAsync(pageSize: Int32.MaxValue);

            return users.Items;
        }
    }
}