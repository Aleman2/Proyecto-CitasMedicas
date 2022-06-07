using Prueba.Entity;
using Prueba.Repository;

namespace Prueba.Service.Impl
{
    public class DiagnosticoService : IDiagnosticoService
    {
        DiagnosticoRepository DiagnosticoRepository;

        public DiagnosticoService(DiagnosticoRepository diagnosticoRepository)
        {
            DiagnosticoRepository = diagnosticoRepository;
        }

        public bool DeleteById(long id)
        {
            var ret = DiagnosticoRepository.DeleteById(id).Result;
            if (ret == null) return false;
            return true;
        }

        public IList<Diagnostico> FindAll()
        {
            return DiagnosticoRepository.GetAll().Result;
        }

        public Diagnostico FindById(long id)
        {
            return DiagnosticoRepository.GetById(id).Result;
        }

        public Diagnostico Insert(Diagnostico diagnostico)
        {
            Diagnostico diagnosticoUp = DiagnosticoRepository.Add(diagnostico).Result;
            return diagnosticoUp;
        }

        public Diagnostico Update(Diagnostico diagnostico)
        {
            Diagnostico diagnosticoUp = DiagnosticoRepository.Update(diagnostico).Result;
            return diagnosticoUp;
        }
    }
}
