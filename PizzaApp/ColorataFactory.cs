using Pizza;

namespace PizzaApp
{
    public class ColorataFactory : IFactory
    {
        public IOrder CreateNewOrder()
        {
            return new Order();
        }

        public IMenu GetMenu()
        {
            return new InMemmoryMenu();
        }

        public IOrderCalculator GetOrderCalculator()
        {
            return new OrderCalculator(GetMenu());
        }

        public IOrderRepository OrderRepository()
        {
            return new OrderRepository();
        }
    }
}
