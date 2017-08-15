using System.Collections.Generic;
using System.Linq;

namespace Kata_ShoppingCart
{
    public class ShoppingCart
    {
        private readonly IReadOnlyCollection<Product> _products;
        private readonly List<string> _items = new List<string>();

        public ShoppingCart(IReadOnlyCollection<Product> products)
        {
            _products = products;
        }

        public void Scan(string sku)
        {
            _items.Add(sku);
        }

        public int Total()
        {
            return _items.Sum(item => _products.Single(x => x.Sku == item).Price);
        }
    }
}