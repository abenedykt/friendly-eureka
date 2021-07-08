using NSubstitute;
using Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PizzaTests
{
    public class Class1
    {
        [Fact]
        public void NSubstitute_example()
        {
            // przykład użycia mocka!!!
            // mock, stub, fake, test double, 

            var menu = Substitute.For<IMenu>();

            menu.GetMenu().Returns(new[]{
                Substitute.For<IMenuPosition>(),
                Substitute.For<IMenuPosition>()
            });

            var x = menu.GetMenu().First();
            Assert.NotNull(x);
            // debug x 

            menu.Received(1).GetMenu();
        }

        [Fact]
        public void For_given_order_should_return_total_price()
        {
            // arrange
            var menu = TestMenu();
            var order = TestOrder();

            var orderCalculator = new OrderCalculator(menu);

            // act
            var result = orderCalculator.Calculate(order);

            //assert
            Assert.Equal(60, result.Value);
        }

        private static IOrder TestOrder()
        {
            var order = Substitute.For<IOrder>();
            order.GetEnumerator().Returns(new List<IOrderItem>{
                new OrderItem("Hawajska", 4, "Arek"),
                new OrderItem("Pepperoni", 4, "Marek"),
                new OrderItem("Margharita", 8, "Darek")
            }.GetEnumerator());
            return order;
        }

        private static IMenu TestMenu()
        {
            var menu = Substitute.For<IMenu>();

            menu.GetMenu().Returns(new List<IMenuPosition>{
                new MenuPosition("Hawajska",new Price(60)),
                new MenuPosition("Domowa",new Price(50)),
                new MenuPosition("Pepperoni",new Price(20)),
                new MenuPosition("Margharita",new Price(20))
            });
            return menu;
        }
    }
}