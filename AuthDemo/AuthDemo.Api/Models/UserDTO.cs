using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Api.Models
{
    public class UserDTORequest
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
