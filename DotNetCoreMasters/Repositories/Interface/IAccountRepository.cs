using Microsoft.AspNetCore.Identity;
using Repositories.DataContext;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(Signup signup);
    }
}