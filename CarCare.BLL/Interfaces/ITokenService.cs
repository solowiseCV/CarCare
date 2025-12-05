using CarCare.Domain.Entities;

namespace CarCare.BLL.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
