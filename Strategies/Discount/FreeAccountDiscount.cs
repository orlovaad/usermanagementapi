namespace UserManagementApi.Strategies.Discount
{
    public class FreeAccountDiscount : IDiscountStrategy
    {
        public decimal CalcDiscount(Enum accountType)
        {
            return 0;
        }
    }
}
