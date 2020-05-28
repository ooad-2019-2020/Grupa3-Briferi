using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MigrantControlSystem.Models
{
    public class HapsenjeController : Controller
    {
        private readonly MCSDbContext _context;

        public HapsenjeController(MCSDbContext context)
        {
            _context = context;
        }

        // GET: Hapsenje
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hapsenje.ToListAsync());
        }

        // GET: Hapsenje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hapsenje = await _context.Hapsenje
                .FirstOrDefaultAsync(m => m.id == id);
            if (hapsenje == null)
            {
                return NotFound();
            }

            return View(hapsenje);
        }

        // GET: Hapsenje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hapsenje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("dodatniRokIzvrsenja,id")] Hapsenje hapsenje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hapsenje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hapsenje);
        }

        // GET: Hapsenje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hapsenje = await _context.Hapsenje.FindAsync(id);
            if (hapsenje == null)
            {
                return NotFound();
            }
            return View(hapsenje);
        }

        // POST: Hapsenje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("dodatniRokIzvrsenja,id")] Hapsenje hapsenje)
        {
            if (id != hapsenje.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hapsenje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HapsenjeExists(hapsenje.id))
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
            return View(hapsenje);
        }

        // GET: Hapsenje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hapsenje = await _context.Hapsenje
                .FirstOrDefaultAsync(m => m.id == id);
            if (hapsenje == null)
            {
                return NotFound();
            }

            return View(hapsenje);
        }

        // POST: Hapsenje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hapsenje = await _context.Hapsenje.FindAsync(id);
            _context.Hapsenje.Remove(hapsenje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HapsenjeExists(int id)
        {
            return _context.Hapsenje.Any(e => e.id == id);
        }
    }
}
