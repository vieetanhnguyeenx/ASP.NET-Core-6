using BookStore.DTO;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SigUpAsyn(UserDTOSignUpRequest user);
        Task<string> SignInAsyn(UserDTOSignInRequest user);

    }
}
