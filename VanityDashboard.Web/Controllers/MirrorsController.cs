using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VanityDashboard.Data;
using VanityDashboard.Servies;
using VanityDashboard.Web.Models;

namespace VanityDashboard.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MirrorsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMirrorService _mirrorService;

        public MirrorsController(AppDbContext context, IMapper mapper, IMirrorService mirrorService)
        {
            _context = context;
            this._mapper = mapper;
            this._mirrorService = mirrorService;
        }

        // GET: api/Mirrors
        [HttpGet]
        public ActionResult<IEnumerable<Mirror>> GetMirrors()
        {
            var results = _mirrorService.GetMirrors();
            if (results == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<MirrorDto[]>(results));
        }

        // GET: api/Mirrors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetMirror(int id)
        {
            var mirror = await _context.Mirrors.FindAsync(id);

            var m = new
            {
                size = mirror.Size.ToString(),
                price = mirror.Price,
            };

            if (mirror == null)
            {
                return NotFound();
            }

            return m;
        }

        // PUT: api/Mirrors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{size}")]
        public IActionResult PutMirror(MirrorDto mirror)
        {

            var newMirror = _mapper.Map<Mirror>(mirror);
            _mirrorService.UpdateMirror(newMirror);
            
            if (_mirrorService.CommitChanges() > 0)
            {
                return Ok();
            } else
            {
                return BadRequest();
            }
            
        }

    
    }
}
