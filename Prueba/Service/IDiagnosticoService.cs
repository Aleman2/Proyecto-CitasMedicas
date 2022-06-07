using Prueba.Repository;
using Prueba.Entity;

namespace Prueba.Service
{
    public interface IDiagnosticoService
    {
        public IList<Diagnostico> FindAll();

        public Diagnostico FindById(long id);

        public Diagnostico Insert(Diagnostico diagnostico);

        public Diagnostico Update(Diagnostico diagnostico);

        public bool DeleteById(long id);
    }
}
