namespace UserManagementApi.Strategies.Discount
{
    public class PremiumAccountDiscount : IDiscountStrategy
    {
        public decimal CalcDiscount(Enum accountType)
        {
            return 20;
        }
    }
}
