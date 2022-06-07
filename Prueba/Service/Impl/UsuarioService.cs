using Prueba.Entity;
using Prueba.Repository;
using Prueba.Service;

namespace Prueba.Service.Impl
{
    public class UsuarioService : IUsuarioService
    {
        UsuarioRepository UsuarioRepository;

        public UsuarioService(UsuarioRepository usuRepository)
        {
            UsuarioRepository = usuRepository;
        }

        public bool DeleteById(long id)
        {
            var ret = UsuarioRepository.DeleteById(id).Result;
            if (ret == null) return false;
            return true;
        }

        public IList<Usuario> FindAll()
        {
            return UsuarioRepository.GetAll().Result;
        }

        public Usuario FindById(long id)
        {
            return UsuarioRepository.GetById(id).Result;
        }

        public Usuario Search(string usuario, string clave)
        {
            return UsuarioRepository.Search(usuario, clave).Result;
        }

        public Usuario Insert(Usuario usuario)
        {
            Usuario usuarioUp = UsuarioRepository.Add(usuario).Result;
            return usuarioUp;
        }

        public Usuario Update(Usuario usuario)
        {
            Usuario usuarioUp = UsuarioRepository.Update(usuario).Result;
            return usuarioUp;
        }
    }
}
