﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanityDashboard.Data;
using VanityDashboard.Data.Dto;
using VanityDashboard.Services;

namespace VanityDashboard.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IVanityComponentService<Table> tableService;
   

        public TablesController(IMapper mapper, IVanityComponentService<Table> tableService)
        {
            this.mapper = mapper;
            this.tableService = tableService;
        }
        // GET: api/Tables
        [HttpGet]
        public ActionResult<IEnumerable<VanityComponentDto>> GetTables()
        {
            var results = tableService.GetAll();

            if (results == null){
                return BadRequest();
            }
            return mapper.Map<VanityComponentDto[]>(results);
        }

  
        // PUT: api/Tables/5
        [HttpPut("{id}")]
        public ActionResult UpdateTable(VanityComponentDto table)
        {
            var newTable = tableService.Update(mapper.Map<Table>(table));

            if (tableService.CommitChanges() < 1)
            {
                return BadRequest();
            }

            return Ok(mapper.Map<VanityComponentDto>(newTable));

        }
    }
}
