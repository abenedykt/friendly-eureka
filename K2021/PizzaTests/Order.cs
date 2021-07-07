using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaTests
{
    public class Order
    {
        private const int PizzaPieces = 8;
        private const int HalfPizzaPieces = 4;

        private readonly IList<OrderItem> items = new List<OrderItem>();

        public bool IsValid()
        {
            return HasAnythingInOrder()
                && PiecesOfSameTypeSumToHalfPizzas()
                && AllPiecessSumToFullPizzas();
        }

        public void Add(OrderItem orderItem)
        {
            if (orderItem == null) { 
                throw new CannotAddNullToOrderException(); 
            }
            items.Add(orderItem);
        }

        private bool AllPiecessSumToFullPizzas()
        {
            return items.Sum(i => i.Pieces) % PizzaPieces == 0;
        }

        private bool PiecesOfSameTypeSumToHalfPizzas()
        {
            return items.GroupBy(g => g.PizzaName)
                                .Select(g => new
                                {
                                    Name = g.Key,
                                    Pieces = g.Sum(p => p.Pieces)
                                }).All(g => g.Pieces % HalfPizzaPieces == 0);
        }

        private bool HasAnythingInOrder()
        {
            return items != null  && items.Any();
        }



        //private readonly Price MinimalOrderValue = new Price(50);

        internal void Remove(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                items.RemoveAt(index);
            }
        }
    }

    internal class CannotAddNullToOrderException : Exception
    {
    }
}