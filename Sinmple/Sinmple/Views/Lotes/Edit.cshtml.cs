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

namespace Sinmple.Views.Lotes
{
    public class EditModel : PageModel
    {
        private readonly Sinmple.Data.SinmpleContext _context;

        public EditModel(Sinmple.Data.SinmpleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lote Lote { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Lote == null)
            {
                return NotFound();
            }

            var lote =  await _context.Lote.FirstOrDefaultAsync(m => m.Id_lote == id);
            if (lote == null)
            {
                return NotFound();
            }
            Lote = lote;
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

            _context.Attach(Lote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoteExists(Lote.Id_lote))
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

        private bool LoteExists(int id)
        {
          return (_context.Lote?.Any(e => e.Id_lote == id)).GetValueOrDefault();
        }
    }
}
