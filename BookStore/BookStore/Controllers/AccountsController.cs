using BookStore.DTO;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService service;

        public AccountsController(IAccountService service)
        {
            this.service = service;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserDTOSignUpRequest signUpRequest)
        {
            var result = await service.SigUpAsyn(signUpRequest);
            if (result.Succeeded)
                return Ok(result.Succeeded);

            var errors = result.Errors;
            var message = string.Join(", ", errors.Select(x => "Code " + x.Code + " Description" + x.Description));
            return StatusCode(500, message);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(UserDTOSignInRequest model)
        {
            var result = await service.SignInAsyn(model);
            if (result.IsNullOrEmpty())
                return Unauthorized();

            return Ok(result);
        }
    }
}
