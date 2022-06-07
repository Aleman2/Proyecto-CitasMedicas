using System.ComponentModel.DataAnnotations;

namespace Prueba.Entity
{
    public class Usuario : IEntity
    {
        //Usamos la propiedad de entidad Key para definir la propiedad principal, required para que sea 
        //requerido el dato y el max lenght para añadir seguridad en la base de datos aunque en esta ya tenga 
        //nvarchar(25) por ejemplo
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(55)]
        public string Apellidos { get; set; }
        [Required]
        [MaxLength(35)]
        public string User { get; set; }
        [Required]
        [MaxLength(20)]
        public string Clave { get; set; }

        //Struc.
        public Usuario(string nombre, string apellidos, string user, string clave)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            User = user;
            Clave = clave;
        }
    }
}
