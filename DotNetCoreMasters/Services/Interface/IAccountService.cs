using Microsoft.AspNetCore.Identity;
using Services.DTO;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IAccountService
    {
        Task<IdentityResult> Signup(SignupDTO signupDto);
        Task<SignInResult> Login(LoginDTO login);
    }
}