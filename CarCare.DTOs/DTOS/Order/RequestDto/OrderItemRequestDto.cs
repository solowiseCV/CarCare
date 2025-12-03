using System;
using System.ComponentModel.DataAnnotations;

namespace CarCare.DTOs.Order.RequestDto
{
    public class OrderItemRequestDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
