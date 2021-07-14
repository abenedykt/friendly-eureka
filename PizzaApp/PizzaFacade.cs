using Pizza;
using System;
using System.Collections.Generic;

namespace PizzaApp
{
    public class PizzaFacade : IPizzaFacade
    {
        private readonly IFactory _factory;
        private readonly CommandExecutor _;

        private readonly AddToOrderCommand _addToOrder;
        private readonly CreateNewOrderCommand _newOrder;

        public PizzaFacade(IFactory factory)
        {
            _factory = factory;
            _ = new CommandExecutor();

            _addToOrder = new AddToOrderCommand(_factory.OrderRepository());
            _newOrder = new CreateNewOrderCommand(_factory.OrderRepository());
        }

        public void AddToOrder(Guid orderId, IMenuPosition menuPosition, uint pieces, string person)
        {
            var addToOrderParams = new AddToOrderParams(
                orderId,
                new OrderItem(menuPosition.Name, pieces, person)
            );
            
            _.Execute(_addToOrder, addToOrderParams);
        }

        public bool CanOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IMenuPosition> GetMenu()
        {
            return _factory.GetMenu().GetMenu();
        }

        public Price OrderValue(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Guid StartNewOrder()
        {
            var newOrderParams = new CreateNewOrderParams();
            return _.Execute(_newOrder, newOrderParams);
        }
    }
}
