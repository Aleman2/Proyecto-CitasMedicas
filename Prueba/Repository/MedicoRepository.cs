using Prueba.Entity;
using Prueba.Repository.Imp;

namespace Prueba.Repository
{
    public class MedicoRepository : Repositor<Medicos, DataConte>
    {
        public MedicoRepository(DataConte context) : base(context)
        {
        }
    }
}
