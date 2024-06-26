using UserManagementApi.Models;
using UserManagementApi.Strategies.Features;

namespace UserManagementApi.Factories
{
    public interface IFeatureAccessFactory
    {
        public IFeatureAccessStrategy FeatureAccessStrategy(AccountType accountType);
    }
}
