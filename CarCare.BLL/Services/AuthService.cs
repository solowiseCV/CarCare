using CarCare.BLL.Exceptions;
using CarCare.DTOs.Auth.RequestDto;
using CarCare.BLL.Interfaces;
using CarCare.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using CarCare.DAL.Entities;
using Microsoft.Extensions.Configuration;
using CarCare.Domain.Interfaces;
using System.Linq;

namespace CarCare.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _config;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly ICustomerRepository _customerRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        public AuthService(UserManager<ApplicationUser> userManager,
                           IEmailService emailService,
                           IConfiguration config,
                           SignInManager<ApplicationUser> signInManager,
                           ITokenService tokenService,
                           ICustomerRepository customerRepository,
                           ISupplierRepository supplierRepository,
                           RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _emailService = emailService;
            _config = config;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _customerRepository = customerRepository;
            _supplierRepository = supplierRepository;
            _roleManager = roleManager;
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

            var allowedRoles = new[] { "Customer", "Supplier" };
            if (!allowedRoles.Contains(dto.Role))
            {
                throw new InvalidOperationException($"Invalid role specified. Allowed roles are: {string.Join(", ", allowedRoles)}.");
            }


            if (!await _roleManager.RoleExistsAsync(dto.Role))
            {
                throw new InvalidOperationException($"Role '{dto.Role}' does not exist in the system. Please contact administrator.");
            }

            var applicationUser = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                Name = dto.Name,
            };

            var result = await _userManager.CreateAsync(applicationUser, dto.Password);
            if (!result.Succeeded)
                throw new InvalidOperationException(result.Errors.First().Description);

            // Assign the chosen role
            await _userManager.AddToRoleAsync(applicationUser, dto.Role);

            // Create specific profile based on role
            switch (dto.Role)
            {
                case "Customer":
                    var customer = new Customer { UserId = applicationUser.Id };
                    await _customerRepository.AddAsync(customer);
                    break;
                case "Supplier":
                    var supplier = new Supplier { UserId = applicationUser.Id, CompanyName = dto.Name }; // Assuming CompanyName can be initialized with user's name
                    await _supplierRepository.AddAsync(supplier);
                    break;
                default:
                    throw new InvalidOperationException("Unsupported role for profile creation.");
            }


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
            if (applicationUser == null) throw new BadRequestException("Invalid email or password.");

            var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, false);
            if (!result.Succeeded) throw new BadRequestException("Invalid email or password.");


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
