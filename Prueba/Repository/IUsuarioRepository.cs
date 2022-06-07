using Prueba.Entity;

namespace Prueba.Repository
{
    public interface IUsuarioRepository
    {
    
        Task<Usuario> Search(string usuario, string clave);
            Task<List<Usuario>> GetAll();

            Task<Usuario> Update(Usuario usuario);

            Task<Usuario> Add(Usuario usuario);

            Task<Usuario> GetById(long id);

            Task<Usuario> DeleteById(long id);

    }
}
