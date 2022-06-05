using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hunter.API.Data;

namespace Hunter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GhostsController : ControllerBase
    {
        private readonly HunterDbContext _context;

        public GhostsController(HunterDbContext context)
        {
            _context = context;
        }

        // GET: api/Ghosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ghost>>> GetGhosts()
        {
            return await _context.Ghosts.ToListAsync();
        }

        // GET: api/Ghosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ghost>> GetGhost(int id)
        {
            var ghost = await _context.Ghosts.FindAsync(id);

            if (ghost == null)
            {
                return NotFound();
            }

            return ghost;
        }

        // PUT: api/Ghosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGhost(int id, Ghost ghost)
        {
            if (id != ghost.Id)
            {
                return BadRequest();
            }

            _context.Entry(ghost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GhostExists(id))
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

        // POST: api/Ghosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ghost>> PostGhost(Ghost ghost)
        {
            _context.Ghosts.Add(ghost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGhost", new { id = ghost.Id }, ghost);
        }

        // DELETE: api/Ghosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGhost(int id)
        {
            var ghost = await _context.Ghosts.FindAsync(id);
            if (ghost == null)
            {
                return NotFound();
            }

            _context.Ghosts.Remove(ghost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GhostExists(int id)
        {
            return _context.Ghosts.Any(e => e.Id == id);
        }
    }
}
