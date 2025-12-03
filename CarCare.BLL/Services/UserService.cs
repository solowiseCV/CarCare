using AutoMapper;
using CarCare.DTOs.Auth.ResponseDto;
using CarCare.DTOs.Auth.RequestDto;
using Microsoft.AspNetCore.Identity;
using CarCare.DAL.Entities; 
using CarCare.BLL.Interfaces; 

namespace CarCare.BLL.Services 
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public UserService(
            UserManager<ApplicationUser> userManager, 
            IMapper mapper, 
            RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<bool> DeleteUserByIdAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<UserDto?> GetCurrentUserByIdAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return null;

            var dto = _mapper.Map<UserDto>(user);
            dto.Roles = (await _userManager.GetRolesAsync(user)).ToArray();

            return dto;
        }

        public async Task<bool> UpdateUserProfileAsync(Guid userId, UpdateUserDto updateDto)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;

            user.Name = updateDto.Name ?? user.Name;
            user.Address = updateDto.Address ?? user.Address;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> UpdateUserRoleAsync(Guid userId, string newRole)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;

            if (!await _roleManager.RoleExistsAsync(newRole))
                return false;

            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);

            var result = await _userManager.AddToRoleAsync(user, newRole);
            return result.Succeeded;
        }
    }
}
