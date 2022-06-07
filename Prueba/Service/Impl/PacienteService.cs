using Prueba.Entity;
using Prueba.Repository;
using Prueba.Service;

namespace Prueba.Service.Impl
{
    public class PacienteService : IPacienteService
    {
        PacienteRepository PacienteRepository;
        MedicoRepository MedicoRepository;


        public PacienteService(PacienteRepository paciRepository, MedicoRepository mediRepository)
        {
            PacienteRepository = paciRepository;
            MedicoRepository = mediRepository;

        }

        public bool DeleteById(long id)
        {
            var ret = PacienteRepository.DeleteById(id).Result;
            if (ret == null) return false;
            return true;
        }

        public IList<Paciente> FindAll()
        {
            return PacienteRepository.GetAll().Result;
        }

        public Paciente FindById(long id)
        {
            return PacienteRepository.GetById(id).Result;
        }

        public Paciente Insert(Paciente paciente)
        {
            Paciente pacienteUp = PacienteRepository.Add(paciente).Result;
            return pacienteUp;
        }
        public Paciente Update(Paciente paciente)
        {
            Paciente pacienteUp = PacienteRepository.Update(paciente).Result;
            return pacienteUp;
        }

        public Paciente InsertMedicoToPaciente(long id_med, long id)
        {
            Paciente paciente = FindById(id);
            Medicos medico = MedicoRepository.GetById(id_med).Result;
            if (paciente is null || medico is null) 
            {
                return null; 
            }
            if (!paciente.Medicos.Contains(medico)) 
            { 
                paciente.Medicos.Add(medico);  
                }
                return PacienteRepository.Update(paciente).Result;
            
            

        }
 

    }
}
