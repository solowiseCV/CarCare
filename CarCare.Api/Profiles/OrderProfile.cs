using AutoMapper;
using CarCare.DTOs.Order.RequestDto;
using CarCare.DTOs.Order.ResponseDto;
using CarCare.Domain.Entities;

namespace CarCare.API.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderRequestDto, Order>();
            CreateMap<Order, OrderResponseDto>();

            CreateMap<OrderItemRequestDto, OrderItem>();
            CreateMap<OrderItem, OrderItemResponseDto>();
        }
    }
}
