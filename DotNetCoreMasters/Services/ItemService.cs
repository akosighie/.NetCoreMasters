using Services.DTO;
using System;
using System.Collections.Generic;
using AutoMapper;
using DomainModel;

namespace Services
{
    public class ItemService
    {
        public IEnumerable<ItemDomainModel> GetAll(int userId)
        {
            var listItemDTO = new List<ItemDTO>()
            {
                new ItemDTO { itemString = "test1"},
                new ItemDTO { itemString = "test2"},
                new ItemDTO { itemString = "test3"},
            };


            var listItemDomainModel = new List<ItemDomainModel>();

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItemDTO, ItemDomainModel>();
            });

            IMapper mapper = configMapper.CreateMapper();
            var mappedItemDTO = mapper.Map(listItemDTO, listItemDomainModel);

            return listItemDomainModel;
        }

        public void Save(ItemDTO itemDto)
        {
            //Save itemDto here?????
        }
    }
}
