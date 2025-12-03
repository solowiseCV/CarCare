using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarCare.API.DTOS.Order.RequestDto
{
    public class OrderRequestDto
    {
        public Guid UserId { get; set; }

        [Required]
        public string DeliveryAddress { get; set; } = string.Empty;

        // Status is typically managed by the system, but included for completeness if initial status is provided
        [MaxLength(50)]
        public string Status { get; set; } = "Pending"; 

        public bool InstallationRequested { get; set; } = false;
        public Guid? MechanicId { get; set; }
        public DateTime? InstallationDate { get; set; }

        public List<OrderItemRequestDto> Items { get; set; } = new List<OrderItemRequestDto>();
    }
}
