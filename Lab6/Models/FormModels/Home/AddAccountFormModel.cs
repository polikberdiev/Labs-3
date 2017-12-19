using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Lab6.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab6.Models.FormModels.Home
{
    public class AddAccountFormModel
    {
        [Required]
        [Display(Name = "Owner user")]
        public Guid? OwnerUserId { get; set; }

        public SelectList OwnerUsersSelectList { get; }

        [Required]
        [Display(Name = "Account type")]
        public Guid? AccountTypeId { get; set; }

        public SelectList AccountTypesSelectList { get; }

        [Required(AllowEmptyStrings = false)]
        public string Number { get; set; }


        public AddAccountFormModel()
            : this(Enumerable.Empty<UserModel>(), Enumerable.Empty<AccountTypeModel>()) { }

        public AddAccountFormModel(IEnumerable<UserModel> users, IEnumerable<AccountTypeModel> accountTypes)
        {
            OwnerUsersSelectList = new SelectList(users, nameof(UserModel.Id), nameof(UserModel.Name));
            AccountTypesSelectList = new SelectList(accountTypes, nameof(AccountTypeModel.Id), nameof(AccountTypeModel.Name));
        }
    }
}