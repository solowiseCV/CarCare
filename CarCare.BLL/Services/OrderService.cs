using AutoMapper;
using CarCare.DTOs.Order.RequestDto;
using CarCare.DTOs.Order.ResponseDto;
using CarCare.Domain.Interfaces;
using CarCare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarCare.BLL.Interfaces;

namespace CarCare.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderResponseDto>> GetOrdersAsync()
        {
            var orders = await _orderRepository.ListAllAsync();
            return _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
        }

        public async Task<OrderResponseDto?> GetOrderByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return _mapper.Map<OrderResponseDto>(order);
        }

        public async Task<OrderResponseDto> CreateOrderAsync(OrderRequestDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            var newOrder = await _orderRepository.AddAsync(order);
            return _mapper.Map<OrderResponseDto>(newOrder);
        }

        public async Task UpdateOrderAsync(Guid id, OrderRequestDto orderDto)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(id);
            if (existingOrder == null)
            {
              
                return;
            }

            _mapper.Map(orderDto, existingOrder);
            await _orderRepository.UpdateAsync(existingOrder);
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
            
                return;
            }
            await _orderRepository.DeleteAsync(order);
        }
    }
}
