
using System.ComponentModel.DataAnnotations;

namespace Prueba.Entity
{
    public class Paciente : Usuario
    {
        [Required]
        public string Nss { get; set; }
        [Required]
        [MaxLength(16)]
        public string NumTarjeta { get; set; }
        [Required]
        [MaxLength(16)]
        public string Telefono { get; set; }
        [MaxLength(30)]
        public string Direccion { get; set; }



        //Struc.
        public Paciente(string nombre, string apellidos, string user, string clave, string nss, string numTarjeta, string telefono, string direccion) : base(nombre, apellidos, user, clave)
        {
            Nss = nss;
            NumTarjeta = numTarjeta;
            Telefono = telefono;
            Direccion = direccion;
        }

        //Navegar por las uniones de tablas este caso muchas a muchas
        public virtual IList<Medicos> Medicos { get; set; } = new List<Medicos>();

        public virtual IList<Cita> Citas { get; set; } = new List<Cita>();


    }
}
