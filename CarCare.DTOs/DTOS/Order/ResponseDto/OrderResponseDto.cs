using System;
using System.Collections.Generic;

namespace CarCare.DTOs.Order.ResponseDto
{
    public class OrderResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string DeliveryAddress { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public bool InstallationRequested { get; set; } = false;
        public Guid? MechanicId { get; set; }
        public DateTime? InstallationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderItemResponseDto> Items { get; set; } = new List<OrderItemResponseDto>();
    }
}
