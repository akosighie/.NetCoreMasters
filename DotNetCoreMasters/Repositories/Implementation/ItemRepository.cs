using Repositories.DataContext;
using Repositories.DataContext.Interface;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Implementation
{
    public class ItemRepository : IItemRepository
    {
        private IDataContext _dataContext;
        public ItemRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<Item> All()
        {
            return _dataContext.ListOfItems().AsQueryable();
        }

        public Item GetById(int itemId)
        {
            return _dataContext.ListOfItems().Where(i => i.ItemId == itemId).SingleOrDefault();
        }

        public void Delete(int id)
        {
            var item = _dataContext.ListOfItems().Where(i => i.ItemId == id).SingleOrDefault();
            _dataContext.ListOfItems().Remove(item);
        }

        public void Save(Item item)
        {
            var isExist = _dataContext.ListOfItems().Where(i => i.ItemId == item.ItemId).Any();

            if (!isExist)
                _dataContext.ListOfItems().Add(item);
        }

        public void Update(Item item)
        {
            var listOfItems = _dataContext.ListOfItems();

            foreach (Item i in listOfItems)
            {
                if (i.ItemId == item.ItemId)
                {
                    i.ItemName = item.ItemName;
                }
            }
        }
    }
}
