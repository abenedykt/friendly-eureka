using Pizza;
using System;
using System.Linq;

namespace PizzaApp
{
    class Program
    {
        static void Main()
        {
            IFactory factory = new DagrassoFactory();

            IMenu menu = factory.GetMenu();
            var order = factory.CreateNewOrder();

            order.Add(new OrderItem(menu.GetMenu().First().Name, 4, "Arek"));
            order.Add(new OrderItem(menu.GetMenu().Skip(1).First().Name, 8, "Darek"));
            order.Add(new OrderItem(menu.GetMenu().Skip(2).First().Name, 4, "Marek"));

            var orderCalculator = factory.GetOrderCalculator();

            ShowMenu(menu);
            Console.WriteLine($"Order is valid = {order.IsValid()}");
            Console.WriteLine($"Order value = {orderCalculator.Calculate(order).Value}");
        }

        private static void ShowMenu(IMenu menu)
        {
            foreach (var menuItem in menu.GetMenu())
            {
                Console.WriteLine($"{menuItem.Name} : {menuItem.Price.Value}");
            }
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
