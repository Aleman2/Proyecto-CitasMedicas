using Prueba.Entity;
using Prueba.Repository.Imp;

namespace Prueba.Repository
{
    public class DiagnosticoRepository : Repositor<Diagnostico, DataConte>
    {
        public DiagnosticoRepository(DataConte context) : base(context)
        {
        }
    }
}
