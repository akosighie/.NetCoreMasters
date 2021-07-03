using DotNetCoreMasters.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMasters.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly JwtSettings _settings;
        public UserController(
            IOptionsSnapshot<JwtSettings> options)
        {
            _settings = options.Value;
            var securityKey = _settings.SecurityKey;
            var issuer = _settings.Issuer;
            var audience = _settings.Audience;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            return Ok(_settings.SecurityKey);
        }

      
    }
}
