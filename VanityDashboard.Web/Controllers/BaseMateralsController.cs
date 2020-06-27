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
using VanityDashboard.Services;

namespace VanityDashboard.Web.Controllers
{
 
    [ApiController]
    public class BaseMateralsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IVanityComponentService<BaseMaterial> baseMaterialService;
   

        public BaseMateralsController(IMapper mapper, IVanityComponentService<BaseMaterial> baseMaterialService)
        {
            this.mapper = mapper;
            this.baseMaterialService = baseMaterialService;
        }
        // GET: api/BaseMaterals
        [HttpGet("/api/products/basematerals")]
        public ActionResult<IEnumerable<VanityComponentDto>> GetBaseMaterals()
        {
            var results = baseMaterialService.GetAll();

            if (results == null){
                return BadRequest();
            }
            return mapper.Map<VanityComponentDto[]>(results);
        }


        // PUT: api/BaseMaterals/5
        [HttpPut("/api/products/basematerals/{id}")]
        public ActionResult UpdateBaseMateral(VanityComponentDto table)
        {
            var newTable = baseMaterialService.Update(mapper.Map<BaseMaterial>(table));

            if (baseMaterialService.CommitChanges() < 1)
            {
                return BadRequest();
            }

            return Ok(mapper.Map<VanityComponentDto>(newTable));

        }
    }
}
