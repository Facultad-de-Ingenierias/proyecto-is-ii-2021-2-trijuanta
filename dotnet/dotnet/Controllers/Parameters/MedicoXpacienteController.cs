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
    public class MedicoXpacienteController : Controller
    {
        private readonly TrijuantaBDContext _context;

        public MedicoXpacienteController(TrijuantaBDContext context)
        {
            _context = context;
        }

        // GET: MedicoXpaciente
        public async Task<IActionResult> Index()
        {
            var trijuantaBDContext = _context.MedicoXpacientes.Include(m => m.IdMedicoNavigation).Include(m => m.IdPacienteNavigation);
            return View(await trijuantaBDContext.ToListAsync());
        }

        // GET: MedicoXpaciente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicoXpaciente = await _context.MedicoXpacientes
                .Include(m => m.IdMedicoNavigation)
                .Include(m => m.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicoXpaciente == null)
            {
                return NotFound();
            }

            return View(medicoXpaciente);
        }

        // GET: MedicoXpaciente/Create
        public IActionResult Create()
        {
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "Id", "Celular");
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Celular");
            return View();
        }

        // POST: MedicoXpaciente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaInicio,FechaFin,IdMedico,IdPaciente")] MedicoXpaciente medicoXpaciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicoXpaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "Id", "Celular", medicoXpaciente.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Celular", medicoXpaciente.IdPaciente);
            return View(medicoXpaciente);
        }

        // GET: MedicoXpaciente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicoXpaciente = await _context.MedicoXpacientes.FindAsync(id);
            if (medicoXpaciente == null)
            {
                return NotFound();
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "Id", "Celular", medicoXpaciente.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Celular", medicoXpaciente.IdPaciente);
            return View(medicoXpaciente);
        }

        // POST: MedicoXpaciente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaInicio,FechaFin,IdMedico,IdPaciente")] MedicoXpaciente medicoXpaciente)
        {
            if (id != medicoXpaciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicoXpaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicoXpacienteExists(medicoXpaciente.Id))
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
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "Id", "Celular", medicoXpaciente.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Celular", medicoXpaciente.IdPaciente);
            return View(medicoXpaciente);
        }

        // GET: MedicoXpaciente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicoXpaciente = await _context.MedicoXpacientes
                .Include(m => m.IdMedicoNavigation)
                .Include(m => m.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicoXpaciente == null)
            {
                return NotFound();
            }

            return View(medicoXpaciente);
        }

        // POST: MedicoXpaciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicoXpaciente = await _context.MedicoXpacientes.FindAsync(id);
            _context.MedicoXpacientes.Remove(medicoXpaciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicoXpacienteExists(int id)
        {
            return _context.MedicoXpacientes.Any(e => e.Id == id);
        }
    }
}
