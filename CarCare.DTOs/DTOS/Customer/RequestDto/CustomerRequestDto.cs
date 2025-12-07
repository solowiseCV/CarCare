using System;
using System.ComponentModel.DataAnnotations;

namespace CarCare.DTOs.Customer.RequestDto
{
    public class CustomerRequestDto
    {
        [Required]
        public Guid UserId { get; set; }
        [StringLength(255)]
        public string? DefaultAddress { get; set; }
        [StringLength(255)]
        public string? City { get; set; }
        [StringLength(255)]
        public string? State { get; set; }
    }
}
