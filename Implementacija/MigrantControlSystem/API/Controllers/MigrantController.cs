using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MigrantController : ControllerBase
    {
        private readonly briferi1Context _context;

        public MigrantController(briferi1Context context)
        {
            _context = context;
        }

        // GET: api/Migrant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Migrant>>> GetMigrant()
        {
            return await _context.Migrant.ToListAsync();
        }

        // GET: api/Migrant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Migrant>> GetMigrant(int id)
        {
            var migrant = await _context.Migrant.FindAsync(id);

            if (migrant == null)
            {
                return NotFound();
            }

            return migrant;
        }

        // PUT: api/Migrant/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMigrant(int id, Migrant migrant)
        {
            if (id != migrant.Id)
            {
                return BadRequest();
            }

            _context.Entry(migrant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MigrantExists(id))
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

        // POST: api/Migrant
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Migrant>> PostMigrant(Migrant migrant)
        {
            _context.Migrant.Add(migrant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMigrant", new { id = migrant.Id }, migrant);
        }

        // DELETE: api/Migrant/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Migrant>> DeleteMigrant(int id)
        {
            var migrant = await _context.Migrant.FindAsync(id);
            if (migrant == null)
            {
                return NotFound();
            }

            _context.Migrant.Remove(migrant);
            await _context.SaveChangesAsync();

            return migrant;
        }

        private bool MigrantExists(int id)
        {
            return _context.Migrant.Any(e => e.Id == id);
        }
    }
}
