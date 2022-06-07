using Prueba.Repository;
using Prueba.Entity;

namespace Prueba.Service
{
    public interface IUsuarioService
    {
        public IList<Usuario> FindAll();

        public Usuario FindById(long id);

        public Usuario Insert(Usuario usuario);


        public Usuario Update(Usuario usuario);

        public Usuario Search(string usuario, string clave);

        public bool DeleteById(long id);
    }
}
