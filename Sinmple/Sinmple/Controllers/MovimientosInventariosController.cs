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
    public class MovimientosInventariosController : Controller
    {
        private readonly SinmpleContext _context;

        public MovimientosInventariosController(SinmpleContext context)
        {
            _context = context;
        }

        // GET: MovimientosInventarios
        public async Task<IActionResult> Index()
        {
              return _context.MovimientosInventario != null ? 
                          View(await _context.MovimientosInventario.ToListAsync()) :
                          Problem("Entity set 'SinmpleContext.MovimientosInventario'  is null.");
        }

        // GET: MovimientosInventarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MovimientosInventario == null)
            {
                return NotFound();
            }

            var movimientosInventario = await _context.MovimientosInventario
                .FirstOrDefaultAsync(m => m.Id_movimiento == id);
            if (movimientosInventario == null)
            {
                return NotFound();
            }

            return View(movimientosInventario);
        }

        // GET: MovimientosInventarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovimientosInventarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_movimiento,Cantidad,TipoMovimiento,Fecha,id_lote")] MovimientosInventario movimientosInventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimientosInventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movimientosInventario);
        }

        // GET: MovimientosInventarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MovimientosInventario == null)
            {
                return NotFound();
            }

            var movimientosInventario = await _context.MovimientosInventario.FindAsync(id);
            if (movimientosInventario == null)
            {
                return NotFound();
            }
            return View(movimientosInventario);
        }

        // POST: MovimientosInventarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_movimiento,Cantidad,TipoMovimiento,Fecha,id_lote")] MovimientosInventario movimientosInventario)
        {
            if (id != movimientosInventario.Id_movimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimientosInventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientosInventarioExists(movimientosInventario.Id_movimiento))
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
            return View(movimientosInventario);
        }

        // GET: MovimientosInventarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MovimientosInventario == null)
            {
                return NotFound();
            }

            var movimientosInventario = await _context.MovimientosInventario
                .FirstOrDefaultAsync(m => m.Id_movimiento == id);
            if (movimientosInventario == null)
            {
                return NotFound();
            }

            return View(movimientosInventario);
        }

        // POST: MovimientosInventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MovimientosInventario == null)
            {
                return Problem("Entity set 'SinmpleContext.MovimientosInventario'  is null.");
            }
            var movimientosInventario = await _context.MovimientosInventario.FindAsync(id);
            if (movimientosInventario != null)
            {
                _context.MovimientosInventario.Remove(movimientosInventario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientosInventarioExists(int id)
        {
          return (_context.MovimientosInventario?.Any(e => e.Id_movimiento == id)).GetValueOrDefault();
        }
    }
}
