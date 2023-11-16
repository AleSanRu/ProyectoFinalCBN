using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sinmple.Models;

namespace Sinmple.Data
{
    public class SinmpleContext : DbContext
    {
        public SinmpleContext (DbContextOptions<SinmpleContext> options)
            : base(options)
        {
        }

        public DbSet<Sinmple.Models.Almacen> Almacen { get; set; } = default!;

        public DbSet<Sinmple.Models.Cuenta>? Cuenta { get; set; }

        public DbSet<Sinmple.Models.Lote>? Lote { get; set; }

        public DbSet<Sinmple.Models.MovimientosInventario>? MovimientosInventario { get; set; }

        public DbSet<Sinmple.Models.Producto>? Producto { get; set; }

        public DbSet<Sinmple.Models.Usuario>? Usuario { get; set; }

        /*public Usuario ValidaUsuario(string correo, string clave)
        {
            return ListaUsuarios().Where(item => item.Correo == correo && item.Clave == clave).FirstOrDefault();
        }
        */
    }
}
