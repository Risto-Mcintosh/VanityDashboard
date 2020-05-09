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
    [Route("api/[controller]")]
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
        public ActionResult<VanityComponentDto[]> Get()
        {
            var result = new List<VanityComponentDto[]>
            {
                AddTypeName(mapper.Map<VanityComponentDto[]>(context.Set<Mirror>().OrderBy(m => m.Size)), "mirror"),
                AddTypeName(mapper.Map<VanityComponentDto[]>(context.Set<Table>().OrderBy(t => t.Size)), "table"),
                AddTypeName(mapper.Map<VanityComponentDto[]>(context.Set<BaseMaterial>().OrderBy(b => b.Size)), "baseMaterial")
            };

            return Ok(result.SelectMany( x => x));
        }

        private static VanityComponentDto[] AddTypeName(VanityComponentDto[] compoenents, string typeName)
        {
            foreach (VanityComponentDto compoenent in compoenents)
            {
                compoenent.Type = typeName;
            }

            return compoenents;
        }
    }
}