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

        public AccountRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IdentityResult> CreateUserAsync(Signup signup)
        {
            var userIdentity = new IdentityUser
            {
                Email = signup.Email,
                UserName = signup.UserName
            };

            return await _userManager.CreateAsync(userIdentity, signup.Password);
        }
    }
}
