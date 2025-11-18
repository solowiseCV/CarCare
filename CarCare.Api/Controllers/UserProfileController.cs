using CarCare.API.DTOs.Auth.ResponseDto;
using CarCare.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UserProfileController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetUserProfile()
        {
            // Get user ID from JWT claims
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdString == null)
                return Unauthorized();

            var userId = Guid.Parse(userIdString);

            // Fetch user from database
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return NotFound();

            // Get roles
            var roles = await _userManager.GetRolesAsync(user);

            // Map to DTO
            var userDto = new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Name = user.Name,
                Address = user.Address,
                Gender = user.Gender,
                BirthDate = user.BirthDate,
                Roles = roles.ToArray()
            };

            return Ok(userDto);
        }
    }
}
