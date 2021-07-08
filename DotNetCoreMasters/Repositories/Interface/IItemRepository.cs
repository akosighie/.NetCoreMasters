using Repositories.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Interface
{
    public interface IItemRepository
    {
        IQueryable<Item> All();
        Item GetById(int itemId);
        void Save(Item item);
        void Delete(int id);
        void Update(Item item);
    }
}
