using Lab6.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Models.ViewModels.Home
{
    public class AccountsViewModel
    {
        public IPagedList<AccountModel> AccountPage { get; }


        public AccountsViewModel(IPagedList<AccountModel> accountPage)
        {
            AccountPage = accountPage;
        }
    }
}