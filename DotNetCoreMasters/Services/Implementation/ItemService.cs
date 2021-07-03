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

        public void Delete(int itemid)
        {
            _itemRepository.Delete(itemid);
        }

        public ItemDTO Get(int itemId)
        {
            var item = _itemRepository.All();
            var itemRepository = item.Where(i => i.ItemId == itemId).SingleOrDefault();

            var mappedItemDTO = MapItemDTOFromItem(itemRepository);

            return mappedItemDTO;
        }

        public IEnumerable<ItemDTO> GetAll()
        {
            var itemListRepo = _itemRepository.All();
            return MapListItemDTO(itemListRepo);
        }

        public IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters)
        {
            var listItems = _itemRepository.All();

            var filteredItems = ApplyFilter(listItems, filters);

            return MapListItemDTO(filteredItems);

        }

        public void Update(ItemDTO itemDto)
        {
            var mappedItem = MapItemFromDTO(itemDto);
            _itemRepository.Update(mappedItem);
        }

        private List<ItemDTO> MapListItemDTO(IQueryable<Item> itemQueryable)
        {
            var itemListDTO = new List<ItemDTO>();
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, ItemDTO>();
            });

            IMapper mapper = configMapper.CreateMapper();
            var mappedItemDTOEnumerable = mapper.Map(itemQueryable, itemListDTO);

            return mappedItemDTOEnumerable;
        }

        private Item MapItemFromDTO(ItemDTO itemDTO)
        {
            var Item = new Item();
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItemDTO, Item>();
            });

            IMapper mapper = configMapper.CreateMapper();
            var mapItemFromDto = mapper.Map(itemDTO, Item);
            return mapItemFromDto;
        }

        private ItemDTO MapItemDTOFromItem(Item item)
        {
            var itemDTO = new ItemDTO();
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, ItemDTO>();
            });

            IMapper mapper = configMapper.CreateMapper();
            var mapItemDtoFromItem = mapper.Map(item, itemDTO);
            return mapItemDtoFromItem;
        }

        private IQueryable<Item> ApplyFilter(IQueryable<Item> items, ItemByFilterDTO filters)
        {
            switch (filters.columnName)
            {
                case "ItemName":
                    return items.Where(p => p.ItemName.Contains(filters.value.ToString()));
                case "ItemId":
                    return items.Where(p => p.ItemId.ToString().Contains(filters.value.ToString()));
                default:
                    return items;
            }
        }
    }
}
