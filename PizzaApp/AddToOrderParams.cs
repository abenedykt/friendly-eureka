using Pizza;
using System;

namespace PizzaApp
{
    public class AddToOrderParams
    {
        public AddToOrderParams(Guid orderId, IOrderItem orderItem)
        {
            OrderId = orderId;
            OrderItem = orderItem;
        }

        public Guid OrderId { get; }
        public IOrderItem OrderItem { get; }
    }
}
