using System;
using System.Collections.Generic;
using WebApplicationRmz.Data;
using WebApplicationRmz.Model;

namespace WebApplicationRmz.Service.ShoppingCartService
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public ShoppingCartService(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;

        }

        public ShoppingItem Add(ShoppingItem newItem) => throw new NotImplementedException();
        public IEnumerable<ShoppingItem> GetAllItems() => _ApplicationDbContext.ShoppingItems;
        public ShoppingItem GetById(Guid id) => throw new NotImplementedException();
        public void Remove(Guid id) => throw new NotImplementedException();
    }
}
