using System.ComponentModel.DataAnnotations;

namespace Prueba.DTO
{
    public class UsuarioDTO
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(25)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Los apellidos son requeridos")]
        [MaxLength(55)]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El usuario es requerido")]
        [MaxLength(35)]
        public string User { get; set; }
        [Required(ErrorMessage = "La clave es requerida")]
        [MaxLength(20)]

        public string Clave  { get; set; }
    }
}
