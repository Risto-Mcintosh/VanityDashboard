using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VanityDashboard.Data;
using VanityDashboard.Services;
using VanityDashboard.Web.Models;
using VanityDashboard.Web.QueryParams;

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
        public ActionResult<OrderDto> GetOrders([FromQuery] OrderQueryStrings query)
        {
            
            var orders = orderService.GetOrders();
            /*if(query.Limit.HasValue) 
            {
                orders = orders.Take(query.Limit.Value);
            } else
            {
                orders = orders.Take(30);
            }*/
          
            if (query.ThisWeek)
            {
                var monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                var sunday = monday.AddDays(6);
                orders = orders.Where(o => o.DueOn <= sunday || o.DueOn >= monday);
            }

            orders = orders.OrderByDescending(o => o.OrderedOn);

            var paginatedList = PaginatedList<Order>.ToPagedList(orders, query.PageNumber ?? 1, query.Limit ?? 30);
            var pageMetaData = new
            {
                paginatedList.Count,
                paginatedList.HasNext,
                paginatedList.HasPrevious,
                paginatedList.TotalCount,
                paginatedList.TotalPages,
                paginatedList.CurrentPage,
            };
            
            if (orders == null)
            {
                return BadRequest();
            }

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageMetaData));

            return Ok(mapper.Map<OrderDto[]>(paginatedList));
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
