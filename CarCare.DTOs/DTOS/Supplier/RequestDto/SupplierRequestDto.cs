using System;
using System.ComponentModel.DataAnnotations;

namespace CarCare.DTOs.Supplier.RequestDto
{
    public class SupplierRequestDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required, StringLength(200)]
        public string CompanyName { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string ContactPerson { get; set; } = string.Empty;

        [Required, StringLength(255), EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(20), Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Address { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(100)]
        public string? State { get; set; }

        [StringLength(255)]
        public string? BusinessRegistrationNumber { get; set; }
        [StringLength(255)]
        public string? ImportLicenseNumber { get; set; }
        [StringLength(2000)]
        public string? VerificationDocumentsJson { get; set; }
    }
}
