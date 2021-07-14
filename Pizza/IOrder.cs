using System;
using System.Collections.Generic;

namespace Pizza
{
    public interface IOrder: IEnumerable<IOrderItem>
    {
        Guid Id { get; }
        void Add(IOrderItem orderItem);
        bool IsValid();
        void Remove(int index);

    }
}