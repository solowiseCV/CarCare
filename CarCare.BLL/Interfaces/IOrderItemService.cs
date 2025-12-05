using CarCare.DTOs.Order.RequestDto;
using CarCare.DTOs.Order.ResponseDto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCare.BLL.Interfaces
{
    public interface IOrderItemService
    {
        Task<OrderItemResponseDto?> GetOrderItemByIdAsync(Guid id);
        Task<OrderItemResponseDto> CreateOrderItemAsync(OrderItemRequestDto orderItemDto);
        Task UpdateOrderItemAsync(Guid id, OrderItemRequestDto orderItemDto);
        Task DeleteOrderItemAsync(Guid id);
    }
}
