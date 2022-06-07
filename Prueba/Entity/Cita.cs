using System.ComponentModel.DataAnnotations;

namespace Prueba.Entity
{
    public class Cita : IEntity
    {
        //Usamos la propiedad de entidad Key para definir la propiedad principal, required para que sea 
        //requerido el dato y el max lenght para añadir seguridad en la base de datos aunque en esta ya tenga 
        //nvarchar(25) por ejemplo
        [Key]
        public long Id { get; set; }

        public DateTime FechaHora { get; set; }

        public string MotivoCita { get; set; }

        //Ctors.
        public Cita(DateTime fechaHora,  long medicoId, string motivoCita, long pacienteId)
        {
            FechaHora = fechaHora;
            MedicoId = medicoId;
            MotivoCita = motivoCita;
            PacienteId = pacienteId;
  
        }
        //Navegar por las uniones de tablas este caso una a una y en diagnostico una a cero o una

        public virtual Diagnostico Diagnostico { get; set; }
        public virtual long? DiagnosticoId { get; set; }

        public virtual Medicos Medico { get; set; }
        public virtual long MedicoId { get; set; }

        public virtual Paciente Paciente { get; set; }
        public virtual long PacienteId { get; set; }
    }
}
