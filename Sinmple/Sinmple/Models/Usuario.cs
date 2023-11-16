using System.ComponentModel.DataAnnotations;

namespace Sinmple.Models
{
    public class Usuario
    {
        [Key]
        public int Id_usuario { get; set; }

        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres")]
        public string Nombre { get; set; }

        [MaxLength(50, ErrorMessage = "El campo Apellido no puede tener más de 50 caracteres")]
        public string Apellido { get; set; }

        [EmailAddress(ErrorMessage = "El campo Correo debe ser una dirección de correo electrónico válida")]
        public string Correo { get; set; }

        [MaxLength(100, ErrorMessage = "El campo Direccion no puede tener más de 100 caracteres")]
        public string Direccion { get; set; }

        public string Roles { get; set; }
    }
}
