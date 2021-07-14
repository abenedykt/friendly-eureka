using Pizza;
using System;
using System.Collections.Generic;

namespace PizzaApp
{
    public class AddToOrderCommand : ICommand<AddToOrderParams, IOrder>
    {
        private readonly IOrderRepository _orderRepository;

        public AddToOrderCommand(IOrderRepository repository)
        {
            _orderRepository = repository;
        }

        public bool CanExecute(AddToOrderParams @params)
        {
            return @params != null
                && @params.OrderItem != null
                && @params.OrderId != null
                && OrderExists(@params.OrderId);
        }

        private bool OrderExists(Guid orderId)
        {
            return _orderRepository.Get(orderId) != null;
        }

        public IOrder Execute(AddToOrderParams @params)
        {
            var order = _orderRepository.Get(@params.OrderId);
            order.Add(@params.OrderItem);
            _orderRepository.Update(order);

            return order;
        }
    }
}
