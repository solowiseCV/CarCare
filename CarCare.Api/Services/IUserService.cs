using System.Diagnostics.Eventing.Reader;
using CarCare.API.DTOs.Auth.RequestDto;
using CarCare.API.DTOs.Auth.ResponseDto;

public interface IUserService
{
  Task<UserDto?> GetCurrentUserByIdAsync(Guid userId);
  Task<bool> DeleteUserByIdAsync(Guid userId);
  Task<bool> UpdateUserProfileAsync(Guid userId, UpdateUserDto updateUserDto);
  Task<bool> UpdateUserRoleAsync(Guid userId, string newRole);
}