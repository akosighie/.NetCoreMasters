using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface
{
    public interface IItemService
    {
        IEnumerable<ItemDTO> GetAll();
        IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters);
        ItemDTO Get(int itemId);
        void Add(ItemDTO itemDto);
        void Delete(int itemid);
        void Update(ItemDTO itemDto);

    }
}
