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
    public class FamiliarXpacienteController : Controller
    {
        private readonly TrijuantaBDContext _context;

        public FamiliarXpacienteController(TrijuantaBDContext context)
        {
            _context = context;
        }

        // GET: FamiliarXpaciente
        public async Task<IActionResult> Index()
        {
            var trijuantaBDContext = _context.FamiliarXpacientes.Include(f => f.IdFamiliarNavigation).Include(f => f.IdPacienteNavigation);
            return View(await trijuantaBDContext.ToListAsync());
        }

        // GET: FamiliarXpaciente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiarXpaciente = await _context.FamiliarXpacientes
                .Include(f => f.IdFamiliarNavigation)
                .Include(f => f.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familiarXpaciente == null)
            {
                return NotFound();
            }

            return View(familiarXpaciente);
        }

        // GET: FamiliarXpaciente/Create
        public IActionResult Create()
        {
            ViewData["IdFamiliar"] = new SelectList(_context.Familiars, "Id", "Documento");
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Documento");
            return View();
        }

        // POST: FamiliarXpaciente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdFamiliar,IdPaciente")] FamiliarXpaciente familiarXpaciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familiarXpaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFamiliar"] = new SelectList(_context.Familiars, "Id", "Documento", familiarXpaciente.IdFamiliar);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Documento", familiarXpaciente.IdPaciente);
            return View(familiarXpaciente);
        }

        // GET: FamiliarXpaciente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiarXpaciente = await _context.FamiliarXpacientes.FindAsync(id);
            if (familiarXpaciente == null)
            {
                return NotFound();
            }
            ViewData["IdFamiliar"] = new SelectList(_context.Familiars, "Id", "Documento", familiarXpaciente.IdFamiliar);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Documento", familiarXpaciente.IdPaciente);
            return View(familiarXpaciente);
        }

        // POST: FamiliarXpaciente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdFamiliar,IdPaciente")] FamiliarXpaciente familiarXpaciente)
        {
            if (id != familiarXpaciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familiarXpaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliarXpacienteExists(familiarXpaciente.Id))
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
            ViewData["IdFamiliar"] = new SelectList(_context.Familiars, "Id", "Documento", familiarXpaciente.IdFamiliar);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Documento", familiarXpaciente.IdPaciente);
            return View(familiarXpaciente);
        }

        // GET: FamiliarXpaciente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiarXpaciente = await _context.FamiliarXpacientes
                .Include(f => f.IdFamiliarNavigation)
                .Include(f => f.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familiarXpaciente == null)
            {
                return NotFound();
            }

            return View(familiarXpaciente);
        }

        // POST: FamiliarXpaciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familiarXpaciente = await _context.FamiliarXpacientes.FindAsync(id);
            _context.FamiliarXpacientes.Remove(familiarXpaciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamiliarXpacienteExists(int id)
        {
            return _context.FamiliarXpacientes.Any(e => e.Id == id);
        }
    }
}
