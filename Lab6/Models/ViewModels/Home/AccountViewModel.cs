using Lab6.Domain.Models;

namespace Lab6.Models.ViewModels.Home
{
    public class AccountViewModel
    {
        public AccountModel Account { get; }


        public AccountViewModel(AccountModel account)
        {
            Account = account;
        }
    }
}