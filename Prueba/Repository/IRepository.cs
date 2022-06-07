using Prueba.Entity;

namespace Prueba.Repository
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {

        Task<List<TEntity>> GetAll();

        Task<TEntity> Update(TEntity entity);

        Task<TEntity> Add(TEntity entity);

        Task<TEntity> GetById(long id);

        Task<TEntity> DeleteById(long id);

    }
}
