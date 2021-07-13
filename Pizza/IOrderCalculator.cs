namespace Pizza
{
    public interface IOrderCalculator
    {
        Price Calculate(IOrder order);
    }
}