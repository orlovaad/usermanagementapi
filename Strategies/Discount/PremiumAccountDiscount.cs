namespace UserManagementApi.Strategies.Discount
{
    public class PremiumAccountDiscount : IDiscountStrategy
    {
        public decimal CalcDiscount()
        {
            return 20;
        }
    }
}
