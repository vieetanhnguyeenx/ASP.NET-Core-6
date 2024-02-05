using AuthDemo.Api.Entity;
using AuthDemo.Api.Models;
using AuthDemo.Api.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration configuration;
        private readonly IUserService userService;

        public AuthController(IConfiguration configuration, IUserService userService)
        {
            this.configuration = configuration;
            this.userService = userService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<string> GetMe()
        {
            var userName = userService.GetUserName();
            return Ok(userName);
            /*
            var username = User?.Identity?.Name;
            var username2 = User?.FindFirstValue(ClaimTypes.Name);
            var role = User.FindFirstValue(ClaimTypes.Role);
            return Ok(new { username, username2, role });
            */
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTORequest request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Username = request.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDTORequest request)
        {
            if (user.Username != request.UserName)
            {
                return BadRequest("User not found");
            }
            if (!VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
                return BadRequest("Password incorrect");
            string token = CreateToken(user);
            return Ok(token);
        }

        private void CreatePasswordHash(string password,
            out byte[] passwordHash,
            out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassword(string pasword, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pasword));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                configuration.GetSection("AppSettings:SecretKey").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        /*
         * "AppSettings": {
    "SecretKey":  "My top scretkey doi den qua"
  }
         */
    }
}

