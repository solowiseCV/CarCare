using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarCare.DTOs.Order.RequestDto
{
    public class OrderRequestDto
    {
        public Guid UserId { get; set; }

        [Required]
        public string DeliveryAddress { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Status { get; set; } = "Pending"; 

        public bool InstallationRequested { get; set; } = false;
        public Guid? MechanicId { get; set; }
        public DateTime? InstallationDate { get; set; }

        public List<OrderItemRequestDto> Items { get; set; } = new List<OrderItemRequestDto>();
    }
}
