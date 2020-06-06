using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API;
using System.Collections.Immutable;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicijskaStanicaController : ControllerBase
    {
        private readonly briferi1Context _context;

        public PolicijskaStanicaController(briferi1Context context)
        {
            _context = context;
        }

        // GET: api/PolicijskaStanica
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicijskaStanica>>> GetPolicijskaStanica()
        {
            var stanice = await _context.PolicijskaStanica.ToListAsync();
            foreach(PolicijskaStanica ps in stanice) {
                var lokacija = _context.Lokacija.Find(ps.Lokacijaid);
                ps.Lokacija = lokacija;
            }
            return stanice;
        }

        // GET: api/PolicijskaStanica/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PolicijskaStanica>> GetPolicijskaStanica(int id)
        {
            var policijskaStanica = await _context.PolicijskaStanica.FindAsync(id);
            var lokacija = _context.Lokacija.Find(policijskaStanica.Lokacijaid);
            policijskaStanica.Lokacija = lokacija;

            if (policijskaStanica == null)
            {
                return NotFound();
            }

            return policijskaStanica;
        }

        // PUT: api/PolicijskaStanica/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicijskaStanica(int id, PolicijskaStanica policijskaStanica)
        {
            if (id != policijskaStanica.Id)
            {
                return BadRequest();
            }

            _context.Entry(policijskaStanica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicijskaStanicaExists(id))
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

        // POST: api/PolicijskaStanica
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PolicijskaStanica>> PostPolicijskaStanica(PolicijskaStanica policijskaStanica)
        {
            _context.PolicijskaStanica.Add(policijskaStanica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolicijskaStanica", new { id = policijskaStanica.Id }, policijskaStanica);
        }

        // DELETE: api/PolicijskaStanica/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PolicijskaStanica>> DeletePolicijskaStanica(int id)
        {
            var policijskaStanica = await _context.PolicijskaStanica.FindAsync(id);
            if (policijskaStanica == null)
            {
                return NotFound();
            }

            _context.PolicijskaStanica.Remove(policijskaStanica);
            await _context.SaveChangesAsync();

            return policijskaStanica;
        }

        private bool PolicijskaStanicaExists(int id)
        {
            return _context.PolicijskaStanica.Any(e => e.Id == id);
        }
    }
}
