using Prueba.Entity;
using Prueba.Repository.Imp;

namespace Prueba.Repository
{
    public class PacienteRepository : Repositor<Paciente, DataConte>
    {
        public PacienteRepository(DataConte context) : base(context)
        {
        }
    }
}
