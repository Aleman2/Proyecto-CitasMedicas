using Prueba.Entity;
using Prueba.Repository;

namespace Prueba.Service.Impl
{
    public class CitaService : ICitaService
    {
        CitaRepository CitaRepository;
        DiagnosticoRepository DiagnosticoRepository;

        public CitaService(CitaRepository citaRepository, DiagnosticoRepository diagnosticoRepository)
        {
            CitaRepository = citaRepository;
            DiagnosticoRepository = diagnosticoRepository;
        }

        public bool DeleteById(long id)
        {
            var ret = CitaRepository.DeleteById(id).Result;
            if (ret == null) return false;
            return true;
        }

        public IList<Cita> FindAll()
        {
            return CitaRepository.GetAll().Result;
        }

        public Cita FindById(long id)
        {
            return CitaRepository.GetById(id).Result;
        }

        public Cita FindByMedId(long id)
        {
            return CitaRepository.GetByMedId(id).Result;
        }
        public Cita FindByPacId(long id)
        {
            return CitaRepository.GetByPacId(id).Result;
        }

        public Cita Insert(Cita cita)
        {
            Cita citaUp = CitaRepository.Add(cita).Result;
            return citaUp;
        }

        public Cita Update(Cita cita)
        {
            Cita citaUp = CitaRepository.Update(cita).Result;
            return citaUp;
        }
        public Cita InsertDiagnosticoToCita(Diagnostico diagnostico, long id)
        {
            Cita cita = FindById(id);
            Diagnostico d = DiagnosticoRepository.Add(diagnostico).Result;
            if (cita is null || cita.Diagnostico != null) 
             {
                return null;
             }
            cita.Diagnostico = d;
            return CitaRepository.Update(cita).Result;
        }

    }
}
