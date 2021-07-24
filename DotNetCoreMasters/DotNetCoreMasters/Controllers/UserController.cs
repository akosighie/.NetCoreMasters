using DotNetCoreMasters.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Repositories.Implementation;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.DTO;

namespace DotNetCoreMasters.Controllers
{
    [Route("login")]
    public class UserController : ControllerBase
    {
        private readonly Keys.Authentication _configSettings;
        private readonly IAccountService _accountService;

        public UserController(
            IOptions<Keys.Authentication> options, IAccountService accountService)
        {
            _configSettings = options.Value;
            _accountService = accountService;
        }

        [HttpPost("/login/signup")]
        public async Task<IActionResult> Index([FromBody] SignupModel signup)
        {
            var signupDTO = new SignupDTO
            {
                UserName = signup.UserName,
                Email = signup.Email,
                Password = signup.Password
            };

            var result = await _accountService.Signup(signupDTO);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                return Ok();
            }


        }

        [HttpPost("/login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            return Ok(_configSettings.jwt.SecurityKey);
        }


    }
}
