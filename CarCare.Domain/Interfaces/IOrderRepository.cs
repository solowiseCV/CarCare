using CarCare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCare.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order?> GetOrderByIdAsync(Guid id);
        Task<Order> AddOrderAsync(Order order);
        Task<bool> UpdateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(Guid id);

       
        Task<OrderItem?> GetOrderItemByIdAsync(Guid id);
        Task<OrderItem> AddOrderItemAsync(OrderItem orderItem);
        Task<bool> UpdateOrderItemAsync(OrderItem orderItem);
        Task<bool> DeleteOrderItemAsync(Guid id);
    }
}
