using UserManagementApi.Models;
using UserManagementApi.Strategies.Discount;

namespace UserManagementApi.Factories
{
    public interface IDiscountStrategyFactory
    {
        public IDiscountStrategy DiscountStrategy(AccountType accountType);
    }
}
