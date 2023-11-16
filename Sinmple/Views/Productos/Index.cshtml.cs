using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sinmple.Data;
using Sinmple.Models;

namespace Sinmple.Views.Productos
{
    public class IndexModel : PageModel
    {
        private readonly Sinmple.Data.SinmpleContext _context;

        public IndexModel(Sinmple.Data.SinmpleContext context)
        {
            _context = context;
        }

        public IList<Producto> Producto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Producto != null)
            {
                Producto = await _context.Producto.ToListAsync();
            }
        }
    }
}
