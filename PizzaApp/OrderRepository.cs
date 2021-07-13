using Pizza;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaApp
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<IOrder> _orders = new List<IOrder>();

        public IOrder Get(Guid orderId)
        {
            return _orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        public void Update(IOrder order)
        {
            // skrót myslowy :) <- działa bo uzywamy referencji w tej konkretnej implementacji

            // convert
            // find/attach
            // .SaveChanges()
        }
    }
}
