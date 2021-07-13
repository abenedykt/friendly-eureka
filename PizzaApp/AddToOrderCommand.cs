using Pizza;
using System;

namespace PizzaApp
{
    public class AddToOrderCommand : ICommand
    {
        private readonly IOrderRepository _orderRepository;

        public AddToOrderCommand(AddToOrderParams parameters, IOrderRepository repository)
        {
            Parameters = parameters;
            _orderRepository = repository;
        }

        public AddToOrderParams Parameters { get; }

        public bool CanExecute()
        {
            return Parameters != null
                && Parameters.OrderItem != null
                && Parameters.OrderId != null
                && OrderExists(Parameters.OrderId);
        }

        private bool OrderExists(Guid orderId)
        {
            return _orderRepository.GetOrder(orderId) != null;
        }

        public void Execute()
        {
            var order = _orderRepository.GetOrder(Parameters.OrderId);
            order.Add(Parameters.OrderItem);
            _orderRepository.Update(order);
        }
    }
}
