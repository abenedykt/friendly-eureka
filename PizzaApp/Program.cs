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
            var executor = new CommandExecutor();

            // tworzenie nowego zamowienie
            var newOrderParams = new CreateNewOrderParams();
            var newOrder = new CreateNewOrderCommand(factory.OrderRepository());
            var orderId = executor.Execute(newOrder, newOrderParams);

            // dodanie pozycji do zamowienia
            var addToOrderParams = new AddToOrderParams(
                orderId,
                new OrderItem(menu.GetMenu().First().Name, 4, "Arek")
            );

            var addToOrder = new AddToOrderCommand(factory.OrderRepository()); 
            var order = executor.Execute(addToOrder, addToOrderParams);



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
}
