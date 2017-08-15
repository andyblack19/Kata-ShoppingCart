using System.Collections.Generic;

namespace Kata_ShoppingCart
{
    public class ShoppingCart
    {
        private readonly List<string> _items = new List<string>();

        public void Scan(string sku)
        {
            _items.Add(sku);
        }

        public int Total()
        {
            return _items.Count * 50;
        }
    }
}