using CarCare.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarCare.API.Services
{
using CarCare.DAL.Entities; // Added for ApplicationUser
// ... other usings
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public TokenService(IConfiguration configuration , UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager= userManager;
        }

        public string CreateToken(CarCare.Domain.Entities.User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secret = jwtSettings["SecretKey"] 
             ?? throw new InvalidOperationException("JWT SecretKey is not configured.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            // Retrieve ApplicationUser to get roles
            var applicationUser = _userManager.FindByIdAsync(user.Id.ToString()).Result 
                                  ?? throw new InvalidOperationException($"ApplicationUser with ID {user.Id} not found.");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                new Claim(ClaimTypes.Name, applicationUser.UserName ?? "") // Use UserName from ApplicationUser
            };
            
            var roles = _userManager.GetRolesAsync(applicationUser).Result;
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpirationMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
