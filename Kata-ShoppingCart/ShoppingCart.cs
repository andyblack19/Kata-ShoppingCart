using System.Collections.Generic;
using System.Linq;

namespace Kata_ShoppingCart
{
    public class ShoppingCart
    {
        private readonly IReadOnlyCollection<Product> _products;
        private readonly IReadOnlyCollection<Discount> _discounts;
        private readonly List<string> _items = new List<string>();

        public ShoppingCart(IReadOnlyCollection<Product> products, IReadOnlyCollection<Discount> discounts)
        {
            _products = products;
            _discounts = discounts;
        }

        public void Scan(string sku)
        {
            _items.Add(sku);
        }

        public int Total()
        {
            var total = _items.Sum(item => _products.Single(x => x.Sku == item).Price);

            foreach (var discount in _discounts)
            {
                var numberOfTimesDiscountApplies = _items.Count(x => x == discount.Sku) / discount.Quantity;
                var discountAmount = discount.Deduction * numberOfTimesDiscountApplies;
                total -= discountAmount;
            }

            return total;
        }
    }
}