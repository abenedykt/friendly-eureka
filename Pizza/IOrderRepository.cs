using System;

namespace Pizza
{
    public interface IOrderRepository
    {
        void Create(IOrder order);
        IOrder Get(Guid orderId);
        void Update(IOrder order);
    }
}
