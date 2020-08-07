using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanityDashboard.Data;

namespace VanityDashboard.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OverviewController : ControllerBase
    {
        private readonly AppDbContext db;

        public OverviewController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult GetOverviewData()
        {
            var pendingOrders = db.Orders.Where(o => o.OrderStatus == OrderStatus.Pending).Count();
            var newOrders = db.Orders.Where(o => o.OrderStatus == OrderStatus.New).Count();
            var overDueOrders = db.Orders.Where(o => o.OrderStatus == OrderStatus.Pending && o.DueOn > DateTime.Today).Count();

            return Ok(new { pendingOrders, newOrders, overDueOrders });
        }
    }
}
