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
    }

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
    }


    //public class SqlMenuRepository : IMenu
    //{

    //}

    //public class MongoMenuRepository : IMenu
    //{

    //}

    //public class FileMenuRepository : IMenu
    //{

    //}

    //public class SqlMenuRepository : IMenu
    //{

    //}
}
