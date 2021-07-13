using Pizza;
using System;

namespace PizzaApp
{
    public class AddToOrderCommand : ICommand
    {
        private readonly AddToOrderParams _parameters;
        private readonly IOrderRepository _orderRepository;

        public AddToOrderCommand(AddToOrderParams parameters, IOrderRepository repository)
        {
            _parameters = parameters;
            _orderRepository = repository;
        }


        public bool CanExecute()
        {
            return _parameters != null
                && _parameters.OrderItem != null
                && _parameters.OrderId != null
                && OrderExists(_parameters.OrderId);
        }

        private bool OrderExists(Guid orderId)
        {
            return _orderRepository.Get(orderId) != null;
        }

        public void Execute()
        {
            var order = _orderRepository.Get(_parameters.OrderId);
            order.Add(_parameters.OrderItem);
            _orderRepository.Update(order);
        }
    }
}
