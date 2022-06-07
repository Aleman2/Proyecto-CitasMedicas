using System.ComponentModel.DataAnnotations;

namespace Prueba.DTO
{
    public class CitaConexDTO
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime FechaHora { get; set; }
        [Required(ErrorMessage = "El motivo es requerido")]
        public string MotivoCita { get; set; }
        public long MedicoId { get; set; }
        public long PacienteId { get; set; }


    }
}
