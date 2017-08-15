using NUnit.Framework;

namespace Kata_ShoppingCart
{
    public class ShoppingCartTests
    {
        [Test]
        public void Single_item_in_cart_gives_individual_price()
        {
            var cart = new ShoppingCart();
            cart.Scan("A99");
            Assert.That(cart.Total(), Is.EqualTo(50));
        }
    }
}
