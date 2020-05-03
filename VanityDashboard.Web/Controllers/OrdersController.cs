using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VanityDashboard.Data;
using VanityDashboard.Servies;
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
            return Ok(mapper.Map<OrderDto[]>(orders));
        }

        [HttpPost("api/orders")]
        public ActionResult<OrderDto> CreateOrder(OrderDto newOrder)
        {
            
            var order = mapper.Map<Order>(newOrder);

            return Ok(mapper.Map<OrderDto>(orderService.CreateOrder(order)));

        }
    }
}
