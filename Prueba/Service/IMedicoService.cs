using Prueba.Repository;
using Prueba.Entity;

namespace Prueba.Service
{
    public interface IMedicoService
    {
        public IList<Medicos> FindAll();

        public Medicos FindById(long id);

        public Medicos InsertPacienteToMedico(long id_paciente, long id);

        /*Si decido poner Cita en medicos, poner esto
        public Cita InsertCitaticoToMedico(Diagnostico diagnostico, long id);*/

        public Medicos Insert(Medicos medicos);

        public Medicos Update(Medicos medicos);

        public bool DeleteById(long id);
    }
}
