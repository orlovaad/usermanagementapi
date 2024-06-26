using UserManagementApi.Data;
using UserManagementApi.Factories;
using UserManagementApi.Models;

namespace UserManagementApi.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _applicationContext;
        public UserService(ApplicationContext applicationContext) { 
            _applicationContext = applicationContext;
        }

        public bool CheckAge(DateTime dateOfBirth)
        {
            if (dateOfBirth == DateTime.MinValue)
                return false;
            var start = dateOfBirth;
            var end = DateTime.UtcNow;
            int years = end.Year - start.Year;
            if (end.Month < start.Month || (end.Month == start.Month && end.Day < start.Day))
            {
                years--;
            }
            return years >= 18;
        }

        public decimal GetDiscount(AccountType accountType)
        {
            var discountStrategyFactory = new DiscountStrategyFactory();
            var discountStrategy = discountStrategyFactory.DiscountStrategy(accountType);
            return discountStrategy.CalcDiscount();
        }

        public string GetFeatures(AccountType accountType)
        {
            var featureAccessFactory = new FeatureAccessFactory();
            var featureAccessStrategy = featureAccessFactory.FeatureAccessStrategy(accountType);
            return featureAccessStrategy.GetFeatures();
        }

    }
}
