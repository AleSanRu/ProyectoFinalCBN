using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sinmple.Data;
using Sinmple.Models;

namespace Sinmple.Views.Lotes
{
    public class DeleteModel : PageModel
    {
        private readonly Sinmple.Data.SinmpleContext _context;

        public DeleteModel(Sinmple.Data.SinmpleContext context)
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

            var lote = await _context.Lote.FirstOrDefaultAsync(m => m.Id_lote == id);

            if (lote == null)
            {
                return NotFound();
            }
            else 
            {
                Lote = lote;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Lote == null)
            {
                return NotFound();
            }
            var lote = await _context.Lote.FindAsync(id);

            if (lote != null)
            {
                Lote = lote;
                _context.Lote.Remove(Lote);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
