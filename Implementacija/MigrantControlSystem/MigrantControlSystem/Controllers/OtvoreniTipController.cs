using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MigrantControlSystem.Models
{
    public class OtvoreniTipController : Controller
    {
        private readonly MCSDbContext _context;

        public OtvoreniTipController(MCSDbContext context)
        {
            _context = context;
        }

        // GET: OtvoreniTip
        public async Task<IActionResult> Index()
        {
            return View(await _context.MCOtvoreniTip.ToListAsync());
        }

        // GET: OtvoreniTip/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mCOtvoreniTip = await _context.MCOtvoreniTip
                .FirstOrDefaultAsync(m => m.id == id);
            if (mCOtvoreniTip == null)
            {
                return NotFound();
            }

            return View(mCOtvoreniTip);
        }

        // GET: OtvoreniTip/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OtvoreniTip/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("otvoreniTip,lokacija")] OtvoreniLokacijaViewModel viewModel)
        {
            viewModel.otvoreniTip.lokacija = viewModel.lokacija;

            if (ModelState.IsValid)
            {
                _context.Add(viewModel.lokacija);
                _context.Add(viewModel.otvoreniTip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: OtvoreniTip/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mCOtvoreniTip = await _context.MCOtvoreniTip.FindAsync(id);
            if (mCOtvoreniTip == null)
            {
                return NotFound();
            }
            return View(mCOtvoreniTip);
        }

        // POST: OtvoreniTip/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("brojRegistrovanih,id,naziv,kapacitet")] MCOtvoreniTip mCOtvoreniTip)
        {
            if (id != mCOtvoreniTip.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mCOtvoreniTip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MCOtvoreniTipExists(mCOtvoreniTip.id))
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
            return View(mCOtvoreniTip);
        }

        // GET: OtvoreniTip/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mCOtvoreniTip = await _context.MCOtvoreniTip
                .FirstOrDefaultAsync(m => m.id == id);
            if (mCOtvoreniTip == null)
            {
                return NotFound();
            }

            return View(mCOtvoreniTip);
        }

        // POST: OtvoreniTip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mCOtvoreniTip = await _context.MCOtvoreniTip.FindAsync(id);
            _context.MCOtvoreniTip.Remove(mCOtvoreniTip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MCOtvoreniTipExists(int id)
        {
            return _context.MCOtvoreniTip.Any(e => e.id == id);
        }
    }
}
