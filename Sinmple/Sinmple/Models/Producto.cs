using System.ComponentModel.DataAnnotations;

namespace Sinmple.Models
{
    public class Producto
    {
        [Key]
        public int Productos_id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres")]
        public string Nombre { get; set; }

        [MaxLength(50, ErrorMessage = "El campo tipo no puede tener más de 50 caracteres")]
        public string tipo { get; set; }
    }
}
