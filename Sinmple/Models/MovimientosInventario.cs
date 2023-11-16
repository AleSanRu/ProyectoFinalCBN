using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sinmple.Models
{
    public class MovimientosInventario
    {
        [Key]
        public int Id_movimiento { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo Cantidad debe ser un número entero")]
        public int Cantidad { get; set; }

        public string TipoMovimiento { get; set; }

        public DateTime Fecha { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo Cantidad debe ser un número entero")]
        public int id_lote { get; set; }
    }
}
