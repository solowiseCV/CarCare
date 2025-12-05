using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarCare.Domain.Entities
{

    public class Mechanic : BaseEntity
    {

        public Guid UserId { get; set; }

        [Required]
        public string WorkshopName { get; set; } = string.Empty;

        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        public bool IsVerified { get; set; }
        public string? VerificationDocumentUrl { get; set; }

        public decimal Rating { get; set; }
        public int TotalJobsCompleted { get; set; }
    }

}

