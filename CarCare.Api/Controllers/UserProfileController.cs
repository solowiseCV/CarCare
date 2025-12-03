using CarCare.DTOs.Auth.RequestDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CarCare.BLL.Interfaces; 

namespace CarCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetUserProfile()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdString == null) return Unauthorized();

            var userId = Guid.Parse(userIdString);
            var userDto = await _userService.GetCurrentUserByIdAsync(userId);

            if (userDto == null) return NotFound();

            return Ok(userDto);
        }
         
          [HttpPatch("me")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserDto dto)
        {
            var userId = GetUserId();
            if (userId == null) return Unauthorized();

            var result = await _userService.UpdateUserProfileAsync(userId.Value, dto);

            return result ? Ok("Profile updated")
                          : BadRequest("Update failed");
        }

      
        [HttpDelete("me")]
        public async Task<IActionResult> DeleteAccount()
        {
            var userId = GetUserId();
            if (userId == null) return Unauthorized();

            var result = await _userService.DeleteUserByIdAsync(userId.Value);

            return result ? Ok("Account deleted")
                          : BadRequest("Delete failed");
        }

      
        [HttpPut("role/{userId}")]
        [Authorize(Roles = "Admin")]  
        public async Task<IActionResult> UpdateUserRole(Guid userId, [FromQuery] string role)
        {
            var result = await _userService.UpdateUserRoleAsync(userId, role);

            return result ? Ok("Role updated")
                          : BadRequest("Failed to update role");
        }

        private Guid? GetUserId()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return id == null ? null : Guid.Parse(id);
        }
    
    }

  
}