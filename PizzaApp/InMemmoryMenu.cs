using Pizza;
using System.Collections.Generic;

namespace PizzaApp
{
    public class InMemmoryMenu : IMenu
    {
        public IEnumerable<IMenuPosition> GetMenu()
        {
            yield return new MenuPosition("Hawajska", 50);
            yield return new MenuPosition("Pepperoni", 20);
            yield return new MenuPosition("Domowa", 30);
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
