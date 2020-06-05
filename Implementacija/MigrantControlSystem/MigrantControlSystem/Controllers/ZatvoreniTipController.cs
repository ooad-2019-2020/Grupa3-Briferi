using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MigrantControlSystem.Models
{
    public class ZatvoreniTipController : Controller
    {
        private readonly MCSDbContext _context;

        public ZatvoreniTipController(MCSDbContext context)
        {
            _context = context;
        }

        // GET: ZatvoreniTip
        public async Task<IActionResult> Index()
        {
            return View(await _context.MCZatvoreniTip.ToListAsync());
        }

        // GET: ZatvoreniTip/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mCZatvoreniTip = await _context.MCZatvoreniTip
                .FirstOrDefaultAsync(m => m.id == id);
            if (mCZatvoreniTip == null)
            {
                return NotFound();
            }

            return View(mCZatvoreniTip);
        }

        // GET: ZatvoreniTip/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZatvoreniTip/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("zatvoreniTip,lokacija")] ZatvoreniLokacijaViewModel viewModel)
        {
            viewModel.zatvoreniTip.lokacija = viewModel.lokacija;
            if (ModelState.IsValid)
            {
                _context.Add(viewModel.lokacija);
                _context.Add(viewModel.zatvoreniTip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: ZatvoreniTip/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mCZatvoreniTip = await _context.MCZatvoreniTip.FindAsync(id);
            if (mCZatvoreniTip == null)
            {
                return NotFound();
            }
            return View(mCZatvoreniTip);
        }

        // POST: ZatvoreniTip/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("standardniPeriodZadrzavanjaMigranta,brojZatvorenih,id,naziv,kapacitet")] MCZatvoreniTip mCZatvoreniTip)
        {
            if (id != mCZatvoreniTip.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mCZatvoreniTip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MCZatvoreniTipExists(mCZatvoreniTip.id))
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
            return View(mCZatvoreniTip);
        }

        // GET: ZatvoreniTip/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mCZatvoreniTip = await _context.MCZatvoreniTip
                .FirstOrDefaultAsync(m => m.id == id);
            if (mCZatvoreniTip == null)
            {
                return NotFound();
            }

            return View(mCZatvoreniTip);
        }

        // POST: ZatvoreniTip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mCZatvoreniTip = await _context.MCZatvoreniTip.FindAsync(id);
            _context.MCZatvoreniTip.Remove(mCZatvoreniTip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MCZatvoreniTipExists(int id)
        {
            return _context.MCZatvoreniTip.Any(e => e.id == id);
        }
    }
}
