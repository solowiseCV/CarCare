using System.ComponentModel.DataAnnotations;

namespace CarCare.DTOs.Auth.RequestDto
{
    public class UpdateUserDto
    {
        [StringLength(255)]
        public string Name { get; set; } = null!;
        [StringLength(255)]
        public string Address { get; set; } = null!;
    }
}