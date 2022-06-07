using AutoMapper;
using Prueba.DTO;
using Prueba.Entity;

namespace Prueba.Mapper

{
    public class MedicosMap : Profile
    {
        public MedicosMap()
        {
            CreateMap<MedicosDTO, Medicos>();
            CreateMap<Medicos, MedicosDTO>();

            CreateMap<MedicosConexDTO, Medicos>();
            CreateMap<Medicos, MedicosConexDTO>();
        }
    }
}
