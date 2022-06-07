using System.ComponentModel.DataAnnotations;

namespace Prueba.Entity
{
    public class Diagnostico : IEntity
    {
        //Usamos la propiedad de entidad Key para definir la propiedad principal, required para que sea 
        //requerido el dato y el max lenght para añadir seguridad en la base de datos aunque en esta ya tenga 
        //nvarchar(25) por ejemplo

        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string ValoracionEspecialista { get; set; }
        [Required]
        [MaxLength(55)]
        public string Enfermedad { get; set; }


        //Struc.
        public Diagnostico(string valoracionEspecialista, string enfermedad)
        {
            ValoracionEspecialista = valoracionEspecialista;
            Enfermedad = enfermedad;
        }

        //Navegar por las uniones de tablas este caso una a una
        public virtual Cita Cita { get; set; }
    }
}