using System.ComponentModel.DataAnnotations;

namespace CarCare.DTOs.Auth.RequestDto
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
