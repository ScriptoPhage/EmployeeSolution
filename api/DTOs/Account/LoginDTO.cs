using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Account
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
