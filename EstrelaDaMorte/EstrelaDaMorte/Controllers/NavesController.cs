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
    public class NavesController : Controller
    {
        private readonly Context _context;

        public NavesController(Context context)
        {
            _context = context;
        }

        // GET: Naves
        public async Task<IActionResult> Index()
        {
            return View(await _context.Naves.ToListAsync());
        }

        // GET: Naves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nave = await _context.Naves
                .FirstOrDefaultAsync(m => m.IdNave == id);
            if (nave == null)
            {
                return NotFound();
            }

            return View(nave);
        }

        // GET: Naves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Naves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNave,Nome,Modelo,Passageiros,Carga,Classe")] Nave nave)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nave);
        }

        // GET: Naves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nave = await _context.Naves.FindAsync(id);
            if (nave == null)
            {
                return NotFound();
            }
            return View(nave);
        }

        // POST: Naves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNave,Nome,Modelo,Passageiros,Carga,Classe")] Nave nave)
        {
            if (id != nave.IdNave)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NaveExists(nave.IdNave))
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
            return View(nave);
        }

        // GET: Naves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nave = await _context.Naves
                .FirstOrDefaultAsync(m => m.IdNave == id);
            if (nave == null)
            {
                return NotFound();
            }

            return View(nave);
        }

        // POST: Naves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nave = await _context.Naves.FindAsync(id);
            _context.Naves.Remove(nave);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NaveExists(int id)
        {
            return _context.Naves.Any(e => e.IdNave == id);
        }
    }
}
