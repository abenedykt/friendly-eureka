using NSubstitute;
using Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PizzaTests
{
    public class OrderCalculatorTests
    {
        [Fact]
        public void NSubstitute_example()
        {
            // its just an example of how to use mocks!!!
            // mock, stub, fake, dummy, test double, spie, 
            //
            // some reading for curious ones:
            // https://martinfowler.com/bliki/TestDouble.html
            // https://martinfowler.com/articles/mocksArentStubs.html

            var menu = Substitute.For<IMenu>();

            menu.GetMenu().Returns(new[]{
                Substitute.For<IMenuPosition>(),
                Substitute.For<IMenuPosition>()
            });

            var x = menu.GetMenu().First();
            Assert.NotNull(x);
            // go on and inspect x while debuging

            menu.Received(1).GetMenu();
        }

        [Fact]
        public void For_given_order_should_return_total_price()
        {
            // arrange
            var menu = CreateTestMenu();
            var order = CreateTestOrder();


            //var order = OrderBuilder.WithClient("2445")
            //    .AndOrderPosition(new OrderItem("", 1, ""))
            //    .AndOrderPosition(new OrderItem("", 2, ""))
            //    .AndOrderPosition(new OrderItem("", 3, ""))
            //    .AndOrderPosition(new OrderItem("", 1, ""))
            //    .AndShipping("sdff", "sdfd")
            //    .Build();


            var orderCalculator = new OrderCalculator(menu);

            // act
            var result = orderCalculator.Calculate(order);

            //assert
            Assert.Equal(60, result.Value);  // without implicit operator

            Assert.Equal(60, result);        // with implicit operator
            Assert.Equal(60, result, 2);

            Assert.True(60 == result);       // with implicit operator
        }

        private static IOrder CreateTestOrder()
        {
            var order = Substitute.For<IOrder>();
            order.GetEnumerator().Returns(new List<IOrderItem>{
                new OrderItem("Hawajska", 4, "Arek"),
                new OrderItem("Pepperoni", 4, "Marek"),
                new OrderItem("Margharita", 8, "Darek")
            }.GetEnumerator());
            return order;
        }

        private static IMenu CreateTestMenu()
        {
            var menu = Substitute.For<IMenu>();

            menu.GetMenu().Returns(new List<IMenuPosition>{
                new MenuPosition("Hawajska",new Price(60)),
                new MenuPosition("Domowa",new Price(50)),
                new MenuPosition("Pepperoni",20),  
                new MenuPosition("Margharita",20)  // <- can write like this because
                                                   // price has implicit operator
            });
            return menu;
        }
    }

    public class OrderBuilder
    {

        //public static CreateOrder WithClient(string v)
        //{
        //}

        //public static CreateOrder AndOrderPosition(IOrderItem orderItem)
        //{
        //}

        public IOrder Build()
        {

            return Order.NewOrder(); // <- 
        }
    }
}