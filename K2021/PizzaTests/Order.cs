using System.Collections.Generic;
using System.Linq;

namespace PizzaTests
{
    internal class Order
    {
        //private readonly Price MinimalOrderValue = new Price(50);

        private readonly IList<OrderItem> items = new List<OrderItem>();

        public bool IsValid()
        {
            return items != null
                && items.Any()
                && items.GroupBy(g => g.PizzaName)
                    .Select(g => new
                    {
                        Name = g.Key,
                        Pieces = g.Sum(p => p.Pieces)
                    }).All(g => g.Pieces % 4 == 0)
                && items.Sum(i=>i.Pieces) % 8 == 0;
        }

        public void Add(OrderItem orderItem)
        {
            items.Add(orderItem);
        }

        //internal void Remove(int index)
        //{
        //    items.RemoveAt(index);
        //}
    }
}