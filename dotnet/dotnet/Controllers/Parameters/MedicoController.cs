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
    public class MedicoController : Controller
    {
        private readonly TrijuantaBDContext _context;

        public MedicoController(TrijuantaBDContext context)
        {
            _context = context;
        }

        // GET: Medico
        public async Task<IActionResult> Index()
        {
            var trijuantaBDContext = _context.Medicos.Include(m => m.IdCuentaNavigation).Include(m => m.IdEspecialidadNavigation);
            return View(await trijuantaBDContext.ToListAsync());
        }

        // GET: Medico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos
                .Include(m => m.IdCuentaNavigation)
                .Include(m => m.IdEspecialidadNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // GET: Medico/Create
        public IActionResult Create()
        {
            ViewData["IdCuenta"] = new SelectList(_context.Cuenta, "Id", "Contrasena");
            ViewData["IdEspecialidad"] = new SelectList(_context.Especialidads, "Id", "Nombre");
            return View();
        }

        // POST: Medico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoDocumento,Documento,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,FechaNacimiento,Sexo,Celular,Correo,PathImagen,TarjetaProf,IdEspecialidad,IdCuenta")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCuenta"] = new SelectList(_context.Cuenta, "Id", "Contrasena", medico.IdCuenta);
            ViewData["IdEspecialidad"] = new SelectList(_context.Especialidads, "Id", "Nombre", medico.IdEspecialidad);
            return View(medico);
        }

        // GET: Medico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }
            ViewData["IdCuenta"] = new SelectList(_context.Cuenta, "Id", "Contrasena", medico.IdCuenta);
            ViewData["IdEspecialidad"] = new SelectList(_context.Especialidads, "Id", "Nombre", medico.IdEspecialidad);
            return View(medico);
        }

        // POST: Medico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoDocumento,Documento,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,FechaNacimiento,Sexo,Celular,Correo,PathImagen,TarjetaProf,IdEspecialidad,IdCuenta")] Medico medico)
        {
            if (id != medico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicoExists(medico.Id))
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
            ViewData["IdCuenta"] = new SelectList(_context.Cuenta, "Id", "Contrasena", medico.IdCuenta);
            ViewData["IdEspecialidad"] = new SelectList(_context.Especialidads, "Id", "Nombre", medico.IdEspecialidad);
            return View(medico);
        }

        // GET: Medico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos
                .Include(m => m.IdCuentaNavigation)
                .Include(m => m.IdEspecialidadNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // POST: Medico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);
            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicoExists(int id)
        {
            return _context.Medicos.Any(e => e.Id == id);
        }
    }
}
