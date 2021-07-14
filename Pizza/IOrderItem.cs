namespace Pizza
{
    public interface IOrderItem
    {
        string Name { get; }
        uint Pieces { get; }
        string PizzaName { get; }
    }
}