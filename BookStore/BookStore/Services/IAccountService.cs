using BookStore.DTO;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> SigUpAsyn(UserDTOSignUpRequest user);
        Task<string> SignInAsyn(UserDTOSignInRequest user);
    }
}
