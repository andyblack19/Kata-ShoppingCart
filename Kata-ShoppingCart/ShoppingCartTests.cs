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

        private static readonly List<Discount> Discounts = new List<Discount>
        {
            new Discount("A99", 3, 20),
            new Discount("B15", 2, 15)
        };

        private static ShoppingCart InitialiseShoppingCart()
        {
            return new ShoppingCart(Products, Discounts);
        }

        [TestCase("A99", 50)]
        [TestCase("B15", 30)]
        [TestCase("C40", 60)]
        [TestCase("T34", 99)]
        public void Single_item_gives_individual_price(string sku, int price)
        {
            var cart = InitialiseShoppingCart();
            cart.Scan(sku);
            Assert.That(cart.Total(), Is.EqualTo(price));
        }

        [Test]
        public void Multiple_products_gives_sum_of_prices()
        {
            var cart = InitialiseShoppingCart();
            cart.Scan(Products[0].Sku);
            cart.Scan(Products[1].Sku);
            cart.Scan(Products[2].Sku);
            cart.Scan(Products[3].Sku);
            Assert.That(cart.Total(), Is.EqualTo(239));
        }

        [Test]
        public void Single_discount_applied_to_whole_cart()
        {
            var cart = InitialiseShoppingCart();
            for (var i = 0; i < 3; i++)
                cart.Scan("A99");
            Assert.That(cart.Total(), Is.EqualTo(130));
        }

        [Test]
        public void Single_discount_applied_to_part_of_cart()
        {
            var cart = InitialiseShoppingCart();
            for (var i = 0; i < 4; i++)
                cart.Scan("A99");
            Assert.That(cart.Total(), Is.EqualTo(180));
        }

        [Test]
        public void Single_discount_applied_twice()
        {
            var cart = InitialiseShoppingCart();
            for (var i = 0; i < 6; i++)
                cart.Scan("A99");
            Assert.That(cart.Total(), Is.EqualTo(260));
        }
    }
}
