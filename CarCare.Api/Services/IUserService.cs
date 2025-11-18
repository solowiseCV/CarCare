using CarCare.API.DTOs.Auth.ResponseDto;

public interface IUserService
{
  Task<UserDto?> GetCurrentUserByIdAsync(Guid userId);
}