using System;

namespace CarCare.API.DTOS.Customer.RequestDto
{
    public class CustomerRequestDto
    {
        public Guid UserId { get; set; }
        public string? DefaultAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
