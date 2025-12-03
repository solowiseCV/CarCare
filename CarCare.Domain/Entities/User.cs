
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCare.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? PhoneNumber { get; set; }

   public virtual Supplier? SupplierProfile { get; set; }
    public virtual Customer? CustomerProfile { get; set; }
    public virtual Mechanic? MechanicProfile { get; set; }

    }
}
