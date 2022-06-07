
using System.ComponentModel.DataAnnotations;

namespace Prueba.Entity
{
    public class Medicos : Usuario

    {

        [Required]
        [MaxLength(16)]
        public string NumColegiado { get; set; }

        //Struc.
        public Medicos(string nombre, string apellidos, string user, string clave, string numColegiado) : base(nombre, apellidos, user, clave)
        {
            NumColegiado = numColegiado;
        }

        //Navegar por las uniones de tablas este caso muchas a muchas
        public virtual IList<Cita> Citas { get; set; } = new List<Cita>();
        public virtual IList<Paciente> Pacientes { get; set; } = new List<Paciente>();

    }
}
