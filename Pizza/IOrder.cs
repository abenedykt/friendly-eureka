using System;
using System.Collections.Generic;

namespace Pizza
{
    public interface IOrder: IEnumerable<IOrderItem>
    {
        Guid OrderId { get; }
        void Add(IOrderItem orderItem);
        bool IsValid();
        void Remove(int index);

    }
}