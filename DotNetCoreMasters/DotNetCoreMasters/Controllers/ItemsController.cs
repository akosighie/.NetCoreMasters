using AutoMapper;
using DotNetCoreMasters.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DotNetCoreMasters.Controllers
{
    public class ItemsController : Controller
    {
        public int Get(int userId)
        {
            var res = new ItemService();
            var listOfStrings = res.GetAll(userId);

            return 0;
        }

        public void Post(ItemCreateBindingModel itemModel)
        {
            var res = new ItemService();
            var itemDTOmap = new ItemDTO();

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItemCreateBindingModel, ItemDTO>();
            });
            IMapper mapper = configMapper.CreateMapper();
            var mappedItemDTO = mapper.Map(itemModel, itemDTOmap);

            res.Save(mappedItemDTO);
        }
    }
}
