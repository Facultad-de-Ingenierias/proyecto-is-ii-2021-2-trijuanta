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
    public class EnfermeroXpacienteController : Controller
    {
        private readonly TrijuantaBDContext _context;

        public EnfermeroXpacienteController(TrijuantaBDContext context)
        {
            _context = context;
        }

        // GET: EnfermeroXpaciente
        public async Task<IActionResult> Index()
        {
            var trijuantaBDContext = _context.EnfermeroXpacientes.Include(e => e.IdEnfermeroNavigation).Include(e => e.IdPacienteNavigation);
            return View(await trijuantaBDContext.ToListAsync());
        }

        // GET: EnfermeroXpaciente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermeroXpaciente = await _context.EnfermeroXpacientes
                .Include(e => e.IdEnfermeroNavigation)
                .Include(e => e.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enfermeroXpaciente == null)
            {
                return NotFound();
            }

            return View(enfermeroXpaciente);
        }

        // GET: EnfermeroXpaciente/Create
        public IActionResult Create()
        {
            ViewData["IdEnfermero"] = new SelectList(_context.Enfermeros, "Id", "Documento");
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Documento");
            return View();
        }

        // POST: EnfermeroXpaciente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaInicio,FechaFin,IdEnfermero,IdPaciente")] EnfermeroXpaciente enfermeroXpaciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enfermeroXpaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEnfermero"] = new SelectList(_context.Enfermeros, "Id", "Documento", enfermeroXpaciente.IdEnfermero);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Documento", enfermeroXpaciente.IdPaciente);
            return View(enfermeroXpaciente);
        }

        // GET: EnfermeroXpaciente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermeroXpaciente = await _context.EnfermeroXpacientes.FindAsync(id);
            if (enfermeroXpaciente == null)
            {
                return NotFound();
            }
            ViewData["IdEnfermero"] = new SelectList(_context.Enfermeros, "Id", "Documento", enfermeroXpaciente.IdEnfermero);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Documento", enfermeroXpaciente.IdPaciente);
            return View(enfermeroXpaciente);
        }

        // POST: EnfermeroXpaciente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaInicio,FechaFin,IdEnfermero,IdPaciente")] EnfermeroXpaciente enfermeroXpaciente)
        {
            if (id != enfermeroXpaciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfermeroXpaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnfermeroXpacienteExists(enfermeroXpaciente.Id))
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
            ViewData["IdEnfermero"] = new SelectList(_context.Enfermeros, "Id", "Documento", enfermeroXpaciente.IdEnfermero);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Documento", enfermeroXpaciente.IdPaciente);
            return View(enfermeroXpaciente);
        }

        // GET: EnfermeroXpaciente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermeroXpaciente = await _context.EnfermeroXpacientes
                .Include(e => e.IdEnfermeroNavigation)
                .Include(e => e.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enfermeroXpaciente == null)
            {
                return NotFound();
            }

            return View(enfermeroXpaciente);
        }

        // POST: EnfermeroXpaciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enfermeroXpaciente = await _context.EnfermeroXpacientes.FindAsync(id);
            _context.EnfermeroXpacientes.Remove(enfermeroXpaciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnfermeroXpacienteExists(int id)
        {
            return _context.EnfermeroXpacientes.Any(e => e.Id == id);
        }
    }
}
