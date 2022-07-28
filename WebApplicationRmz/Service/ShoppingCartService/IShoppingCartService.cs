using System;
using System.Collections.Generic;
using WebApplicationRmz.Model;

namespace WebApplicationRmz.Service.ShoppingCartService
{
    public interface IShoppingCartService
    {
        IEnumerable<ShoppingItem> GetAllItems();
        ShoppingItem Add(ShoppingItem newItem);
        ShoppingItem GetById(Guid id);
        void Remove(Guid id);
    }
}
