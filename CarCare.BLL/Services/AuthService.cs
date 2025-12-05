using CarCare.DTOs.Auth.RequestDto;
using CarCare.BLL.Interfaces;
using CarCare.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using CarCare.DAL.Entities;
using Microsoft.Extensions.Configuration;

namespace CarCare.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _config;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly ITokenService _tokenService;
        public AuthService(UserManager<ApplicationUser> userManager,
                           IEmailService emailService,
                           IConfiguration config,
                           SignInManager<ApplicationUser> signInManager,
                           ITokenService tokenService)

        {
            _userManager = userManager;
            _emailService = emailService;
            _config = config;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<bool> SendEmailVerificationAsync(CarCare.Domain.Entities.User user)
        {
            var applicationUser = await _userManager.FindByIdAsync(user.Id.ToString())
                                  ?? throw new InvalidOperationException($"ApplicationUser with ID {user.Id} not found.");

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
            var url = $"{_config["AppUrl"]}/api/auth/confirm-email?userId={applicationUser.Id}&token={Uri.EscapeDataString(token)}";
            if (string.IsNullOrWhiteSpace(applicationUser.Email))
                throw new InvalidOperationException("User email is missing.");
            await _emailService.SendEmailAsync(applicationUser.Email, "Verify Email", $"Click to verify: {url}");
            return true;
        }


        public async Task<bool> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            var result = await _userManager.ConfirmEmailAsync(user, token);
            return result.Succeeded;
        }

        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return false;

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = $"{_config["AppUrl"]}/reset-password?userId={user.Id}&token={Uri.EscapeDataString(token)}";

            await _emailService.SendEmailAsync(email, "Reset Password", $"Click to reset: {url}");
            return true;
        }

        public async Task<bool> ResetPasswordAsync(string userId, string token, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return result.Succeeded;
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                Name = dto.Name,
            };

            var result = await _userManager.CreateAsync(applicationUser, dto.Password);
            if (!result.Succeeded)
                throw new InvalidOperationException(result.Errors.First().Description);


            await _userManager.AddToRoleAsync(applicationUser, "Customer");

            // Send verification email
            var domainUser = new CarCare.Domain.Entities.User
            {
                Id = applicationUser.Id,
                Email = applicationUser.Email,
                Name = applicationUser.Name
            };
            await SendEmailVerificationAsync(domainUser);

            return "Registration successful. Check your email for verification.";
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var applicationUser = await _userManager.FindByEmailAsync(dto.Email);
            if (applicationUser == null) throw new InvalidOperationException("Invalid email or password.");

            var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, false);
            if (!result.Succeeded) throw new InvalidOperationException("Invalid email or password.");


            var domainUser = new CarCare.Domain.Entities.User
            {
                Id = applicationUser.Id,
                Email = applicationUser.Email,
                Name = applicationUser.Name,
                Address = applicationUser.Address,
                Gender = applicationUser.Gender,
                BirthDate = applicationUser.BirthDate,
                ProfilePictureUrl = applicationUser.ProfilePictureUrl,
                CreatedAt = applicationUser.CreatedAt,
                UpdatedAt = applicationUser.UpdatedAt,
                PhoneNumber = applicationUser.PhoneNumber
            };

            return _tokenService.CreateToken(domainUser);
        }
    }
}
