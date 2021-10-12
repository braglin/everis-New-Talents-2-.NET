using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstrelaDaMorte.Models;
using System.Data.SqlTypes;

namespace EstrelaDaMorte.Controllers
{
    public class HistoricoViagensController : Controller
    {
        private readonly Context _context;

        public HistoricoViagensController(Context context)
        {
            _context = context;
        }

        // GET: HistoricoViagems
        public async Task<IActionResult> Index()
        {
            return View(await _context.HistoricoViagens.ToListAsync());
        }

        // GET: HistoricoViagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoViagem = await _context.HistoricoViagens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historicoViagem == null)
            {
                return NotFound();
            }

            return View(historicoViagem);
        }

        // GET: HistoricoViagems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HistoricoViagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdNave,IdPiloto,DtSaida,DtChegada")] HistoricoViagem historicoViagem)
        {
            if (ModelState.IsValid)
            {
                historicoViagem.DtChegada = SqlDateTime.MinValue.Value;
                _context.Add(historicoViagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historicoViagem);
        }

        // GET: HistoricoViagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoViagem = await _context.HistoricoViagens.FindAsync(id);
            if (historicoViagem == null)
            {
                return NotFound();
            }
            return View(historicoViagem);
        }

        // POST: HistoricoViagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdNave,IdPiloto,DtSaida,DtChegada")] HistoricoViagem historicoViagem)
        {
            if (id != historicoViagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historicoViagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricoViagemExists(historicoViagem.Id))
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
            return View(historicoViagem);
        }

        // GET: HistoricoViagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoViagem = await _context.HistoricoViagens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historicoViagem == null)
            {
                return NotFound();
            }

            return View(historicoViagem);
        }

        // POST: HistoricoViagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historicoViagem = await _context.HistoricoViagens.FindAsync(id);
            _context.HistoricoViagens.Remove(historicoViagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoricoViagemExists(int id)
        {
            return _context.HistoricoViagens.Any(e => e.Id == id);
        }
    }
}
