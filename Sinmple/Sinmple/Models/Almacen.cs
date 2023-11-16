using System.ComponentModel.DataAnnotations;

namespace Sinmple.Models
{
    public class Almacen
    {
        [Key]
        public int Id_almacen { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres")]
        public string Nombre { get; set; }

        [MaxLength(100, ErrorMessage = "El campo Ubicacion no puede tener más de 100 caracteres")]
        public string Ubicacion { get; set; }
    }
}
