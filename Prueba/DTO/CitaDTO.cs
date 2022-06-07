using System.ComponentModel.DataAnnotations;

namespace Prueba.DTO
{
    public class CitaDTO
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime FechaHora { get; set; }
        [Required(ErrorMessage = "El motivo es requerido")]
        public string MotivoCita { get; set; }

        public virtual DiagnosticoConexDTO? Diagnostico { get; set; }
        public virtual MedicosConexDTO Medico { get; set; }
        public virtual PacienteConexDTO Paciente { get; set; }
    }
}
