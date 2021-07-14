using Pizza;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaApp
{
    public class OrderRepository : IOrderRepository
    {
        private static readonly List<IOrder> _orders = new List<IOrder>();

        public void Create(IOrder order)
        {
            _orders.Add(order);
        }

        public IOrder Get(Guid orderId)
        {
            return _orders.FirstOrDefault(o => o.Id == orderId);
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
