using Pizza;

namespace Pizza
{
    internal class MenuPosition : IMenuPosition
    {

        public MenuPosition(string name, Price price )
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }
        public Price Price { get; }
    }
}