﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MigrantControlSystem.Models;

namespace MigrantControlSystem.Controllers
{
    public class MigrantskiCentarController : Controller
    {
        private readonly MCSDbContext _context;

        public MigrantskiCentarController(MCSDbContext context)
        {
            _context = context;
        }

        // GET: MigrantskiCentar
        public async Task<IActionResult> Index()
        {
            return View(await _context.MigrantskiCentar.ToListAsync());
        }

        // GET: MigrantskiCentar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var migrantskiCentar = await _context.MigrantskiCentar
                .FirstOrDefaultAsync(m => m.id == id);
            if (migrantskiCentar == null)
            {
                return NotFound();
            }

            return View(migrantskiCentar);
        }

        // GET: MigrantskiCentar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MigrantskiCentar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,naziv,kapacitet")] MigrantskiCentar migrantskiCentar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(migrantskiCentar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(migrantskiCentar);
        }

        // GET: MigrantskiCentar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var migrantskiCentar = await _context.MigrantskiCentar.FindAsync(id);
            if (migrantskiCentar == null)
            {
                return NotFound();
            }
            return View(migrantskiCentar);
        }

        // POST: MigrantskiCentar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,naziv,kapacitet")] MigrantskiCentar migrantskiCentar)
        {
            if (id != migrantskiCentar.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(migrantskiCentar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MigrantskiCentarExists(migrantskiCentar.id))
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
            return View(migrantskiCentar);
        }

        // GET: MigrantskiCentar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var migrantskiCentar = await _context.MigrantskiCentar
                .FirstOrDefaultAsync(m => m.id == id);
            if (migrantskiCentar == null)
            {
                return NotFound();
            }

            return View(migrantskiCentar);
        }

        // POST: MigrantskiCentar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var migrantskiCentar = await _context.MigrantskiCentar.FindAsync(id);
            _context.MigrantskiCentar.Remove(migrantskiCentar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MigrantskiCentarExists(int id)
        {
            return _context.MigrantskiCentar.Any(e => e.id == id);
        }
    }
}
