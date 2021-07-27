using Microsoft.AspNetCore.Identity;
using Repositories.DataContext;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<IdentityResult> CreateUserAsync(Signup signup)
        {
            var userIdentity = MapIdentityUser(signup);

            return await _userManager.CreateAsync(userIdentity, signup.Password);
        }

        public async Task SendEmailToken(Signup signup)
        {

            var token = await GenerateToken(signup);
            //email processor here
        }

        public async Task<SignInResult> SignIn(SignIn signin)
        {
            var result = await _signInManager.PasswordSignInAsync(signin.UserName, signin.Password, false, false);
            return result;
        }

        private async Task<string> GenerateToken(Signup signup)
        {
            var userIdentity = MapIdentityUser(signup);
            var result = await _userManager.GenerateEmailConfirmationTokenAsync(userIdentity);
            return result;
        }

        private IdentityUser MapIdentityUser(Signup signup)
        {
            var userIdentity = new IdentityUser
            {
                Email = signup.Email,
                UserName = signup.UserName
            };

            return userIdentity;
        }
    }
}
