using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sinmple.Data;
using Sinmple.Models;

namespace Sinmple.Controllers
{
    public class AlmacenesController : Controller
    {
        private readonly SinmpleContext _context;

        public AlmacenesController(SinmpleContext context)
        {
            _context = context;
        }

        // GET: Almacenes
        public async Task<IActionResult> Index()
        {
              return _context.Almacen != null ? 
                          View(await _context.Almacen.ToListAsync()) :
                          Problem("Entity set 'SinmpleContext.Almacen'  is null.");
        }

        // GET: Almacenes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Almacen == null)
            {
                return NotFound();
            }

            var almacen = await _context.Almacen
                .FirstOrDefaultAsync(m => m.Id_almacen == id);
            if (almacen == null)
            {
                return NotFound();
            }

            return View(almacen);
        }

        // GET: Almacenes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Almacenes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_almacen,Nombre,Ubicacion")] Almacen almacen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(almacen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(almacen);
        }

        // GET: Almacenes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Almacen == null)
            {
                return NotFound();
            }

            var almacen = await _context.Almacen.FindAsync(id);
            if (almacen == null)
            {
                return NotFound();
            }
            return View(almacen);
        }

        // POST: Almacenes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_almacen,Nombre,Ubicacion")] Almacen almacen)
        {
            if (id != almacen.Id_almacen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(almacen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlmacenExists(almacen.Id_almacen))
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
            return View(almacen);
        }

        // GET: Almacenes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Almacen == null)
            {
                return NotFound();
            }

            var almacen = await _context.Almacen
                .FirstOrDefaultAsync(m => m.Id_almacen == id);
            if (almacen == null)
            {
                return NotFound();
            }

            return View(almacen);
        }

        // POST: Almacenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Almacen == null)
            {
                return Problem("Entity set 'SinmpleContext.Almacen'  is null.");
            }
            var almacen = await _context.Almacen.FindAsync(id);
            if (almacen != null)
            {
                _context.Almacen.Remove(almacen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlmacenExists(int id)
        {
          return (_context.Almacen?.Any(e => e.Id_almacen == id)).GetValueOrDefault();
        }
    }
}
