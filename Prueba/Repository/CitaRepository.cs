using Prueba.Entity;
using Prueba.Repository.Imp;

namespace Prueba.Repository
{
    public class CitaRepository : ICitas
    {
        private readonly DataConte dataconte;

        public CitaRepository(DataConte dataconte)
        {
            this.dataconte = dataconte;
        }

        public async Task<Cita> Add(Cita cita)
        {
            var result = await dataconte.CitaDB.AddAsync(cita);
            await dataconte.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Cita> DeleteById(long id)
        {
            var result = dataconte.CitaDB.FirstOrDefault(e => e.Id == id);
            if (result != null)
            {
                dataconte.CitaDB.Remove(result);
                await dataconte.SaveChangesAsync();
                return result;

            }

            return null;
        }

        public async Task<List<Cita>> GetAll()
        {
            return dataconte.CitaDB.ToList();
        }

        public async Task<Cita> GetById(long id)
        {
            return await dataconte.Set<Cita>().FindAsync(id);
        }

        public async Task<Cita> GetByMedId(long id)
        {
            return dataconte.CitaDB.FirstOrDefault(e => e.MedicoId == id);
        }

        public async Task<Cita> GetByPacId(long id)
        {
            return dataconte.CitaDB.FirstOrDefault(e => e.PacienteId == id);
        }


        public Task<Cita> Update(Cita cita)
        {
            var result = dataconte.CitaDB.FirstOrDefault(e => e.Id == cita.Id);
            if (result != null)
            {
                dataconte.CitaDB.Update(result);
                dataconte.SaveChangesAsync();

            }

            return null;
        }
    }
}
