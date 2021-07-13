using System;

namespace Pizza
{
    public interface IOrderRepository
    {
        IOrder Get(Guid orderId);
        void Update(IOrder order);
    }
}
