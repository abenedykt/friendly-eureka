using Pizza;
using System.Linq;

namespace Pizza
{
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