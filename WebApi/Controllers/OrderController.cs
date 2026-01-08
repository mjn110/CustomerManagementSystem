using Application.DTO.Orders;
using Application.Services.Orders;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public IActionResult Create(CreateOrderDto order)
        {
            _orderService.CreateOrder(order);
            return Ok("The order created sucessfully!");
        }
    }
}
