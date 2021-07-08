using System.Collections.Generic;

namespace Pizza
{
    public interface IMenu
    {
        IEnumerable<IMenuPosition> GetMenu();
    }   
}