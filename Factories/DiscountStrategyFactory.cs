using UserManagementApi.Models;
using UserManagementApi.Strategies.Discount;

namespace UserManagementApi.Factories
{
    public class DiscountStrategyFactory
    {
        public IDiscountStrategy DiscountStrategy(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Free:     
                    return new FreeAccountDiscount();
                case AccountType.Standard: 
                    return new StandardAccountDiscount();
                case AccountType.Premium:  
                    return new PremiumAccountDiscount();
                default:
                    throw new ArgumentException("Invalid account type");
            }
        }
    }
}
