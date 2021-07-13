using Pizza;

namespace PizzaApp
{
    public interface IFactory
    {
        IOrder CreateNewOrder();
        IMenu GetMenu();
        IOrderCalculator GetOrderCalculator();
    }
}