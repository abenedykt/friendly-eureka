using Pizza;
using System;
using System.Collections.Generic;

namespace PizzaApp
{
    public interface IPizzaFacade
    {
        Guid StartNewOrder();
        void AddToOrder(Guid orderId, IMenuPosition menuPosition, uint pieces, string person);
        bool CanOrder(Guid orderId);
        Price OrderValue(Guid orderId);

        IEnumerable<IMenuPosition> GetMenu();
    }
}
