using Xunit;

namespace PizzaTests
{
    public class OrderTests
    {
        // when... then...
        // when... should...
        // give... should...
        // given...expect ...

        [Fact]
        public void When_order_is_empty_it_should_be_invalid()
        {
            var order = new Order();
            Assert.False(order.IsValid());
        }

        [Fact]
        public void When_order_has_8_pieces_should_be_valid()
        {
            var order = new Order();

            order.Add(new OrderItem("Pepperoni", 2, "Arek"));
            order.Add(new OrderItem("Pepperoni", 2, "Marek"));
            order.Add(new OrderItem("Hawajska", 4, "Darek"));
            

            Assert.True(order.IsValid());
        }

        // todo 2 peperoni, 2 hawajskie 4, margarity -> valid = false


        //-> pepperoni 1/2 * 30
        //-> hawajska 1/2 * 50

        //cena zamówienia = 40 -> ? da się czy się nie da? 

        //Arek -> 7,50
        //Marek -> 7,50
        //Darek -> 25


        //[Fact]
        //public void When_order_is_less_than_minimal_order_should_be_invalid()
        //{
        //    var order = new PizzaOrder();

        //    order.Add(new OrderItem("Margharita", new Price(30)));

        //    Assert.False(order.IsValid());
        //}

        //[Fact]
        //public void When_order_is_valid_should_recived_confirmation()
        //{
        //    var order = new PizzaOrder();

        //    order.Add(new OrderItem("Margharita", new Price(50)));

        //    Assert.True(order.IsValid());
        //}

        //[Fact]
        //public void When_item_was_removed_order_should_not_count_it()
        //{
        //    var order = new PizzaOrder();

        //    order.Add(new OrderItem("Margharita", new Price(25)));
        //    order.Add(new OrderItem("Margharita", new Price(25)));

        //    order.Remove(1);

        //    Assert.False(order.IsValid());
        //}
    }
}
