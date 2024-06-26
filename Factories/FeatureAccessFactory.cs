using UserManagementApi.Models;
using UserManagementApi.Strategies.Features;

namespace UserManagementApi.Factories
{
    public class FeatureAccessFactory
    {
        public IFeatureAccessStrategy FeatureAccessStrategy(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Free:
                    return new FreeAccountFeatures();
                case AccountType.Standard:
                    return new StandardAccountFeatures();
                case AccountType.Premium:
                    return new PremiumAccountFeatures();
                default:
                    throw new ArgumentException("Invalid account type");
            }
        }
    }
}
