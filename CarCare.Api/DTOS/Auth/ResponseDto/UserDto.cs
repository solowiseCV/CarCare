using System;
namespace CarCare.API.DTOs.Auth.ResponseDto
{
    public class UserDto
    {
       public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string[] Roles { get; set; } = Array.Empty<string>();
    }
}