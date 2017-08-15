namespace Kata_ShoppingCart
{
    public class DiscountRule
    {
        public string Sku { get; }
        public int Quantity { get; }
        public int Deduction { get; }

        public DiscountRule(string sku, int quantity, int deduction)
        {
            Sku = sku;
            Quantity = quantity;
            Deduction = deduction;
        }
    }
}