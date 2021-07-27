using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Repositories.DataContext;
using Repositories.Interface;
using Services.DTO;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IdentityResult> Signup(SignupDTO signupDto)
        {
            var signup = MapSignupFromDTO(signupDto);
            var result = await _accountRepository.CreateUserAsync(signup);

            if (result.Succeeded)
            {
                await _accountRepository.SendEmailToken(signup);
            }

            return result;
        }

        public async Task<SignInResult> Login(LoginDTO login)
        {
            var signinModel = new SignIn
            {
                UserName = login.UserName,
                Password = login.Password
            };

            var result = await _accountRepository.SignIn(signinModel);
            return result;
        }

        private Signup MapSignupFromDTO(SignupDTO signupDto)
        {
            var signup = new Signup();
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SignupDTO, Signup>();
            });

            IMapper mapper = configMapper.CreateMapper();
            var mapSignupFromDto = mapper.Map(signupDto, signup);
            return mapSignupFromDto;
        }
    }
}
