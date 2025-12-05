using AutoMapper;
using CarCare.DAL.Entities;
using CarCare.DTOs.Auth.ResponseDto;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<ApplicationUser, UserDto>()
            .ForMember(dest => dest.Roles, opt => opt.Ignore());
    }
}
