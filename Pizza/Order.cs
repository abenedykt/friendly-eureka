using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PizzaTests")] // show internals for specific assemlby :D

namespace Pizza
{
    public class Order : IOrder, IEnumerable<IOrderItem>
    {
        private const int PizzaPieces = 8;
        private const int HalfPizzaPieces = 4;

        private readonly IList<IOrderItem> _items = new List<IOrderItem>();

        public Guid OrderId => throw new NotImplementedException(); // ? 

        public bool IsValid()
        {
            return HasAnythingInOrder()
                && PiecesOfSameTypeSumToHalfPizzas()
                && AllPiecessSumToFullPizzas();
        }

        public void Add(IOrderItem orderItem)
        {
            if (orderItem == null)
            {
                throw new CannotAddNullToOrderException();
            }
            _items.Add(orderItem);
        }

        private bool AllPiecessSumToFullPizzas()
        {
            return _items.Sum(i => i.Pieces) % PizzaPieces == 0;
        }

        private bool PiecesOfSameTypeSumToHalfPizzas()
        {
            return _items.GroupBy(g => g.PizzaName)
                                .Select(g => new
                                {
                                    Name = g.Key,
                                    Pieces = g.Sum(p => p.Pieces)
                                }).All(g => g.Pieces % HalfPizzaPieces == 0);
        }

        private bool HasAnythingInOrder()
        {
            return _items != null && _items.Any();
        }



        //private readonly Price MinimalOrderValue = new Price(50);

        public void Remove(int index)
        {
            if (index >= 0 && index < _items.Count)
            {
                _items.RemoveAt(index);
            }
        }

        public IEnumerator<IOrderItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }

    internal class CannotAddNullToOrderException : Exception
    {
    }
}