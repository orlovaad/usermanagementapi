namespace UserManagementApi.Strategies.Discount
{
    public class StandardAccountDiscount : IDiscountStrategy
    {
        public decimal CalcDiscount(Enum accountType)
        {
            return 10;
        }
    }
}
