using System.ComponentModel.DataAnnotations;

namespace Prueba.DTO
{
    public class MedicosDTO : UsuarioDTO
    {

        [Required(ErrorMessage = "El NumColegiado es requerido")]
        public string NumColegiado { get; set; }

        public virtual IList<CitaConexDTO> Citas { get; set; } = new List<CitaConexDTO>();
        public virtual IList<PacienteConexDTO> Pacientes { get; set; } = new List<PacienteConexDTO>();
    }
}
