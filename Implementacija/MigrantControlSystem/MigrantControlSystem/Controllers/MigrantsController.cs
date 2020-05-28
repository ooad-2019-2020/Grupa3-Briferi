using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MigrantControlSystem.Models
{
    public class MigrantsController : Controller
    {
        private readonly MCSDbContext _context;

        public MigrantsController(MCSDbContext context)
        {
            _context = context;
        }

        // GET: Migrants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Migrant.ToListAsync());
        }

        // GET: Migrants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var migrant = await _context.Migrant
                .FirstOrDefaultAsync(m => m.id == id);
            if (migrant == null)
            {
                return NotFound();
            }

            return View(migrant);
        }

        // GET: Migrants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Migrants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ime,prezime,drzavaPorijekla,datumRegistracije")] Migrant migrant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(migrant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(migrant);
        }

        // GET: Migrants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var migrant = await _context.Migrant.FindAsync(id);
            if (migrant == null)
            {
                return NotFound();
            }
            return View(migrant);
        }

        // POST: Migrants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,ime,prezime,drzavaPorijekla,datumRegistracije")] Migrant migrant)
        {
            if (id != migrant.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(migrant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MigrantExists(migrant.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(migrant);
        }

        // GET: Migrants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var migrant = await _context.Migrant
                .FirstOrDefaultAsync(m => m.id == id);
            if (migrant == null)
            {
                return NotFound();
            }

            return View(migrant);
        }

        // POST: Migrants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var migrant = await _context.Migrant.FindAsync(id);
            _context.Migrant.Remove(migrant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MigrantExists(int id)
        {
            return _context.Migrant.Any(e => e.id == id);
        }
    }
}
