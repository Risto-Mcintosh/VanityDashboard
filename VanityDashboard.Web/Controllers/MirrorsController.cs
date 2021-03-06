﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VanityDashboard.Data;
using VanityDashboard.Data.Dto;
using VanityDashboard.Services;
using VanityDashboard.Web.Models;

namespace VanityDashboard.Web.Controllers
{
    [ApiController]
    public class MirrorsController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly IVanityComponentService<Mirror> _mirrorService;

        public MirrorsController(IMapper mapper, IVanityComponentService<Mirror> mirrorService)
        {
            this._mapper = mapper;
            this._mirrorService = mirrorService;
        }

      
        [HttpGet("/api/products/mirrors")]
        public ActionResult<IEnumerable<Mirror>> GetMirrors()
        {
            var results = _mirrorService.GetAll();
            if (results == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<VanityComponentDto[]>(results));
        }

       
        [HttpPut("/api/products/mirrors/{id}")]
        public IActionResult PutMirror(VanityComponentDto mirror)
        {

            var newMirror = _mirrorService.Update(_mapper.Map<Mirror>(mirror));
            
            if (_mirrorService.CommitChanges() < 1)
            {
               return BadRequest();
            }

            return Ok(_mapper.Map<VanityComponentDto>(newMirror));
        }

    
    }
}
