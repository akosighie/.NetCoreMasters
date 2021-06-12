using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DotNetCoreMasters.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : Controller
    {
        public IActionResult GetAll(int userId)
        {
            var res = new ItemService();
            var listOfStrings = res.GetAll(userId);

            return Ok(listOfStrings);
        }
    }
}
