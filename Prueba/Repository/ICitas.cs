using Prueba.Entity;

namespace Prueba.Repository
{
    public interface ICitas
    {

        Task<List<Cita>> GetAll();

        Task<Cita> Update(Cita cita);

        Task<Cita> Add(Cita cita);

        Task<Cita> GetById(long id);


        Task<Cita> GetByMedId(long id);
        Task<Cita> GetByPacId(long id);

        Task<Cita> DeleteById(long id);

    }
}
