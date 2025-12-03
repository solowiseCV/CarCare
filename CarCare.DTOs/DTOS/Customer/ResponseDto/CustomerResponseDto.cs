using System;

namespace CarCare.DTOs.Customer.ResponseDto
{
    public class CustomerResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? DefaultAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
