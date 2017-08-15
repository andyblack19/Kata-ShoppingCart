namespace Kata_ShoppingCart
{
    public class Discount
    {
        public string Sku { get; }
        public int Quantity { get; }
        public int Deduction { get; }

        public Discount(string sku, int quantity, int deduction)
        {
            Sku = sku;
            Quantity = quantity;
            Deduction = deduction;
        }
    }
}