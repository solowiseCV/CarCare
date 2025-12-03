using AutoMapper;
using CarCare.API.DTOS.Order.RequestDto;
using CarCare.API.DTOS.Order.ResponseDto;
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
