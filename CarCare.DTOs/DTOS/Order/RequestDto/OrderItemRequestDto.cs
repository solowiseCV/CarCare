using System;
using System.ComponentModel.DataAnnotations;

namespace CarCare.DTOs.Order.RequestDto
{
    public class OrderItemRequestDto
    {
        [Required]
        public Guid ProductId { get; set; }
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal UnitPrice { get; set; }
    }
}
