using DotNetCoreMasters.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreMasters.Controllers
{
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;


        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("/items")]
        public IActionResult GetAll()
        {
            var listItems = _itemService.GetAll().ToList();

            return Ok(listItems);
        }

        [HttpGet("/items/{itemId}")]
        public IActionResult Get(int itemId)
        {

            var item = _itemService.Get(itemId);

            return Ok(item);
        }


        [HttpGet("/items/filterBy")]
        public IActionResult GetByFilters([FromQuery] Dictionary<string, string> filterBy)
        {
            var filterDto = filterBy.Select(f => new ItemByFilterDTO { columnName = f.Key, value = f.Value }).SingleOrDefault();
            var items = _itemService.GetAllByFilter(filterDto);

            return Ok(items);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ItemCreateBindingModel itemCreateModel)
        {

            var itemDTO = new ItemDTO
            {
                ItemName = itemCreateModel.itemString
            };

            _itemService.Add(itemDTO);
            return Ok();
        }

        [HttpPut("/items/{itemId}")]
        public IActionResult Put(int itemId, [FromBody] ItemCreateBindingModel itemCreateModel)
        {
            var itemDTO = new ItemDTO
            {
                ItemId = itemId,
                ItemName = itemCreateModel.itemString
            };

            _itemService.Update(itemDTO);
            return Ok();
        }

        [HttpDelete("/items/{itemId}")]
        public IActionResult Delete(int itemid)
        {
            _itemService.Delete(itemid);

            return Ok();
        }

    }
}
