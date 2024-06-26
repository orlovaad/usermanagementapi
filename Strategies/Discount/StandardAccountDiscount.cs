namespace UserManagementApi.Strategies.Discount
{
    public class StandardAccountDiscount : IDiscountStrategy
    {
        public decimal CalcDiscount()
        {
            return 10;
        }
    }
}
