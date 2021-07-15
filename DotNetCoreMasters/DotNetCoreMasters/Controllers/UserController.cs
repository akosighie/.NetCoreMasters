using DotNetCoreMasters.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMasters.Controllers
{
    [Route("login")]
    public class UserController : ControllerBase
    {
        private readonly Keys.Authentication _configSettings;
        public UserController(
            IOptions<Keys.Authentication> options)
        {
            _configSettings = options.Value;

        }

        [HttpGet("/login")]
        public IActionResult Index()
        {
            return Ok(_configSettings);
        }

        [HttpPost("/login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            return Ok(_configSettings.jwt.SecurityKey);
        }


    }
}
