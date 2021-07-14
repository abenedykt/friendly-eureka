using Pizza;
using System;

namespace PizzaApp
{
    public class CreateNewOrderCommand : ICommand<CreateNewOrderParams, Guid>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateNewOrderCommand(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public bool CanExecute(CreateNewOrderParams parameters)
        {
            return true;
        }

        public Guid Execute(CreateNewOrderParams parameters)
        {
            var order = Order.NewOrder();
            _orderRepository.Create(order);
            return order.Id;
        }
    }

    public class CreateNewOrderParams
    {
       // a co gdyby tworzyc nowe zamowianie z pozycjami (preinicjalizacja)
       // to tez trzeba by otestowac :D
    }

}
