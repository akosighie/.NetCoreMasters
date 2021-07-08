using DotNetCoreMasters.BindingModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace DotNetCoreMasters.Controllers
{
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult GetAll()
        {
            var listItems = new List<string>()
            {
                "Item1",
                "Item2",
                "Item3"
            };

            return Ok(listItems);
        }

        [HttpGet("/items/{itemId}")]
        public IActionResult Get(int itemId)
        {

            return Ok(itemId);
        }

        [HttpGet("/items/filterBy")]
        [HttpGet]
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
