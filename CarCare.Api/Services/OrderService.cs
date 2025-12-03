using AutoMapper;
using CarCare.API.DTOS.Order.RequestDto;
using CarCare.API.DTOS.Order.ResponseDto;
using CarCare.Domain.Interfaces;
using CarCare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCare.API.Services
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
            var orders = await _orderRepository.GetOrdersAsync();
            return _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
        }

        public async Task<OrderResponseDto?> GetOrderByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            return _mapper.Map<OrderResponseDto>(order);
        }

        public async Task<OrderResponseDto> CreateOrderAsync(OrderRequestDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            var newOrder = await _orderRepository.AddOrderAsync(order);
            return _mapper.Map<OrderResponseDto>(newOrder);
        }

        public async Task<bool> UpdateOrderAsync(Guid id, OrderRequestDto orderDto)
        {
            var existingOrder = await _orderRepository.GetOrderByIdAsync(id);
            if (existingOrder == null)
            {
                return false;
            }

            _mapper.Map(orderDto, existingOrder); // Map incoming DTO to existing entity
            return await _orderRepository.UpdateOrderAsync(existingOrder);
        }

        public async Task<bool> DeleteOrderAsync(Guid id)
        {
            return await _orderRepository.DeleteOrderAsync(id);
        }

        // OrderItem specific methods
        public async Task<OrderItemResponseDto?> GetOrderItemByIdAsync(Guid id)
        {
            var orderItem = await _orderRepository.GetOrderItemByIdAsync(id);
            return _mapper.Map<OrderItemResponseDto>(orderItem);
        }

        public async Task<OrderItemResponseDto> CreateOrderItemAsync(OrderItemRequestDto orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            var newOrderItem = await _orderRepository.AddOrderItemAsync(orderItem);
            return _mapper.Map<OrderItemResponseDto>(newOrderItem);
        }

        public async Task<bool> UpdateOrderItemAsync(Guid id, OrderItemRequestDto orderItemDto)
        {
            var existingOrderItem = await _orderRepository.GetOrderItemByIdAsync(id);
            if (existingOrderItem == null)
            {
                return false;
            }

            _mapper.Map(orderItemDto, existingOrderItem);
            return await _orderRepository.UpdateOrderItemAsync(existingOrderItem);
        }

        public async Task<bool> DeleteOrderItemAsync(Guid id)
        {
            return await _orderRepository.DeleteOrderItemAsync(id);
        }
    }
}
