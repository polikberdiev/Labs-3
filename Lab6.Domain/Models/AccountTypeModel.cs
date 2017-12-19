using Lab6.Domain.Base;

namespace Lab6.Domain.Models
{
    public class AccountTypeModel : StateEntityModelBase
    {
        public string Name { get; set; }

        public double BonusPercent { get; set; }
    }
}