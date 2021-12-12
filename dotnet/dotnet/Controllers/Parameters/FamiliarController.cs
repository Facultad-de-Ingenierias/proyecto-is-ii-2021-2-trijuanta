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
    public class FamiliarController : Controller
    {
        private readonly TrijuantaBDContext _context;

        public FamiliarController(TrijuantaBDContext context)
        {
            _context = context;
        }

        // GET: Familiar
        public async Task<IActionResult> Index()
        {
            var trijuantaBDContext = _context.Familiars.Include(f => f.IdCuentaNavigation);
            return View(await trijuantaBDContext.ToListAsync());
        }

        // GET: Familiar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiar = await _context.Familiars
                .Include(f => f.IdCuentaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familiar == null)
            {
                return NotFound();
            }

            return View(familiar);
        }

        // GET: Familiar/Create
        public IActionResult Create()
        {
            ViewData["IdCuenta"] = new SelectList(_context.Cuenta, "Id", "Contrasena");
            return View();
        }

        // POST: Familiar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoDocumento,Documento,Nombres,Apellidos,Sexo,Celular,Correo,IdCuenta")] Familiar familiar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familiar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCuenta"] = new SelectList(_context.Cuenta, "Id", "Contrasena", familiar.IdCuenta);
            return View(familiar);
        }

        // GET: Familiar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiar = await _context.Familiars.FindAsync(id);
            if (familiar == null)
            {
                return NotFound();
            }
            ViewData["IdCuenta"] = new SelectList(_context.Cuenta, "Id", "Contrasena", familiar.IdCuenta);
            return View(familiar);
        }

        // POST: Familiar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoDocumento,Documento,Nombres,Apellidos,Sexo,Celular,Correo,IdCuenta")] Familiar familiar)
        {
            if (id != familiar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familiar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliarExists(familiar.Id))
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
            ViewData["IdCuenta"] = new SelectList(_context.Cuenta, "Id", "Contrasena", familiar.IdCuenta);
            return View(familiar);
        }

        // GET: Familiar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiar = await _context.Familiars
                .Include(f => f.IdCuentaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familiar == null)
            {
                return NotFound();
            }

            return View(familiar);
        }

        // POST: Familiar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familiar = await _context.Familiars.FindAsync(id);
            _context.Familiars.Remove(familiar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamiliarExists(int id)
        {
            return _context.Familiars.Any(e => e.Id == id);
        }
    }
}
