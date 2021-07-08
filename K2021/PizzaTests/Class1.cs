using NSubstitute;
using Pizza;
using System.Linq;
using Xunit;

namespace PizzaTests
{
    public class Class1
    {
        [Fact]
        public void Menu()
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
                Substitute.For<IMenuPosition>(),
                Substitute.For<IMenuPosition>(),
                Substitute.For<IMenuPosition>()
            });

            //var order = Substitute.For<IOrder>();
            //order.Items ?

            //var orderCalculator = new OrderCalculator(menu);
            
            //// act
            //var result = orderCalculator.Calculate(order);

            // assert
            //Assert.Equal(60, result.Value);
        }


            // klasa do elementów menu z cenami 
            // ->    słownik -> nazwa pizzy i cena


            // pok 1.
            // słownik -> nazwa pizzy i cena
            // enum z nazwami pizzy
            // oddzielna klasa do liczenia ceny

            // pok 2.
            // klasa do elementów menu z cenami
            // jakiś obiekt (cena <-> ludzie)

            // pok 3.
            // słownik -> nazwa pizzy i cena (słownik z ceną mała, średnia, duża)
            // enum z nazwami pizzy

            // pok 4.
            // obiekt pizza -> id, cena, nazwa
            // order item -> pizza i osoba -> cena za order item cena pizzy * il. kawałków
            // liczyć w order
    }

    public class OrderCalculator
    {
        private readonly IMenu _menu;

        public OrderCalculator(IMenu menu)
        {
            _menu = menu;
        }

        internal Price Calculate(IOrder order)
        {
            throw new System.NotImplementedException();
        }
    }
}