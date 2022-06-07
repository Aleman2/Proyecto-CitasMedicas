
using Prueba.Entity;
using Prueba.Repository;
using Prueba.Service;

namespace Prueba.Service.Impl
{
    public class MedicoService : IMedicoService
    {
        MedicoRepository MedicoRepository;
        PacienteRepository PacienteRepository;
        //CitaRepository CitaRepository;

        public MedicoService(MedicoRepository medicoRepository, PacienteRepository pacienteRepository)
        {
            MedicoRepository = medicoRepository;
            PacienteRepository = pacienteRepository;

        }

        public bool DeleteById(long id)
        {
            var ret = MedicoRepository.DeleteById(id).Result;
            if (ret == null) return false;
            return true;
        }

        public IList<Medicos> FindAll()
        {
            return MedicoRepository.GetAll().Result;
        }

        public Medicos FindById(long id)
        {
            return MedicoRepository.GetById(id).Result;
        }

        public Medicos Insert(Medicos medico)
        {
            Medicos medicoUp = MedicoRepository.Add(medico).Result;
            return medicoUp;
        }

        public Medicos Update(Medicos medico)
        {
            Medicos medicoUp = MedicoRepository.Update(medico).Result;
            return medicoUp;
        }

        public Medicos InsertPacienteToMedico(long id_pac, long id)
        {
            Medicos medico = FindById(id);
            Paciente paciente = PacienteRepository.GetById(id_pac).Result;
            if (medico is null || paciente is null) 
            {
                return null;
            }
            if (!medico.Pacientes.Contains(paciente))
            { 
                medico.Pacientes.Add(paciente);
                }
            return MedicoRepository.Update(medico).Result;
            

        }

     
    }
}
