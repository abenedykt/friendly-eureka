using System.Linq;

namespace Pizza
{
    public class OrderCalculator : IOrderCalculator
    {
        private const int PizzaPieces = 8;
        private readonly IMenu _menu;

        public OrderCalculator(IMenu menu)
        {
            _menu = menu;
        }

        public Price Calculate(IOrder order)
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

    public class FancyOrderCalculator : IOrderCalculator
    {
        private const int PizzaPieces = 8;
        private readonly IMenu _menu;

        public FancyOrderCalculator(IMenu menu)
        {
            _menu = menu;
        }

        public Price Calculate(IOrder order)
        {
            return new Price(order.Sum(o => o.Pieces * PriceOfSlice(o.PizzaName).Value) + 5);
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