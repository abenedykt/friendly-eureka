namespace Pizza
{
    public class OrderItem : IOrderItem
    {
        public OrderItem(string pizzaName, int pieces, string name)
        {
            PizzaName = pizzaName;
            Pieces = pieces;
            Name = name;
        }

        public string PizzaName { get; }
        public int Pieces { get; }
        public string Name { get; }

    }
}