namespace PizzaTests
{
    public class OrderItem
    {
        public OrderItem(string name, Price price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }
        public Price Price { get; }

        // operator + 
        // operator >=
    }
}