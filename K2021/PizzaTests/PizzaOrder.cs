using System.Collections.Generic;
using System.Linq;

namespace PizzaTests
{
    internal class PizzaOrder
    {
        private readonly Price MinimalOrderValue = new Price(50);

        private readonly IList<OrderItem> items = new List<OrderItem>();

        public bool IsValid()
        {
            return items != null 
                && items.Any() 
                && items.Sum(i=>i.Price.Value) >= MinimalOrderValue.Value;
        }

        public void Add(OrderItem orderItem)
        {
            items.Add(orderItem);
        }
    }
}