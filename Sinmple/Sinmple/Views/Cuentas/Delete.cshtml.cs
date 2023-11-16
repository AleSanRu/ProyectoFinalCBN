using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sinmple.Data;
using Sinmple.Models;

namespace Sinmple.Views.Cuentas
{
    public class DeleteModel : PageModel
    {
        private readonly Sinmple.Data.SinmpleContext _context;

        public DeleteModel(Sinmple.Data.SinmpleContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Cuenta Cuenta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cuenta == null)
            {
                return NotFound();
            }

            var cuenta = await _context.Cuenta.FirstOrDefaultAsync(m => m.Id_cuenta == id);

            if (cuenta == null)
            {
                return NotFound();
            }
            else 
            {
                Cuenta = cuenta;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cuenta == null)
            {
                return NotFound();
            }
            var cuenta = await _context.Cuenta.FindAsync(id);

            if (cuenta != null)
            {
                Cuenta = cuenta;
                _context.Cuenta.Remove(Cuenta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
