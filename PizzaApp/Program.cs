using System.Linq;

namespace PizzaApp
{

    class Program
    {
        static void Main()
        {

            var dagrasso = new DagrassoFactory();
            var app = new PizzaFacade(dagrasso);


            var menu = app.GetMenu();

            // tworzenie nowego zamowienie
            var order = app.StartNewOrder();


            // dodanie pozycji do zamowienia
            app.AddToOrder(order, menu.First(), 4, "Arek");
            app.AddToOrder(order, menu.Skip(1).First(), 4, "Marek");
            app.AddToOrder(order, menu.Skip(2).First(), 4, "Darek");


            //var orderCalculator = dagrasso.GetOrderCalculator();

            //Console.WriteLine($"Order is valid = {order.IsValid()}");
            //Console.WriteLine($"Order value = {orderCalculator.Calculate(order).Value}");
        }

        //private static void ShowMenu(IMenu menu)
        //{
        //    foreach (var menuItem in menu.GetMenu())
        //    {
        //        Console.WriteLine($"{menuItem.Name} : {menuItem.Price.Value}");
        //    }
        //}
    }
}
