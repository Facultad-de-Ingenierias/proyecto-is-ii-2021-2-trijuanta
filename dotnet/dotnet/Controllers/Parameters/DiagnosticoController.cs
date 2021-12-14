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
    public class DiagnosticoController : Controller
    {
        private readonly TrijuantaBDContext _context;

        public DiagnosticoController(TrijuantaBDContext context)
        {
            _context = context;
        }

        // GET: Diagnostico
        public async Task<IActionResult> Index(int? id)
        {
           


            var trijuantaBDContext = from m in _context.Diagnosticos select m;  

            if (!String.IsNullOrEmpty(id.ToString()))
            {
                trijuantaBDContext = trijuantaBDContext.Where(s => s.Id == id);
            }


            if (trijuantaBDContext == null)
            {
                return NotFound();
            }

            return View(await trijuantaBDContext.ToListAsync());
        }

        // GET: Diagnostico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
     

            var diagnostico = await _context.Diagnosticos
                .Include(d => d.IdMedicoNavigation)
                .Include(d => d.IdPacienteNavigation)
                .Include(d => d.IdSignosVitalesNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
       

            return View(diagnostico);
        }

        // GET: Diagnostico/Create
        public IActionResult Create()
        {
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "Id", "Documento");
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Documento");
            ViewData["IdSignosVitales"] = new SelectList(_context.SignosVitales, "Id", "Id");
            return View();
        }

        // POST: Diagnostico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sugerencia,Antecedentes,SaludSexual,Fecha,IdPaciente,IdMedico,IdSignosVitales")] Diagnostico diagnostico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diagnostico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "Id", "Documento", diagnostico.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Documento", diagnostico.IdPaciente);
            ViewData["IdSignosVitales"] = new SelectList(_context.SignosVitales, "Id", "Id", diagnostico.IdSignosVitales);
            return View(diagnostico);
        }

        // GET: Diagnostico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnostico = await _context.Diagnosticos.FindAsync(id);
            if (diagnostico == null)
            {
                return NotFound();
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "Id", "Documento", diagnostico.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Documento", diagnostico.IdPaciente);
            ViewData["IdSignosVitales"] = new SelectList(_context.SignosVitales, "Id", "Id", diagnostico.IdSignosVitales);
            return View(diagnostico);
        }

        // POST: Diagnostico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sugerencia,Antecedentes,SaludSexual,Fecha,IdPaciente,IdMedico,IdSignosVitales")] Diagnostico diagnostico)
        {
            if (id != diagnostico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diagnostico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiagnosticoExists(diagnostico.Id))
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
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "Id", "Documento", diagnostico.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Documento", diagnostico.IdPaciente);
            ViewData["IdSignosVitales"] = new SelectList(_context.SignosVitales, "Id", "Id", diagnostico.IdSignosVitales);
            return View(diagnostico);
        }

        // GET: Diagnostico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnostico = await _context.Diagnosticos
                .Include(d => d.IdMedicoNavigation)
                .Include(d => d.IdPacienteNavigation)
                .Include(d => d.IdSignosVitalesNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diagnostico == null)
            {
                return NotFound();
            }

            return View(diagnostico);
        }

        // POST: Diagnostico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diagnostico = await _context.Diagnosticos.FindAsync(id);
            _context.Diagnosticos.Remove(diagnostico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiagnosticoExists(int id)
        {
            return _context.Diagnosticos.Any(e => e.Id == id);
        }
    }
}
