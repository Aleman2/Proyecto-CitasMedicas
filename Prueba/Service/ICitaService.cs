using Prueba.Repository;
using Prueba.Entity;

namespace Prueba.Service
{
    public interface ICitaService
    {
        public IList<Cita> FindAll();

        public Cita FindById(long id);

        public Cita FindByMedId(long id);

        public Cita FindByPacId(long id);


        public Cita InsertDiagnosticoToCita(Diagnostico diagnostico, long id);


        public Cita Insert(Cita cita);

        public Cita Update(Cita cita);

        public bool DeleteById(long id);
    }
}
