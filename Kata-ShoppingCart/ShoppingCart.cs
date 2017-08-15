using System.Collections.Generic;
using System.Linq;

namespace Kata_ShoppingCart
{
    public class ShoppingCart
    {
        private readonly IReadOnlyCollection<Product> _products;
        private readonly IReadOnlyCollection<DiscountRule> _discountRules;
        private readonly List<string> _items = new List<string>();

        public ShoppingCart(IReadOnlyCollection<Product> products, IReadOnlyCollection<DiscountRule> discountRules)
        {
            _products = products;
            _discountRules = discountRules;
        }

        public void Scan(string sku)
        {
            _items.Add(sku);
        }

        public int Total()
        {
            var subtotal = _items.Sum(item => _products.Single(x => x.Sku == item).Price);
            var discount = 0;

            foreach (var discountRule in _discountRules)
            {
                var timesDiscountApplies = _items.Count(x => x == discountRule.Sku) / discountRule.Quantity;
                discount += discountRule.Deduction * timesDiscountApplies;
            }

            return subtotal - discount;
        }
    }
}