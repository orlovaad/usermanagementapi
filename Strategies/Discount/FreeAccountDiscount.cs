namespace UserManagementApi.Strategies.Discount
{
    public class FreeAccountDiscount : IDiscountStrategy
    {
        public decimal CalcDiscount()
        {
            return 0;
        }
    }
}
