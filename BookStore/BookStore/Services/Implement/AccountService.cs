using BookStore.DTO;
using BookStore.Repository;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Services.Implement
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;

        public AccountService(IAccountRepository repository)
        {
            this.repository = repository;
        }

        public Task<string> SignInAsyn(UserDTOSignInRequest user) => repository.SignInAsyn(user);

        public Task<IdentityResult> SigUpAsyn(UserDTOSignUpRequest user) => repository.SigUpAsyn(user);
    }
}
