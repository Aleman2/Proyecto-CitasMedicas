using System.ComponentModel.DataAnnotations;

namespace Prueba.DTO
{
    public class PacienteDTO : UsuarioDTO
    {

        [Required(ErrorMessage = "El NSS es requerido")]
        public string NSS { get; set; }
        [Required(ErrorMessage = "El numero de tarjeta requerido")]
        public string NumTarjeta { get; set; }
        [Required(ErrorMessage = "El telefono es requerido")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "La dirección es requerida")]
        public string Direccion { get; set; }

        public virtual IList<MedicosConexDTO> Medicos { get; set; } = new List<MedicosConexDTO>();

        public virtual IList<CitaConexDTO> Citas { get; set; } = new List<CitaConexDTO>();

    }
}
