using Repositories.DatabaseContext.DataContextModel;
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
        private readonly DotNetCoreDBContext _context;
        public ItemRepository(DotNetCoreDBContext context)
        {
            _context = context;
        }

        public IQueryable<Item> All()
        {
            return _context.Items.AsQueryable();
        }

        public Item GetById(int itemId)
        {
            return _context.Items.Where(i => i.ItemId == itemId).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var item = _context.Items.Where(i => i.ItemId == id).FirstOrDefault();

            if (item != null)
                _context.Items.Remove(item);
            _context.SaveChanges();
        }

        public void Save(Item item)
        {
            var isExist = _context.Items.Where(i => i.ItemName.Trim().ToLower() == item.ItemName.Trim().ToLower()).Any();

            if (!isExist)
            {
                _context.Items.Add(item);
                _context.SaveChanges();
            }
        }

        public void Update(Item item)
        {
            var itemToUpdate = _context.Items.Where(i => i.ItemId == item.ItemId).FirstOrDefault();

            if (itemToUpdate != null)
            {
                itemToUpdate.ItemName = item.ItemName;
                _context.SaveChanges();
            }
        }
    }
}
