using CarCare.DTOs.Order.RequestDto;
using CarCare.DTOs.Order.ResponseDto;
using CarCare.BLL.Interfaces; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

    
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        [AllowAnonymous] 
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        [Authorize(Roles = "Customer")] 
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequestDto orderDto)
        {
            var newOrder = await _orderService.CreateOrderAsync(orderDto);
            return CreatedAtAction(nameof(GetOrder), new { id = newOrder.Id }, newOrder);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Customer,Admin")] 
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] OrderRequestDto orderDto)
        {
            var result = await _orderService.UpdateOrderAsync(id, orderDto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var result = await _orderService.DeleteOrderAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

   
        [HttpGet("{orderId}/items/{itemId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetOrderItem(Guid orderId, Guid itemId)
        {
            var orderItem = await _orderService.GetOrderItemByIdAsync(itemId);
            if (orderItem == null || orderItem.OrderId != orderId)
            {
                return NotFound();
            }
            return Ok(orderItem);
        }

        [HttpPost("{orderId}/items")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> AddOrderItem(Guid orderId, [FromBody] OrderItemRequestDto orderItemDto)
        {
         

            var newOrderItem = await _orderService.CreateOrderItemAsync(orderItemDto);
        
            return CreatedAtAction(nameof(GetOrderItem), new { orderId = orderId, itemId = newOrderItem.Id }, newOrderItem);
        }

        [HttpPut("{orderId}/items/{itemId}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> UpdateOrderItem(Guid orderId, Guid itemId, [FromBody] OrderItemRequestDto orderItemDto)
        {
            var result = await _orderService.UpdateOrderItemAsync(itemId, orderItemDto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{orderId}/items/{itemId}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> DeleteOrderItem(Guid orderId, Guid itemId)
        {
            var result = await _orderService.DeleteOrderItemAsync(itemId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
