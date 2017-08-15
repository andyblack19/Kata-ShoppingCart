using System.Collections.Generic;
using NUnit.Framework;

namespace Kata_ShoppingCart
{
    public class ShoppingCartTests
    {
        private static readonly List<Product> Products = new List<Product>
        {
            new Product("A99", 50),
            new Product("B15", 30),
            new Product("C40", 60),
            new Product("T34", 99)
        };

        [TestCase("A99", 50)]
        [TestCase("B15", 30)]
        [TestCase("C40", 60)]
        [TestCase("T34", 99)]
        public void Single_item_gives_individual_price(string sku, int price)
        {
            var cart = new ShoppingCart(Products);
            cart.Scan(sku);
            Assert.That(cart.Total(), Is.EqualTo(price));
        }

        [Test]
        public void Multiple_products_gives_sum_of_prices()
        {
            var cart = new ShoppingCart(Products);
            cart.Scan(Products[0].Sku);
            cart.Scan(Products[1].Sku);
            cart.Scan(Products[2].Sku);
            cart.Scan(Products[3].Sku);
            Assert.That(cart.Total(), Is.EqualTo(239));
        }
    }
}
