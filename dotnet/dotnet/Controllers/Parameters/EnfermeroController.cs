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
    public class EnfermeroController : Controller
    {
        private readonly TrijuantaBDContext _context;

        public EnfermeroController(TrijuantaBDContext context)
        { 
            _context = context;
        }

        // GET: Enfermero
        public async Task<IActionResult> Index()
        {
            var trijuantaBDContext = _context.Enfermeros.Include(e => e.IdCuentaNavigation);
            return View(await trijuantaBDContext.ToListAsync());
        }

        
        

        // GET: Enfermero/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermero = await _context.Enfermeros
                .Include(e => e.IdCuentaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enfermero == null)
            {
                return NotFound();
            }

            return View(enfermero);
        }

        // GET: Enfermero/Create
        public IActionResult Create()
        {

            ViewData["IdCuenta"] = new SelectList(_context.Cuenta, "Id", "Contrasena");
            return View();
        }

        // POST: Enfermero/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoDocumento,Documento,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,FechaNacimiento,Sexo,Celular,Correo,PathImagen,IdCuenta")] Enfermero enfermero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enfermero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdCuenta"] = new SelectList(_context.Cuenta, "Id", "Contrasena", enfermero.IdCuenta);
            return View(enfermero);
        }

        // GET: Enfermero/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermero = await _context.Enfermeros.FindAsync(id);
            if (enfermero == null)
            {
                return NotFound();
            }
            ViewData["IdCuenta"] = new SelectList(_context.Cuenta, "Id", "Contrasena", enfermero.IdCuenta);
            return View(enfermero);
        }

        // POST: Enfermero/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoDocumento,Documento,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,FechaNacimiento,Sexo,Celular,Correo,PathImagen,IdCuenta")] Enfermero enfermero)
        {
            if (id != enfermero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfermero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnfermeroExists(enfermero.Id))
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
            ViewData["IdCuenta"] = new SelectList(_context.Cuenta, "Id", "Contrasena", enfermero.IdCuenta);
            return View(enfermero);
        }

        // GET: Enfermero/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermero = await _context.Enfermeros
                .Include(e => e.IdCuentaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enfermero == null)
            {
                return NotFound();
            }

            return View(enfermero);
        }

        // POST: Enfermero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enfermero = await _context.Enfermeros.FindAsync(id);
            _context.Enfermeros.Remove(enfermero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnfermeroExists(int id)
        {
            return _context.Enfermeros.Any(e => e.Id == id);
        }
    }
}
