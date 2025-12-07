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
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseDto>> GetOrdersAsync();
        Task<OrderResponseDto> GetOrderByIdAsync(Guid id);
        Task<OrderResponseDto> CreateOrderAsync(OrderRequestDto orderDto);
        Task UpdateOrderAsync(Guid id, OrderRequestDto orderDto);
        Task DeleteOrderAsync(Guid id);
    }
}
