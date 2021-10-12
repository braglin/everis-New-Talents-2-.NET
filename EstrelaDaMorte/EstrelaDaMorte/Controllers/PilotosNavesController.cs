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
    public class PilotosNavesController : Controller
    {
        private readonly Context _context;

        public PilotosNavesController(Context context)
        {
            _context = context;
        }

        // GET: PilotoNaves
        public async Task<IActionResult> Index()
        {
            return View(await _context.PilotosNaves.ToListAsync());
        }

       
        // GET: PilotoNaves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PilotoNaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPiloto,IdNave,FlagAutorizado")] PilotoNave pilotoNave)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pilotoNave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pilotoNave);
        }

        // GET: PilotoNaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            int idNave = int.Parse(Request.Query["nave"][0]);
            int idPiloto = int.Parse(Request.Query["piloto"][0]);

            if ((idNave == null) || (idPiloto == null))
            {
                return NotFound();
            }

            var pilotoNave = await _context.PilotosNaves.FindAsync(idNave,idPiloto);
            if (pilotoNave == null)
            {
                return NotFound();
            }
            return View(pilotoNave);
        }

        // POST: PilotoNaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int idNave, int idPiloto, [Bind("IdPiloto,IdNave,FlagAutorizado")] PilotoNave pilotoNave)
        {
            if ((idPiloto != pilotoNave.IdPiloto) || (idNave != pilotoNave.IdNave))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pilotoNave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if ((!PilotoNaveExists(pilotoNave.IdPiloto)) || (!PilotoNaveExists(pilotoNave.IdNave)))
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
            return View(pilotoNave);
        }

        private bool PilotoNaveExists(int id)
        {
            return _context.PilotosNaves.Any(e => e.IdPiloto == id);
        }
    }
}
