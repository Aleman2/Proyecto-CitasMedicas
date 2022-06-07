using AutoMapper;
using Prueba.DTO;
using Prueba.Entity;

namespace Prueba.Mapper
{

    public class DiagnosticoMap : Profile
    {
        public DiagnosticoMap()
        {
            CreateMap<DiagnosticoDTO, Diagnostico>();
            CreateMap<Diagnostico, DiagnosticoDTO>();

            CreateMap<DiagnosticoConexDTO, Diagnostico>();
            CreateMap<Diagnostico, DiagnosticoConexDTO>();
        }
    }

}
