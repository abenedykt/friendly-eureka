using Xunit;

namespace PizzaTests
{
    public class OrderTests
    {
        private readonly Order _order;

        // test naming convention
        // when...  then...
        // when...  should...
        // give...  should...
        // given... expect...
        //
        // general rule -> state under test -> expected behaviour
        // 
        // naming bugs: BUG_ID + description

        public OrderTests()
        {
            _order = new Order();
        }

        [Fact]
        public void When_order_is_empty_it_should_be_invalid()
        {
            Assert.False(_order.IsValid());
        }

        [Fact]
        public void When_order_has_8_pieces_should_be_valid()
        {
            _order.Add(new OrderItem("Pepperoni", 2, "Arek"));
            _order.Add(new OrderItem("Pepperoni", 2, "Marek"));
            _order.Add(new OrderItem("Hawajska", 4, "Darek"));
            
            Assert.True(_order.IsValid());
        }

        [Fact]
        public void When_pizza_kind_pieces_do_not_sum_to_half_pizzas_should_be_invalid()
        {
            _order.Add(new OrderItem("Pepperoni", 2, "Arek"));
            _order.Add(new OrderItem("Hawajska", 2, "Marek"));
            _order.Add(new OrderItem("Margharita", 4, "Darek"));

            Assert.False(_order.IsValid());
        }

        [Fact]
        public void When_all_pieces_do_not_sum_to_full_pizzas_should_be_invalid()
        {
            _order.Add(new OrderItem("Pepperoni", 4, "Arek"));
            _order.Add(new OrderItem("Hawajska", 4, "Marek"));
            _order.Add(new OrderItem("Margharita", 4, "Darek"));

            Assert.False(_order.IsValid());
        }



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

        [Fact]
        public void When_item_was_removed_order_should_not_count_it()
        {
            
            _order.Add(new OrderItem("Margharita", 4, "Arek"));
            _order.Add(new OrderItem("Margharita", 4, "Arek"));

            _order.Remove(1);

            Assert.False(_order.IsValid());
        }

        [Fact]
        public void When_trying_to_remove_nonexistent_item_should_do_nothing()
        {
            _order.Add(new OrderItem("Margharita", 4, "Arek"));
            _order.Add(new OrderItem("Margharita", 4, "Arek"));

            //Assert.DoesNotThrow() <- niestety w wersji 2.x XUnita nie jest juz dostępne
            _order.Remove(-1);
            _order.Remove(1000);

        }

        [Fact]
        public void When_trying_to_add_null_to_order_should_throw_cannot_add_null_to_order_exception()
        {
            var order = new Order();

            Assert.Throws<CannotAddNullToOrderException>(()=>order.Add(null));
        }
    }


}
