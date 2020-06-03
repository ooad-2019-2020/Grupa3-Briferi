using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MigrantControlSystem.Models
{
    public class PolicijskaStanicaController : Controller
    {
        private readonly MCSDbContext _context;

        public PolicijskaStanicaController(MCSDbContext context)
        {
            _context = context;
        }

        // GET: PolicijskaStanica
        public async Task<IActionResult> Index()
        {
            return View(await _context.PolicijskaStanica.ToListAsync());
        }

        // GET: PolicijskaStanica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policijskaStanica = await _context.PolicijskaStanica
                .FirstOrDefaultAsync(m => m.id == id);
            if (policijskaStanica == null)
            {
                return NotFound();
            }

            return View(policijskaStanica);
        }

        // GET: PolicijskaStanica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PolicijskaStanica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("policijskaStanica, lokacija")] PolicijskaStanicaLokacijaViewModel viewModel)
        { 
            viewModel.policijskaStanica.lokacija = viewModel.lokacija;
            if (ModelState.IsValid)
            {
                _context.Add(viewModel.lokacija);
                _context.Add(viewModel.policijskaStanica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: PolicijskaStanica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policijskaStanica = await _context.PolicijskaStanica.FindAsync(id);
            if (policijskaStanica == null)
            {
                return NotFound();
            }
            return View(policijskaStanica);
        }

        // POST: PolicijskaStanica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,naziv")] PolicijskaStanica policijskaStanica)
        {
            if (id != policijskaStanica.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policijskaStanica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolicijskaStanicaExists(policijskaStanica.id))
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
            return View(policijskaStanica);
        }

        // GET: PolicijskaStanica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policijskaStanica = await _context.PolicijskaStanica
                .FirstOrDefaultAsync(m => m.id == id);
            if (policijskaStanica == null)
            {
                return NotFound();
            }

            return View(policijskaStanica);
        }

        // POST: PolicijskaStanica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var policijskaStanica = await _context.PolicijskaStanica.FindAsync(id);
            _context.PolicijskaStanica.Remove(policijskaStanica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolicijskaStanicaExists(int id)
        {
            return _context.PolicijskaStanica.Any(e => e.id == id);
        }
    }
}
