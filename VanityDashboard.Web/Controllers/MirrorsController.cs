using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VanityDashboard.Data;

namespace VanityDashboard.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MirrorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MirrorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Mirrors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mirror>>> GetMirrors()
        {
            return await _context.Mirrors.ToListAsync();
        }

        // GET: api/Mirrors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mirror>> GetMirror(int id)
        {
            var mirror = await _context.Mirrors.FindAsync(id);

            if (mirror == null)
            {
                return NotFound();
            }

            return mirror;
        }

        // PUT: api/Mirrors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMirror(int id, Mirror mirror)
        {
            if (id != mirror.Id)
            {
                return BadRequest();
            }

            _context.Entry(mirror).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MirrorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Mirrors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Mirror>> PostMirror(Mirror mirror)
        {
            _context.Mirrors.Add(mirror);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMirror", new { id = mirror.Id }, mirror);
        }

        // DELETE: api/Mirrors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mirror>> DeleteMirror(int id)
        {
            var mirror = await _context.Mirrors.FindAsync(id);
            if (mirror == null)
            {
                return NotFound();
            }

            _context.Mirrors.Remove(mirror);
            await _context.SaveChangesAsync();

            return mirror;
        }

        private bool MirrorExists(int id)
        {
            return _context.Mirrors.Any(e => e.Id == id);
        }
    }
}
