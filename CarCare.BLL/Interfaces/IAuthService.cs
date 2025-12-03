using CarCare.DTOs.Auth.RequestDto;
using CarCare.Domain.Entities;

namespace CarCare.BLL.Interfaces 
{
    public interface IAuthService
    {   Task<string> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
        Task<bool> SendEmailVerificationAsync(User user);
        Task<bool> ConfirmEmailAsync(string userId, string token);
        Task<bool> ForgotPasswordAsync(string email);
        Task<bool> ResetPasswordAsync(string userId, string token, string newPassword);

    }
}
