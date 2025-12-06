using System.ComponentModel.DataAnnotations;

namespace CarCare.DTOs.Auth.RequestDto
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [MinLength(6)] // Example: minimum password length
        public string Password { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Role { get; set; } = null!; // New property for selected role
    }
}

