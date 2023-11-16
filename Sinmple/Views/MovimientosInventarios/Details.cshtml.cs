using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sinmple.Data;
using Sinmple.Models;

namespace Sinmple.Views.MovimientosInventarios
{
    public class DetailsModel : PageModel
    {
        private readonly Sinmple.Data.SinmpleContext _context;

        public DetailsModel(Sinmple.Data.SinmpleContext context)
        {
            _context = context;
        }

      public MovimientosInventario MovimientosInventario { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MovimientosInventario == null)
            {
                return NotFound();
            }

            var movimientosinventario = await _context.MovimientosInventario.FirstOrDefaultAsync(m => m.Id_movimiento == id);
            if (movimientosinventario == null)
            {
                return NotFound();
            }
            else 
            {
                MovimientosInventario = movimientosinventario;
            }
            return Page();
        }
    }
}
