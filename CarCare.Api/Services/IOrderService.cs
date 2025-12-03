using CarCare.API.DTOS.Order.RequestDto;
using CarCare.API.DTOS.Order.ResponseDto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCare.API.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseDto>> GetOrdersAsync();
        Task<OrderResponseDto?> GetOrderByIdAsync(Guid id);
        Task<OrderResponseDto> CreateOrderAsync(OrderRequestDto orderDto);
        Task<bool> UpdateOrderAsync(Guid id, OrderRequestDto orderDto);
        Task<bool> DeleteOrderAsync(Guid id);

        // OrderItem specific methods
        Task<OrderItemResponseDto?> GetOrderItemByIdAsync(Guid id);
        Task<OrderItemResponseDto> CreateOrderItemAsync(OrderItemRequestDto orderItemDto);
        Task<bool> UpdateOrderItemAsync(Guid id, OrderItemRequestDto orderItemDto);
        Task<bool> DeleteOrderItemAsync(Guid id);
    }
}
