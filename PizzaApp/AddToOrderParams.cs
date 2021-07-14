using Pizza;
using System;

namespace PizzaApp
{
    public class AddToOrderParams
    {
        public Guid OrderId { get; set; }
        public IOrderItem OrderItem { get; set; }
    }
}
