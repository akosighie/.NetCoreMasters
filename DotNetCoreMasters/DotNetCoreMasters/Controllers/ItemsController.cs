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

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listItems = _itemService.GetAll().ToList();

            return Ok(listItems);
        }

        [HttpGet("/items/{itemId}")]
        public IActionResult Get(int itemId)
        {

            return Ok(itemId);
        }


        [HttpGet("/items/filterBy")]
        public IActionResult GetByFilters([FromQuery] Dictionary<string, string> filters)
        {
            var filter = filters;

            return Ok(filter);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ItemCreateBindingModel itemCreateModel)
        {
            var model = itemCreateModel;

            return Ok();
        }

        [HttpPut("/items/{itemId}")]
        public IActionResult Put(int itemId, [FromBody] ItemCreateBindingModel itemCreateModel)
        {
            var newId = itemId;
            var model = itemCreateModel;

            return Ok();
        }

        [HttpDelete("/items/{itemId}")]
        public IActionResult Put(int itemId)
        {
            var newId = itemId;

            return Ok();
        }

    }
}
