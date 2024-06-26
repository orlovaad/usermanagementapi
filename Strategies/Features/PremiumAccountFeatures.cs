namespace UserManagementApi.Strategies.Features
{
    public class PremiumAccountFeatures : IFeatureAccessStrategy
    {
        public string GetFeatures()
        {
            return "Ты лучший!";
        }

    }
}
