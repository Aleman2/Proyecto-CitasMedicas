using AutoMapper;
using Prueba.DTO;
using Prueba.Entity;

namespace Prueba.Mapper
{
  
        public class CitaMap : Profile
        {
            public CitaMap()
            {
                CreateMap<CitaDTO, Cita>();
                CreateMap<Cita, CitaDTO>();

                CreateMap<CitaConexDTO, Cita>();
                CreateMap<Cita, CitaConexDTO>();
            }
        }
    
}
