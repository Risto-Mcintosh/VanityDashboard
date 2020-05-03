using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanityDashboard.Data;
using VanityDashboard.Servies;
using VanityDashboard.Web.Models;

namespace VanityDashboard.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITableService tableService;
   

        public TablesController(IMapper mapper, ITableService tableService)
        {
            this.mapper = mapper;
            this.tableService = tableService;
        }
        // GET: api/Tables
        [HttpGet]
        public ActionResult<IEnumerable<TableDto>> Get()
        {
            var results = tableService.GetTables();

            if (results == null){
                return BadRequest();
            }
            return mapper.Map<TableDto[]>(results);
        }

        // GET: api/Tables/5
        [HttpGet("{id}", Name = "Get")]
        public string ControllerBase(int id)
        {
            return "value";
        }

  
        // PUT: api/Tables/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

    }
}
