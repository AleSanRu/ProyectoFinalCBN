using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sinmple.Models
{
    public class Lote
    {
        [Key]
        public int Id_lote { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Nombre_lote no puede tener más de 50 caracteres")]
        public string Nombre_lote { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaElaboracion { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaVencimiento { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo Id_almacen debe ser un número entero")]
        public int Cantidad { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo Cantidad debe ser un número entero")]
        public int Productos_id { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo Cantidad debe ser un número entero")]
        public int Almacen_id { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo Cantidad debe ser un número entero")]
        public int usuario_id { get; set; }
    }
}
