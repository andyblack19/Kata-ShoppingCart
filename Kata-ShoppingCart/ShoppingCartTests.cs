using NUnit.Framework;

namespace Kata_ShoppingCart
{
    public class ShoppingCartTests
    {
        [Test]
        public void Single_item_gives_individual_price()
        {
            var cart = new ShoppingCart();
            cart.Scan("A99");
            Assert.That(cart.Total(), Is.EqualTo(50));
        }

        [Test]
        public void Two_of_same_item_cart_gives_double_the_individual_price()
        {
            var cart = new ShoppingCart();
            cart.Scan("A99");
            cart.Scan("A99");
            Assert.That(cart.Total(), Is.EqualTo(100));
        }
    }
}
