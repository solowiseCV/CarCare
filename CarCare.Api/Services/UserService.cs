
using AutoMapper;
using CarCare.API.DTOs.Auth.ResponseDto;
using CarCare.DAL.Entities;
using Microsoft.AspNetCore.Identity;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    public UserService(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<UserDto?> GetCurrentUserByIdAsync(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user is null) return null;
        var dto = _mapper.Map<UserDto>(user);

        dto.Roles = (await _userManager.GetRolesAsync(user)).ToArray();
        return dto;
       
    }}

