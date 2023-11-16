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

namespace Sinmple.Views.Cuentas
{
    public class EditModel : PageModel
    {
        private readonly Sinmple.Data.SinmpleContext _context;

        public EditModel(Sinmple.Data.SinmpleContext context)
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

            var cuenta =  await _context.Cuenta.FirstOrDefaultAsync(m => m.Id_cuenta == id);
            if (cuenta == null)
            {
                return NotFound();
            }
            Cuenta = cuenta;
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

            _context.Attach(Cuenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentaExists(Cuenta.Id_cuenta))
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

        private bool CuentaExists(int id)
        {
          return (_context.Cuenta?.Any(e => e.Id_cuenta == id)).GetValueOrDefault();
        }
    }
}
