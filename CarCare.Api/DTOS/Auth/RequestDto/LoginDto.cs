namespace CarCare.API.DTOs.Auth.RequestDto
{
    public class LoginDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
