using AutoMapper;
using CarCare.BLL.Interfaces;
using CarCare.DTOs.Order.RequestDto;
using CarCare.DTOs.Order.ResponseDto;
using CarCare.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCare.BLL.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<OrderItemResponseDto?> GetOrderItemByIdAsync(Guid id)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id);
            return _mapper.Map<OrderItemResponseDto>(orderItem);
        }

        public async Task<OrderItemResponseDto> CreateOrderItemAsync(OrderItemRequestDto orderItemDto)
        {
            var orderItem = _mapper.Map<Domain.Entities.OrderItem>(orderItemDto);
            var newOrderItem = await _orderItemRepository.AddAsync(orderItem);
            return _mapper.Map<OrderItemResponseDto>(newOrderItem);
        }

        public async Task UpdateOrderItemAsync(Guid id, OrderItemRequestDto orderItemDto)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id);
            if (orderItem == null)
            {
              
                return;
            }

            _mapper.Map(orderItemDto, orderItem);
            await _orderItemRepository.UpdateAsync(orderItem);
        }

        public async Task DeleteOrderItemAsync(Guid id)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id);
            if (orderItem == null)
            {
             
                return;
            }
            await _orderItemRepository.DeleteAsync(orderItem);
        }
    }
}
