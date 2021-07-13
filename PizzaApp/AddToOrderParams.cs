using Pizza;
using System;

namespace PizzaApp
{
    public class AddToOrderParams
    {
        public IOrderItem OrderItem { get; }
        public Guid OrderId { get; }
    }
}
