using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarCare.DTOs.Order.RequestDto
{
    public class OrderRequestDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string DeliveryAddress { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Status { get; set; } = "Pending";

        public bool InstallationRequested { get; set; } = false;
        public Guid? MechanicId { get; set; }
        public DateTime? InstallationDate { get; set; }

        [MinLength(1, ErrorMessage = "Order must have at least one item.")]
        public List<OrderItemRequestDto> Items { get; set; } = new List<OrderItemRequestDto>();
    }
}
