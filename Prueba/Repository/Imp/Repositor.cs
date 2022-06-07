
using Microsoft.EntityFrameworkCore;
using Prueba.Entity;
using Prueba.Repository;

namespace Prueba.Repository.Imp
//Recordatorio: Probar a declarar el contexto aqui directamente sin usar TContext
{
    public abstract class Repositor<TEntity, TC> : IRepository<TEntity> where TEntity: class, IEntity where TC: DbContext
    {
        private readonly TC context;
        /*Apuntes: Async es una funcion que devuelve una promesa, si esta funcion genera alguna excepcion
         * esta promesa se rechaza, await sirve para pausar la funcion y esperar la resolucion de la promesa*/
        public Repositor(TC context)
        {
            this.context = context;
        }
        public async Task<TEntity> DeleteById(long id)
        {
            {
                var entity = await context.Set<TEntity>().FindAsync(id);
                if (entity == null)
                {
                    return null;
                }
              
                

                    context.Set<TEntity>().Remove(entity);
                    await context.SaveChangesAsync();

                    return entity;
                
            }
        }
        //ToListAsync hace lo mismo que ToList pero asincrono, lo que produce que se pueda manejar subprocesos
        //al mismo tiempo, lo malo es que en cuestion individual por la sobrecarga es mas lento que la sincrona
        //Set<TEntity> Devuelve una instancia para obtener acceso a las entidades especificadas en el contexto
        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();

        }

        public async Task<TEntity> GetById(long id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        //SaveChangesAsync Guarda todos los cambios realizados en este contexto en la base de datos
        //Usando Await para que espere a que todo este bien antes de hacerlo
        public async Task<TEntity> Add(TEntity entity)
        {
            {
                context.Set<TEntity>().Add(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
        //Entry nos da acceso a la entidad y a poder realizar cambios en esta
        //Recordatorio: Intentar con DbSet.Attach(entity) solo actualizar las propiedades en concreto en vez de todas
        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
