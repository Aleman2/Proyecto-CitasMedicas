using Prueba.Entity;
using Prueba.Repository.Imp;

namespace Prueba.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
       private readonly DataConte dataconte;

        public UsuarioRepository(DataConte dataconte)
        {
            this.dataconte = dataconte;
        }

        public async Task<Usuario> Add(Usuario usuario)
        {
           var result = await dataconte.UsuarioDB.AddAsync(usuario);
            await dataconte.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Usuario> DeleteById(long id)
        {
            var result =  dataconte.UsuarioDB.FirstOrDefault(e => e.Id == id);
            if (result != null)
            {
                dataconte.UsuarioDB.Remove(result);
                await dataconte.SaveChangesAsync();
                return result;

            }

            return null;
        }

        public async Task<List<Usuario>> GetAll()
        {
            return  dataconte.UsuarioDB.ToList();        }

        public async Task<Usuario> GetById(long id)
        {
            return await dataconte.Set<Usuario>().FindAsync(id);
        }

        public async Task<Usuario> Search(string usuario, string clave)
        {
           

            return dataconte.UsuarioDB.FirstOrDefault(e=> e.User == usuario && e.Clave == clave);
        }
    

        public Task<Usuario> Update(Usuario usuario)
        {
            var result = dataconte.UsuarioDB.FirstOrDefault(e => e.Id == usuario.Id);
            if (result != null)
            {
                dataconte.UsuarioDB.Update(result);
                 dataconte.SaveChangesAsync();

            }

            return null;
        }
    }
}
