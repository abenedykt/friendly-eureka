using Pizza;
using System;

namespace Pizza
{
    public interface IOrderRepository
    {
        IOrder GetOrder(Guid orderId);
        void Update(IOrder order);
    }
}
