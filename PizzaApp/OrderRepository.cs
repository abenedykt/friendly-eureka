using Pizza;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaApp
{
    public class OrderRepository : IOrderRepository
    {
        private List<IOrder> _orders = new List<IOrder>();

        public  IOrder GetOrder(Guid orderId)
        {
            return _orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        public void Update(IOrder order)
        {
            // skrót myslowy :)
        }
    }
}
