using Services.DTO;
using System;
using System.Collections.Generic;
using AutoMapper;
using DomainModel;
using Services.Interface;
using Repositories.Interface;
using Repositories.DataContext;
using System.Linq;

namespace Services
{
    public class ItemService : IItemService
    {
        private IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public void Add(ItemDTO itemDto)
        {
            var itemModel = new Item();

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItemDTO, Item>();
            });

            IMapper mapper = configMapper.CreateMapper();
            var mappedItem = mapper.Map(itemDto, itemModel);


            _itemRepository.Save(mappedItem);
        }

        public void Delete(int id)
        {
            _itemRepository.Delete(id);
        }

        public ItemDTO Get(int itemId)
        {
            var item = _itemRepository.All();
            var itemRepository = item.Where(i => i.ItemId == itemId).SingleOrDefault();

            var itemModelDTO = new ItemDTO();
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, ItemDTO>();
            });

            IMapper mapper = configMapper.CreateMapper();
            var mappedItemDTO = mapper.Map(itemRepository, itemModelDTO);

            return mappedItemDTO;
        }

        public IEnumerable<ItemDTO> GetAll()
        {
            var itemListRepo = _itemRepository.All();

            var itemListDTO = new List<ItemDTO>();
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, ItemDTO>();
            });

            IMapper mapper = configMapper.CreateMapper();
            var mappedItemDTOEnumerable = mapper.Map(itemListRepo, itemListDTO);

            return mappedItemDTOEnumerable;
        }

        public IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters)
        {
            throw new NotImplementedException();
        }

        public void Update(ItemDTO itemDTO)
        {
            var itemModel = new Item();

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItemDTO, Item>();
            });

            IMapper mapper = configMapper.CreateMapper();
            var mappedItem = mapper.Map(itemDTO, itemModel);

            _itemRepository.Save(mappedItem);
        }
    }
}
