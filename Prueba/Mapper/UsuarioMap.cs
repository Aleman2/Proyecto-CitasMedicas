using AutoMapper;
using Prueba.DTO;
using Prueba.Entity;

namespace Prueba.Mapper

{
    public class UsuarioMap : Profile
    {
        public UsuarioMap()
        {
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<Usuario, UsuarioDTO>();
  
        }
    }
}
