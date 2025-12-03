using CarCare.API.DTOs.Auth.RequestDto;
using CarCare.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CarCare.DAL.Entities; 
using CarCare.Domain.Entities; 

namespace CarCare.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly ITokenService _tokenService;

        private readonly IAuthService _authService;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService, IAuthService authService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var message = await _authService.RegisterAsync(registerDto);
            return Ok(message);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _authService.LoginAsync(loginDto);
            return Ok(new { token });
        }

        [HttpPost("send-verification-email")]
        public async Task<IActionResult> SendVerificationEmail()
        {
            var applicationUser = await _userManager.GetUserAsync(User);
            if (applicationUser is null)
                return Unauthorized();
            
            var domainUser = new CarCare.Domain.Entities.User
            {
                Id = applicationUser.Id,
                Email = applicationUser.Email,
                Name = applicationUser.Name // Assuming Name is populated in ApplicationUser
                // Add other properties as needed to map from ApplicationUser to Domain.User
            };

            await _authService.SendEmailVerificationAsync(domainUser); // Pass domainUser
            
            return Ok("Verification email sent.");
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailDto dto)
        {
            var result = await _authService.ConfirmEmailAsync(dto.UserId, dto.Token);
            return result ? Ok("Email confirmed.") : BadRequest("Invalid token.");
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgetPasswordDto dto)
        {
            await _authService.ForgotPasswordAsync(dto.Email);
            return Ok("Password reset link sent.");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
        {
            var result = await _authService.ResetPasswordAsync(dto.UserId, dto.Token, dto.NewPassword);
            return result ? Ok("Password updated.") : BadRequest("Invalid token.");
        }

    }
}