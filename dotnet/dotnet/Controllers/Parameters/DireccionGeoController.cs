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
    public class DireccionGeoController : Controller
    {
        private readonly TrijuantaBDContext _context;

        public DireccionGeoController(TrijuantaBDContext context)
        {
            _context = context;
        }

        // GET: DireccionGeo
        public async Task<IActionResult> Index()
        {
            return View(await _context.DireccionGeos.ToListAsync());
        }

        // GET: DireccionGeo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionGeo = await _context.DireccionGeos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccionGeo == null)
            {
                return NotFound();
            }

            return View(direccionGeo);
        }

        // GET: DireccionGeo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DireccionGeo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Direccion,Latitud,Longitud")] DireccionGeo direccionGeo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direccionGeo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(direccionGeo);
        }

        // GET: DireccionGeo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionGeo = await _context.DireccionGeos.FindAsync(id);
            if (direccionGeo == null)
            {
                return NotFound();
            }
            return View(direccionGeo);
        }

        // POST: DireccionGeo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Direccion,Latitud,Longitud")] DireccionGeo direccionGeo)
        {
            if (id != direccionGeo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direccionGeo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionGeoExists(direccionGeo.Id))
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
            return View(direccionGeo);
        }

        // GET: DireccionGeo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionGeo = await _context.DireccionGeos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccionGeo == null)
            {
                return NotFound();
            }

            return View(direccionGeo);
        }

        // POST: DireccionGeo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direccionGeo = await _context.DireccionGeos.FindAsync(id);
            _context.DireccionGeos.Remove(direccionGeo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionGeoExists(int id)
        {
            return _context.DireccionGeos.Any(e => e.Id == id);
        }
    }
}
