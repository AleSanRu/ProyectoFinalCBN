using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sinmple.Data;
using Sinmple.Models;

namespace Sinmple.Views.Almacenes
{
    public class DeleteModel : PageModel
    {
        private readonly Sinmple.Data.SinmpleContext _context;

        public DeleteModel(Sinmple.Data.SinmpleContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Almacen Almacen { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Almacen == null)
            {
                return NotFound();
            }

            var almacen = await _context.Almacen.FirstOrDefaultAsync(m => m.Id_almacen == id);

            if (almacen == null)
            {
                return NotFound();
            }
            else 
            {
                Almacen = almacen;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Almacen == null)
            {
                return NotFound();
            }
            var almacen = await _context.Almacen.FindAsync(id);

            if (almacen != null)
            {
                Almacen = almacen;
                _context.Almacen.Remove(Almacen);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
