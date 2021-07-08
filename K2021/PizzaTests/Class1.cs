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
        public void Calculating_order_price()
        {
            // arrange
            var menu = Substitute.For<IMenu>();

            menu.GetMenu().Returns(new[]{
                new MenuPosition("Hawajska",new Price(60)),
                new MenuPosition("Domowa",new Price(50)),
                new MenuPosition("Pepperoni",new Price(20)),
                new MenuPosition("Margharita",new Price(20))
            });

            var order = Substitute.For<IOrder>();

            var items = new List<IOrderItem>{
                new OrderItem("Hawajska", 4, "Arek"),
                new OrderItem("Pepperoni", 4, "Marek"),
                new OrderItem("Margharita", 8, "Darek")
            };
            order.GetEnumerator().Returns(items.GetEnumerator());

            var orderCalculator = new OrderCalculator(menu);

            // act
            var result = orderCalculator.Calculate(order);

            //assert
            Assert.Equal(60, result.Value);
        }
    }

           

    internal class MenuPosition : IMenuPosition
    {

        public MenuPosition(string name, Price price )
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }
        public Price Price { get; }
    }

    public class OrderCalculator
    {
        private const int PizzaPieces = 8;
        private readonly IMenu _menu;

        public OrderCalculator(IMenu menu)
        {
            _menu = menu;
        }

        internal Price Calculate(IOrder order)
        {
            return new Price(order.Sum(o => o.Pieces * PriceOfSlice(o.PizzaName).Value));
        }

        private Price PriceOfSlice(string pizzaName)
        {
            return new Price(PizzaPrice(pizzaName) / PizzaPieces);
        }

        private decimal PizzaPrice(string pizzaName)
        {
            return _menu.GetMenu().First(x => x.Name == pizzaName).Price.Value;
        }
    }
}