using Xunit;

namespace PizzaTests
{
    public class UnitTest1
    {
        // when... then...
        // when... should...
        // give... should...
        // given...expect ...

        [Fact]
        public void When_order_is_empty_it_should_be_invalid()
        {
            var order = new PizzaOrder();
            Assert.False(order.IsValid());
        }

        [Fact]
        public void When_order_is_valid_should_received_confirmation()
        {
            var order = new PizzaOrder();

            order.Add(new OrderItem("Margharita", new Price(50)));

            Assert.True(order.IsValid());
        }
    }
}
