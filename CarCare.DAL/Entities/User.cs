using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarCare.DAL.Entities
{
    public class User : IdentityUser<Guid>
    {
        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
         
         public string? ProfilePictureUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }


    }
}
