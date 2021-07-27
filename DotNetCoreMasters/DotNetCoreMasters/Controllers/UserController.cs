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
    [Route("user")]
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

        [HttpPost("/user/signup")]
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

        [HttpPost("/user/login")]
        public async Task<IActionResult> Index([FromBody] LoginModel loginModel)
        {
            var loginDTO = new LoginDTO
            {
                UserName = loginModel.UserName,
                Password = loginModel.Password
            };

            var result = await _accountService.Login(loginDTO);

            if (result.Succeeded)
            {
                return Ok(_configSettings.jwt.SecurityKey);
            }

            return NotFound("Invalid username or password!.");
        }


    }
}
