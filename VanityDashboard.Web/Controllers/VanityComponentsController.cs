using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanityDashboard.Data;
using VanityDashboard.Data.Dto;
using VanityDashboard.Data.Models;

namespace VanityDashboard.Web.Controllers
{
    [ApiController]
    public class VanityComponentsController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public VanityComponentsController( AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/products")]
        public ActionResult<VanityComponentDto[]> Get()
        {
            var result = new List<VanityComponentDto[]>
            {
                mapper.Map<VanityComponentDto[]>(context.Set<Mirror>().OrderBy(m => m.Size)),
                mapper.Map<VanityComponentDto[]>(context.Set<Table>().OrderBy(t => t.Size)),
                mapper.Map<VanityComponentDto[]>(context.Set<BaseMaterial>().OrderBy(b => b.Size))
            };

            return Ok(result.SelectMany( x => x));
        }

    }
}