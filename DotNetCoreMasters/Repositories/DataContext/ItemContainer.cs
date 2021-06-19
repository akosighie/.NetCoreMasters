using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.DataContext
{
    public class ItemContainer
    {
        public List<Item> ListOfItems()
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
