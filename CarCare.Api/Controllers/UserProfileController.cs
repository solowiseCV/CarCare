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
            var userId = GetUserId();
            if (userId == null) return Unauthorized();

            var userDto = await _userService.GetCurrentUserByIdAsync(userId.Value);
            return Ok(userDto);
        }

        [HttpPatch("me")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserDto dto)
        {
            var userId = GetUserId();
            if (userId == null) return Unauthorized();

            await _userService.UpdateUserProfileAsync(userId.Value, dto);
            return Ok("Profile updated");
        }


        [HttpDelete("me")]
        public async Task<IActionResult> DeleteAccount()
        {
            var userId = GetUserId();
            if (userId == null) return Unauthorized();

            await _userService.DeleteUserByIdAsync(userId.Value);
            return Ok("Account deleted");
        }


        [HttpPut("role/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUserRole(Guid userId, [FromQuery] string role)
        {
            await _userService.UpdateUserRoleAsync(userId, role);
            return Ok("Role updated");
        }

        private Guid? GetUserId()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return id == null ? null : Guid.Parse(id);
        }

    }


}