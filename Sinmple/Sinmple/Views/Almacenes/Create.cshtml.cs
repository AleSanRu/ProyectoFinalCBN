using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sinmple.Data;
using Sinmple.Models;

namespace Sinmple.Views.Almacenes
{
    public class CreateModel : PageModel
    {
        private readonly Sinmple.Data.SinmpleContext _context;

        public CreateModel(Sinmple.Data.SinmpleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Almacen Almacen { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Almacen == null || Almacen == null)
            {
                return Page();
            }

            _context.Almacen.Add(Almacen);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
