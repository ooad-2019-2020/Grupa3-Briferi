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
    public class MigrantskiCentarController : ControllerBase
    {
        private readonly briferi1Context _context;

        public MigrantskiCentarController(briferi1Context context)
        {
            _context = context;
        }

        // GET: api/MigrantskiCentar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MigrantskiCentar>>> GetMigrantskiCentar()
        {
            var centri = await _context.MigrantskiCentar.ToListAsync();
            foreach(MigrantskiCentar mc in centri)
            {
                var lokacija = _context.Lokacija.Find(mc.Lokacijaid);
                mc.Lokacija = lokacija;
            }
            return centri;
        }

        // GET: api/MigrantskiCentar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MigrantskiCentar>> GetMigrantskiCentar(int id)
        {
            var migrantskiCentar = await _context.MigrantskiCentar.FindAsync(id);
            var lokacija = _context.Lokacija.Find(migrantskiCentar.Lokacijaid);
            migrantskiCentar.Lokacija = lokacija;

            if (migrantskiCentar == null)
            {
                return NotFound();
            }

            return migrantskiCentar;
        }

        // PUT: api/MigrantskiCentar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMigrantskiCentar(int id, MigrantskiCentar migrantskiCentar)
        {
            if (id != migrantskiCentar.Id)
            {
                return BadRequest();
            }

            _context.Entry(migrantskiCentar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MigrantskiCentarExists(id))
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

        // POST: api/MigrantskiCentar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MigrantskiCentar>> PostMigrantskiCentar(MigrantskiCentar migrantskiCentar)
        {
            _context.MigrantskiCentar.Add(migrantskiCentar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMigrantskiCentar", new { id = migrantskiCentar.Id }, migrantskiCentar);
        }

        // DELETE: api/MigrantskiCentar/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MigrantskiCentar>> DeleteMigrantskiCentar(int id)
        {
            var migrantskiCentar = await _context.MigrantskiCentar.FindAsync(id);
            if (migrantskiCentar == null)
            {
                return NotFound();
            }

            _context.MigrantskiCentar.Remove(migrantskiCentar);
            await _context.SaveChangesAsync();

            return migrantskiCentar;
        }

        private bool MigrantskiCentarExists(int id)
        {
            return _context.MigrantskiCentar.Any(e => e.Id == id);
        }
    }
}
