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

namespace Sinmple.Views.Usuarios
{
    public class EditModel : PageModel
    {
        private readonly Sinmple.Data.SinmpleContext _context;

        public EditModel(Sinmple.Data.SinmpleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario =  await _context.Usuario.FirstOrDefaultAsync(m => m.Id_usuario == id);
            if (usuario == null)
            {
                return NotFound();
            }
            Usuario = usuario;
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

            _context.Attach(Usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(Usuario.Id_usuario))
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

        private bool UsuarioExists(int id)
        {
          return (_context.Usuario?.Any(e => e.Id_usuario == id)).GetValueOrDefault();
        }
    }
}
