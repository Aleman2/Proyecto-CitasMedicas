using System.ComponentModel.DataAnnotations;

namespace Prueba.DTO
{
    public class DiagnosticoConexDTO
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "La valoracion es requerida")]
        public string ValoracionEspecialista { get; set; }
        [Required(ErrorMessage = "La enfermedad es requerida")]
        public string Enfermedad { get; set; }
    }
}
