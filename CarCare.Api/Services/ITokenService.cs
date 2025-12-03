using CarCare.Domain.Entities;

namespace CarCare.API.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
