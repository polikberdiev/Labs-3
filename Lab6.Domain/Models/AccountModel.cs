using System;
using Lab6.Domain.Base;

namespace Lab6.Domain.Models
{
    public class AccountModel : StateEntityModelBase
    {
        public Guid OwnerUserId { get; set; }

        public virtual UserModel OwnerUser { get; set; }

        public string Number { get; set; }

        public decimal Balance { get; set; }

        public Guid AccountTypeId { get; set; }

        public virtual AccountTypeModel AccountType { get; set; }

        public decimal Bonus { get; set; }
    }
}