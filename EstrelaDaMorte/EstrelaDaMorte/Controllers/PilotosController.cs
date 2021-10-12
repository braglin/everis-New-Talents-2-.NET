﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstrelaDaMorte.Models;

namespace EstrelaDaMorte.Controllers
{
    public class PilotosController : Controller
    {
        private readonly Context _context;

        public PilotosController(Context context)
        {
            _context = context;
        }

        // GET: Pilotoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pilotos.ToListAsync());
        }

        // GET: Pilotoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = await _context.Pilotos
                .FirstOrDefaultAsync(m => m.IdPiloto == id);
            if (piloto == null)
            {
                return NotFound();
            }

            return View(piloto);
        }

        // GET: Pilotoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pilotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPiloto,Nome,AnoNascimento,IdPlaneta")] Piloto piloto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(piloto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(piloto);
        }

        // GET: Pilotoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = await _context.Pilotos.FindAsync(id);
            if (piloto == null)
            {
                return NotFound();
            }
            return View(piloto);
        }

        // POST: Pilotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPiloto,Nome,AnoNascimento,IdPlaneta")] Piloto piloto)
        {
            if (id != piloto.IdPiloto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(piloto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PilotoExists(piloto.IdPiloto))
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
            return View(piloto);
        }

        // GET: Pilotoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = await _context.Pilotos
                .FirstOrDefaultAsync(m => m.IdPiloto == id);
            if (piloto == null)
            {
                return NotFound();
            }

            return View(piloto);
        }

        // POST: Pilotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var piloto = await _context.Pilotos.FindAsync(id);
            _context.Pilotos.Remove(piloto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PilotoExists(int id)
        {
            return _context.Pilotos.Any(e => e.IdPiloto == id);
        }
    }
}
