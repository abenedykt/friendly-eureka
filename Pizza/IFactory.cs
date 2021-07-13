namespace Pizza
{
    public interface IFactory
    {

        IOrder CreateNewOrder();
        IMenu GetMenu();
        IOrderCalculator GetOrderCalculator();

        IOrderRepository OrderRepository();
    }
}