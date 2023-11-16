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

namespace Sinmple.Views.Almacenes
{
    public class EditModel : PageModel
    {
        private readonly Sinmple.Data.SinmpleContext _context;

        public EditModel(Sinmple.Data.SinmpleContext context)
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

            var almacen =  await _context.Almacen.FirstOrDefaultAsync(m => m.Id_almacen == id);
            if (almacen == null)
            {
                return NotFound();
            }
            Almacen = almacen;
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

            _context.Attach(Almacen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlmacenExists(Almacen.Id_almacen))
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

        private bool AlmacenExists(int id)
        {
          return (_context.Almacen?.Any(e => e.Id_almacen == id)).GetValueOrDefault();
        }
    }
}
