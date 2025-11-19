using CarCare.API.DTOs.Auth.RequestDto;
using CarCare.API.Services;
using CarCare.DAL.Entities;
using Microsoft.AspNetCore.Identity;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _config;
     private readonly SignInManager<User> _signInManager;

    private readonly ITokenService _tokenService;
    public AuthService(UserManager<User> userManager, 
                       IEmailService emailService,
                       IConfiguration config, 
                       SignInManager<User> signInManager,
                       ITokenService tokenService)
                       
    {
        _userManager = userManager;
        _emailService = emailService;
        _config = config;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<bool> SendEmailVerificationAsync(User user)
    {
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var url = $"{_config["AppUrl"]}/api/auth/confirm-email?userId={user.Id}&token={Uri.EscapeDataString(token)}";
         if (string.IsNullOrWhiteSpace(user.Email))
              throw new InvalidOperationException("User email is missing.");
        await _emailService.SendEmailAsync(user.Email, "Verify Email", $"Click to verify: {url}");
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
        var user = new User
        {
            UserName = dto.Email,
            Email = dto.Email,
            Name = dto.Name
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
            throw new InvalidOperationException(result.Errors.First().Description);

        // Assign default role
        await _userManager.AddToRoleAsync(user, "Customer");

        // Send verification email
        await SendEmailVerificationAsync(user);

        return "Registration successful. Check your email for verification.";
    }

    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null) throw new InvalidOperationException("Invalid email or password.");

        var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, false);
        if (!result.Succeeded) throw new InvalidOperationException("Invalid email or password.");

        return _tokenService.CreateToken(user);
    }
}
