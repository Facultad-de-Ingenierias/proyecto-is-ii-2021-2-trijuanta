using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dotnet.Models.DB;

namespace dotnet.Controllers.Parameters
{
    public class SignosVitaleController : Controller
    {
        private readonly TrijuantaBDContext _context;

        public SignosVitaleController(TrijuantaBDContext context)
        {
            _context = context;
        }

        // GET: SignosVitale
        public async Task<IActionResult> Index()
        {
            var trijuantaBDContext = _context.SignosVitales.Include(s => s.IdEnfermeroNavigation);
            return View(await trijuantaBDContext.ToListAsync());
        }

        // GET: SignosVitale/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signosVitale = await _context.SignosVitales
                .Include(s => s.IdEnfermeroNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signosVitale == null)
            {
                return NotFound();
            }

            return View(signosVitale);
        }

        // GET: SignosVitale/Create
        public IActionResult Create()
        {
            ViewData["IdEnfermero"] = new SelectList(_context.Enfermeros, "Id", "Documento");
            return View();
        }

        // POST: SignosVitale/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Oximetria,FrecCardiaca,FrecRespiratoria,Temperatura,PresionArterial,Glicemias,IdEnfermero")] SignosVitale signosVitale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signosVitale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEnfermero"] = new SelectList(_context.Enfermeros, "Id", "Documento", signosVitale.IdEnfermero);
            return View(signosVitale);
        }

        // GET: SignosVitale/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signosVitale = await _context.SignosVitales.FindAsync(id);
            if (signosVitale == null)
            {
                return NotFound();
            }
            ViewData["IdEnfermero"] = new SelectList(_context.Enfermeros, "Id", "Documento", signosVitale.IdEnfermero);
            return View(signosVitale);
        }

        // POST: SignosVitale/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Oximetria,FrecCardiaca,FrecRespiratoria,Temperatura,PresionArterial,Glicemias,IdEnfermero")] SignosVitale signosVitale)
        {
            if (id != signosVitale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signosVitale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignosVitaleExists(signosVitale.Id))
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
            ViewData["IdEnfermero"] = new SelectList(_context.Enfermeros, "Id", "Documento", signosVitale.IdEnfermero);
            return View(signosVitale);
        }

        // GET: SignosVitale/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signosVitale = await _context.SignosVitales
                .Include(s => s.IdEnfermeroNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signosVitale == null)
            {
                return NotFound();
            }

            return View(signosVitale);
        }

        // POST: SignosVitale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var signosVitale = await _context.SignosVitales.FindAsync(id);
            _context.SignosVitales.Remove(signosVitale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignosVitaleExists(int id)
        {
            return _context.SignosVitales.Any(e => e.Id == id);
        }
    }
}
