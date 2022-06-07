using Prueba.Repository;
using Prueba.Entity;

namespace Prueba.Service
{
    public interface IPacienteService
    {
        public IList<Paciente> FindAll();

        public Paciente FindById(long id);

        //Cambiar longs por int cuando lo cambie de la base de datos
        public Paciente InsertMedicoToPaciente(long id_medico, long id);

        /*Recordatorio: Si se decide poner el id de la cita en paciente, usar esto
        public Paciente InsertCitaToPaciente(long id_cita, long id);*/


        public Paciente Insert(Paciente paciente);

        public Paciente Update(Paciente paciente);

        public bool DeleteById(long id);
    }
}
