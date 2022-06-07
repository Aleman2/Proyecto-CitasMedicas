using System.ComponentModel.DataAnnotations;

namespace Prueba.DTO
{
    public class MedicosConexDTO : UsuarioDTO
    {
        [Required(ErrorMessage = "El NumColegiado es requerido")]
        public string NumColegiado { get; set; }

    }
}
