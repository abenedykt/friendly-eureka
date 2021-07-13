using Pizza;

namespace PizzaApp
{
    public class DagrassoFactory: IFactory
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
            return new FancyOrderCalculator(GetMenu());
        }

        public IOrderRepository OrderRepository()
        {
            return new OrderRepository();  <-
        }
    }
}
