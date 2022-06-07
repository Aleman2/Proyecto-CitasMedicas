using AutoMapper;
using Prueba.DTO;
using Prueba.Entity;

namespace Prueba.Mapper

{
    public class PacienteMap : Profile
    {
        public PacienteMap()
        {
            CreateMap<PacienteDTO, Paciente>();
            CreateMap<Paciente, PacienteDTO>();

            CreateMap<PacienteConexDTO, Paciente>();
            CreateMap<Paciente, PacienteConexDTO>();
        }
    }
}
