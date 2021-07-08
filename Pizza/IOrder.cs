using System.Collections.Generic;

namespace Pizza
{
    public interface IOrder: IEnumerable<IOrderItem>
    {
        void Add(IOrderItem orderItem);
        bool IsValid();
        void Remove(int index);

    }
}