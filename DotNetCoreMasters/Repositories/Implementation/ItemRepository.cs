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
        private IItemContext _itemContext;
        public ItemRepository(IItemContext itemContext)
        {
            _itemContext = itemContext;
        }

        public IQueryable<Item> All()
        {
            return _itemContext.ListOfItems().AsQueryable();
        }

        public Item GetById(int itemId)
        {
            return _itemContext.ListOfItems().Where(i => i.ItemId == itemId).SingleOrDefault();
        }

        public void Delete(int id)
        {
            var item = _itemContext.ListOfItems().Where(i => i.ItemId == id).SingleOrDefault();
            _itemContext.ListOfItems().Remove(item);
        }

        public void Save(Item item)
        {
            var isExist = _itemContext.ListOfItems().Where(i => i.ItemId == item.ItemId).Any();

            if (!isExist)
                _itemContext.ListOfItems().Add(item);
        }

        public void Update(Item item)
        {
            var listOfItems = _itemContext.ListOfItems();

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
