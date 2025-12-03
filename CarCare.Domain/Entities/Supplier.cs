using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarCare.Domain.Entities
{
   public class Supplier
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    [Required, MaxLength(200)]
    public string CompanyName { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string ContactPerson { get; set; } = string.Empty;

    [Required, MaxLength(255), EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required, MaxLength(20), Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    public string? Address { get; set; }

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(100)]
    public string? State { get; set; }

    // Verification
    public bool IsVerified { get; set; } = false;
    public DateTime? VerifiedAt { get; set; }
    public string? BusinessRegistrationNumber { get; set; }
    public string? ImportLicenseNumber { get; set; }
    public string? VerificationDocumentsJson { get; set; }

    // Metrics
    [Column(TypeName = "decimal(3,2)")]
    public decimal AverageRating { get; set; } = 0;

    public int TotalReviews { get; set; }
    public int TotalProductsSold { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal OnTimeDeliveryRate { get; set; } = 100;

    // Status
    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Navigation
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
}
