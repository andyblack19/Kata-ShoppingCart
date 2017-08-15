namespace Kata_ShoppingCart
{
    public class Product
    {
        public string Sku { get; }

        public int Price { get; }

        public Product(string sku, int price)
        {
            Sku = sku;
            Price = price;
        }
    }
}