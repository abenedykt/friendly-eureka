using Pizza;
using Xunit;
using System.Linq;
using NSubstitute;

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
            _order = Order.NewOrder();
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

        [Fact]
        public void When_adding_two_items_order_contains_two_items(){
            
            _order.Add(new OrderItem("Pepperoni", 4, "Arek"));
            _order.Add(new OrderItem("Hawajska", 4, "Marek"));

            Assert.Equal(2, _order.Count());

            // pierwsze podjescie
            Assert.Equal("Pepperoni", _order.First().PizzaName);
            Assert.Equal(4, _order.First().Pieces);
            Assert.Equal("Arek", _order.First().Name);


            // drugie podejscie
            var secondPosition = _order.Skip(1).First();
            Assert.Equal("Hawajska", secondPosition.PizzaName);
            Assert.Equal(4, secondPosition.Pieces);
            Assert.Equal("Marek", secondPosition.Name);
        }


        [Fact]
        public void When_adding_two_items_order_contains_two_items_v2()
        {
            var item1 = new OrderItem("Pepperoni", 4, "Arek");
            var item2 = new OrderItem("Hawajska", 4, "Marek");

            _order.Add(item1);
            _order.Add(item2);


            Assert.Equal(item1, _order.First());
            Assert.Equal(item2, _order.Skip(1).First());
        }

        [Fact]
        public void When_adding_two_items_order_contains_two_items_v3()
        {
            var item1 = Substitute.For<IOrderItem>();
            var item2 = Substitute.For<IOrderItem>();

            _order.Add(item1);
            _order.Add(item2);


            Assert.Equal(item1, _order.First());
            Assert.Equal(item2, _order.Skip(1).First());
        }

        //[Theory, AutoNSubstitute]
        //public void When_adding_two_items_order_contains_two_items_v3(IOrderItem item1, IOrderItem item2)
        //{
        //    _order.Add(item1);
        //    _order.Add(item2);


        //    Assert.Equal(item1, _order.First());
        //    Assert.Equal(item2, _order.Skip(1).First());
        //}


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
            var order = Order.NewOrder();

            Assert.Throws<CannotAddNullToOrderException>(()=>order.Add(null));
        }
    }
}
