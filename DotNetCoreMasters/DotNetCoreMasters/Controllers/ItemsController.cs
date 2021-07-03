using AutoMapper;
using DotNetCoreMasters.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DotNetCoreMasters.Controllers
{
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly ItemDTO _itemDTO;

        public ItemsController(IItemService itemService, ItemDTO itemDTO, ItemByFilterDTO itemDTOFilter)
        {
            _itemService = itemService;
            _itemDTO = itemDTO;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listItems = _itemService.GetAll().ToList();

            return Ok(listItems);
        }

        [HttpGet]
        public IActionResult Get(int itemId)
        {

            var item = _itemService.Get(itemId);

            return Ok(item);
        }


        [HttpGet]
        public IActionResult GetByFilters([FromQuery] Dictionary<string, string> filters)
        {
            var filterDto = filters.Select(f => new ItemByFilterDTO { columnName = f.Key, value = f.Value }).SingleOrDefault();
            var items = _itemService.GetAllByFilter(filterDto);

            return Ok(items);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ItemCreateBindingModel itemCreateModel)
        {
            _itemDTO.ItemName = itemCreateModel.itemString;
            _itemService.Add(_itemDTO);

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int itemId, [FromBody] ItemCreateBindingModel itemCreateModel)
        {
            _itemDTO.ItemName = itemCreateModel.itemString;
            _itemDTO.ItemId = itemId;

            _itemService.Update(_itemDTO);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int itemid)
        {
            _itemService.Delete(itemid);

            return Ok();
        }

    }
}
