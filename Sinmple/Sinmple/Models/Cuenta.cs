using System.ComponentModel.DataAnnotations;

namespace Sinmple.Models
{
    public class Cuenta
    {
        [Key]
        public int Id_cuenta { get; set; }
        public string Usuario { get; set; }

        public string Contraseña { get; set; }
    }
}
