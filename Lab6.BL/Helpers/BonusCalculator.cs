using Lab6.Domain.Models;

namespace Lab6.BL.Helpers
{
    public class BonusCalculator : IBonusCalculator
    {
        public decimal Calculate(AccountModel account, decimal increasedValue)
        {
            return (decimal) account.AccountType.BonusPercent / 100 * increasedValue;
        }
    }
}