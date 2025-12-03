using System;
using System.ComponentModel.DataAnnotations;

namespace CarCare.API.DTOS.Supplier.ResponseDto
{
    public class SupplierResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string CompanyName { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        public bool IsVerified { get; set; } = false;
        public DateTime? VerifiedAt { get; set; }
        public string? BusinessRegistrationNumber { get; set; }
        public string? ImportLicenseNumber { get; set; }
        public string? VerificationDocumentsJson { get; set; }

        public decimal AverageRating { get; set; } = 0;
        public int TotalReviews { get; set; }
        public int TotalProductsSold { get; set; }
        public decimal OnTimeDeliveryRate { get; set; } = 100;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
