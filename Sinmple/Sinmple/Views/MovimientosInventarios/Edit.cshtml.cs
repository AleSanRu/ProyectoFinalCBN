using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sinmple.Data;
using Sinmple.Models;

namespace Sinmple.Views.MovimientosInventarios
{
    public class EditModel : PageModel
    {
        private readonly Sinmple.Data.SinmpleContext _context;

        public EditModel(Sinmple.Data.SinmpleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MovimientosInventario MovimientosInventario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MovimientosInventario == null)
            {
                return NotFound();
            }

            var movimientosinventario =  await _context.MovimientosInventario.FirstOrDefaultAsync(m => m.Id_movimiento == id);
            if (movimientosinventario == null)
            {
                return NotFound();
            }
            MovimientosInventario = movimientosinventario;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MovimientosInventario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientosInventarioExists(MovimientosInventario.Id_movimiento))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovimientosInventarioExists(int id)
        {
          return (_context.MovimientosInventario?.Any(e => e.Id_movimiento == id)).GetValueOrDefault();
        }
    }
}
