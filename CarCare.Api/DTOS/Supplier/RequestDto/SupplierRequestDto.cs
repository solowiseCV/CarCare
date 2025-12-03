using System;
using System.ComponentModel.DataAnnotations;

namespace CarCare.API.DTOS.Supplier.RequestDto
{
    public class SupplierRequestDto
    {
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

        public string? BusinessRegistrationNumber { get; set; }
        public string? ImportLicenseNumber { get; set; }
        public string? VerificationDocumentsJson { get; set; }
    }
}
