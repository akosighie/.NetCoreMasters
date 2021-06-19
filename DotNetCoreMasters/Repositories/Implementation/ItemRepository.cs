using Repositories.DataContext;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Implementation
{
    public class ItemRepository : IItemRepository
    {

        public ItemRepository()
        {
        }

        public IQueryable<Item> All()
        {
            return ListOfItems().AsQueryable();
        }

        public void Delete(int id)
        {
            var item = ListOfItems().Where(i => i.ItemId == id).SingleOrDefault();
            ListOfItems().Remove(item);
        }

        public void Save(Item item)
        {
            var isExist = ListOfItems().Where(i => i.ItemId == item.ItemId).Any();

            if (!isExist)
            ListOfItems().Add(item);
        }

        private List<Item> ListOfItems()
        {
            return new List<Item>()
            {
                new Item{
                    ItemId = 1,
                    ItemName = "First Item"
                },
                 new Item{
                    ItemId = 2,
                    ItemName = "Second Item"
                },
                  new Item{
                    ItemId = 3,
                    ItemName = "Third Item"
                }
            };
        }


    }
}
