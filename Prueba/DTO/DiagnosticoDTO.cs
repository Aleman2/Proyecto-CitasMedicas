using System.ComponentModel.DataAnnotations;

namespace Prueba.DTO
{
    public class DiagnosticoDTO
    {
       

        public int Id { get; set; }
        [Required(ErrorMessage = "La enfermedad es requerida")]
        public string Enfermedad { get; set; }
        [Required(ErrorMessage = "La valoracion es requerida")]
        public string ValoracionEspecialista { get; set; }

        public virtual CitaConexDTO Cita { get; set; }

    }
}
