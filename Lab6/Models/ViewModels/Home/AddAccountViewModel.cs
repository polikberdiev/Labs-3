using System.Collections.Generic;
using Lab6.Domain.Models;
using Lab6.Models.FormModels.Home;

namespace Lab6.Models.ViewModels.Home
{
    public class AddAccountViewModel
    {
        public AddAccountFormModel AddAccountFormModel { get; }


        public AddAccountViewModel(IEnumerable<UserModel> users, IEnumerable<AccountTypeModel> accountTypes)
        {
            AddAccountFormModel = new AddAccountFormModel(users, accountTypes);
        }
    }
}