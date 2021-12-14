using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnet.Models.DB;

namespace dotnet.Controllers.Parameters
{
    public class CuentumController : Controller
    {
        private readonly TrijuantaBDContext _context;

        public CuentumController(TrijuantaBDContext context)
        {
            _context = context;
        }

        // GET: Cuentum
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cuenta.ToListAsync());
        }

        // GET: Cuentum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentum = await _context.Cuenta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuentum == null)
            {
                return NotFound();
            }

            return View(cuentum);
        }

        // GET: Cuentum/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cuentum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rol,Usuario,Contrasena")] Cuentum cuentum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuentum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuentum);
        }

        // GET: Cuentum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentum = await _context.Cuenta.FindAsync(id);
            if (cuentum == null)
            {
                return NotFound();
            }
            return View(cuentum);
        }

        // POST: Cuentum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rol,Usuario,Contrasena")] Cuentum cuentum)
        {
            if (id != cuentum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuentum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuentumExists(cuentum.Id))
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
            return View(cuentum);
        }

        // GET: Cuentum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentum = await _context.Cuenta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuentum == null)
            {
                return NotFound();
            }

            return View(cuentum);
        }

        // POST: Cuentum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuentum = await _context.Cuenta.FindAsync(id);
            _context.Cuenta.Remove(cuentum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuentumExists(int id)
        {
            return _context.Cuenta.Any(e => e.Id == id);
        }
    }
}
