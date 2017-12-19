using Lab6.Domain;
using Lab6.Domain.Models;

namespace Lab6.BL.Helpers
{
    public interface IBonusCalculator
    {
        decimal Calculate(AccountModel account, decimal increasedValue);
    }
}