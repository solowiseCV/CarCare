using System;

namespace CarCare.DTOs.Customer.RequestDto
{
    public class CustomerRequestDto
    {
        public Guid UserId { get; set; }
        public string? DefaultAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
