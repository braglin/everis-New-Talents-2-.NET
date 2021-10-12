using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstrelaDaMorte.Models;

namespace EstrelaDaMorte.Controllers
{
    public class PlanetasController : Controller
    {
        private readonly Context _context;

        public PlanetasController(Context context)
        {
            _context = context;
        }

        // GET: Planetas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Planetas.ToListAsync());
        }

        // GET: Planetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planeta = await _context.Planetas
                .FirstOrDefaultAsync(m => m.IdPlaneta == id);
            if (planeta == null)
            {
                return NotFound();
            }

            return View(planeta);
        }

        // GET: Planetas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planetas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPlaneta,Nome,Rotacao,Orbita,Diametro,Clima,Populacao")] Planeta planeta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planeta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planeta);
        }

        // GET: Planetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planeta = await _context.Planetas.FindAsync(id);
            if (planeta == null)
            {
                return NotFound();
            }
            return View(planeta);
        }

        // POST: Planetas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPlaneta,Nome,Rotacao,Orbita,Diametro,Clima,Populacao")] Planeta planeta)
        {
            if (id != planeta.IdPlaneta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planeta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanetaExists(planeta.IdPlaneta))
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
            return View(planeta);
        }

        // GET: Planetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planeta = await _context.Planetas
                .FirstOrDefaultAsync(m => m.IdPlaneta == id);
            if (planeta == null)
            {
                return NotFound();
            }

            return View(planeta);
        }

        // POST: Planetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planeta = await _context.Planetas.FindAsync(id);
            _context.Planetas.Remove(planeta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanetaExists(int id)
        {
            return _context.Planetas.Any(e => e.IdPlaneta == id);
        }
    }
}
