using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using VanityDashboard.Data;
using VanityDashboard.Services;
using VanityDashboard.Web.Models;

namespace VanityDashboard.Web.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase
    {
        

        private readonly ILogger<Order> _logger;
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrdersController(ILogger<Order> logger, IOrderService orderService, IMapper mapper)
        {
            _logger = logger;
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [HttpGet("api/orders")]
        public ActionResult<OrderDto> GetOrders()
        {
            var orders = orderService.GetOrders();
            if (orders == null)
            {
                return BadRequest();
            }
            return Ok(mapper.Map<OrderDto[]>(orders));
        }

        [HttpGet("api/orders/{id}")]
        public ActionResult<OrderDto> GetOrder(int id)
        {
            var order = orderService.GetOrder(id);
            if (order == null)
            {
                return BadRequest();
            }
            return Ok(mapper.Map<OrderDto>(order));
        }

        [HttpPost("api/orders")]
        public ActionResult<OrderDto> CreateOrder(OrderDto newOrder)
        {
            
            var createdOrder = orderService.CreateOrder(mapper.Map<Order>(newOrder));
            if (createdOrder == null)
            {
                return BadRequest();
            }
            if ( orderService.CommitChanges() < 1)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction("GetOrder", new { id = createdOrder.Id},mapper.Map<OrderDto>(createdOrder));

        }

        [HttpPut("api/orders/{id}")]
        public ActionResult<OrderDto> UpdateOrder(int id, OrderDto updatedOrder)
        {
            orderService.UpdateOrder(mapper.Map<Order>(updatedOrder));

            if (orderService.CommitChanges() < 1)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(mapper.Map<OrderDto>(orderService.GetOrder(id)));
        }

        [HttpDelete("api/orders/{id}")]
        public ActionResult DeleteOrder(int id)
        {
            orderService.DeleteOrder(id);
            if (orderService.CommitChanges() < 1)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok($"Order #{id} deleted");
        }
    }
}
