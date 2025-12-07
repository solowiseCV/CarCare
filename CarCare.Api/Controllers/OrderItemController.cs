using CarCare.DTOs.Order.RequestDto;
using CarCare.DTOs.Order.ResponseDto;
using CarCare.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarCare.API.Controllers
{
    [ApiController]
    [Route("api/orders/{orderId}/items")]
    [Authorize]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet("{itemId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetOrderItem(Guid orderId, Guid itemId)
        {
            var orderItem = await _orderItemService.GetOrderItemByIdAsync(orderId, itemId);
            return Ok(orderItem);
        }

        [HttpPost]

        [Authorize(Roles = "Customer")]

        public async Task<IActionResult> AddOrderItem(Guid orderId, [FromBody] OrderItemRequestDto orderItemDto)

        {

            var newOrderItem = await _orderItemService.CreateOrderItemAsync(orderItemDto);



            return CreatedAtAction(nameof(GetOrderItem), new { orderId = orderId, itemId = newOrderItem.Id }, newOrderItem);

        }



        [HttpPut("{itemId}")]

        [Authorize(Roles = "Customer")]

        public async Task<IActionResult> UpdateOrderItem(Guid orderId, Guid itemId, [FromBody] OrderItemRequestDto orderItemDto)

        {

            await _orderItemService.UpdateOrderItemAsync(itemId, orderItemDto);

            return NoContent();

        }

        [HttpDelete("{itemId}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> DeleteOrderItem(Guid orderId, Guid itemId)
        {
            await _orderItemService.DeleteOrderItemAsync(itemId);
            return NoContent();
        }
    }
}
