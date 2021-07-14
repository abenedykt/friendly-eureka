namespace Pizza
{
    public class OrderItem : IOrderItem
    {
        public OrderItem(string pizzaName, uint pieces, string name)
        {
            PizzaName = pizzaName;
            Pieces = pieces;
            Name = name;
        }

        public string PizzaName { get; }
        public uint Pieces { get; }
        public string Name { get; }
    }
}