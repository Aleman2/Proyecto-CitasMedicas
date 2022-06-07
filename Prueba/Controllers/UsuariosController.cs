#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba.Entity;
using Prueba.Service;
using Prueba.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using System.Linq.Expressions;

namespace Prueba.Controllers
{

    [ApiController]

    [Route("api/Usuario")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;



        public UsuariosController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        private static readonly Expression<Func<Usuario, UsuarioDTO>> AsUsuarioDto =
           x => new UsuarioDTO
           {
               Nombre = x.Nombre,
               Apellidos = x.Apellidos,
               User = x.User,
               Clave = x.Clave
           };


        // GET: Usuarios
        [HttpGet("GetUsuarios")]
        public IList<UsuarioDTO> Index()
        {
            /*En vez de la primera linea y el foreach, probar con:
             * var ususer = _usuarioService.FindAll();
             * var UsuDTO = ususer.Select(x=>_mapper.Map<UsuariosDTO>(x));
             * return View(UsuDTO.ToList());
             */
            IList<UsuarioDTO> usuarioDTO = new List<UsuarioDTO>();
            var usuarios = _usuarioService.FindAll();
            foreach (Usuario u in usuarios)
            {
                usuarioDTO.Add(_mapper.Map<UsuarioDTO>(u));
            }
            return usuarioDTO;
        }

        // GET: Usuarios/{id}
        [HttpGet("Detalles/{id}")]
        public UsuarioDTO Details(long id)
        {
         /*   if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }*/
            var usuarios = _usuarioService.FindById(id); //Probar id.Value
            if (usuarios is null)
            {
                return null; //httpNotFound´´

            }
            return _mapper.Map<UsuarioDTO>(usuarios);
        }



        [HttpGet("Detalles/{usuario}/{clave}")]
        public UsuarioDTO Search(string usuario, string clave)
        {
            /*   if (id == null)
               {
                   return new StatusCodeResult(StatusCode.BadRequest);
               }*/
            var usuarios = _usuarioService.Search(usuario, clave); //Probar id.Value
            if (usuarios is null)
            {
                return null; //httpNotFound´´

            }
            return _mapper.Map<UsuarioDTO>(usuarios);
        }

        // POST: Usuarios
        [HttpPost("Create")]
        public UsuarioDTO Create(UsuarioDTO usuarioDto)
         /*Sin automapper el codigo seria asi
             *  Usuarios usuarios = new Usuarios{
             *  valores usuario = UsuariosDTO.valor,
             *  };
             *  usuarios = _usuarioService.Insert(usuarios);
             *
             *return RedirectToAction("Index");
             *
             * 
             * 
             * */
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            usuario = _usuarioService.Insert(usuario);

            //Preguntar si seria mejor que en vez de este return fuese uno de redirectiontoaction o View(DiagnosticoDTO)
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        // PUT: Usuarios/{id}
        [HttpPut("Edit/{id}")]
        public UsuarioDTO Edit(int id, UsuarioDTO usuarioDto)
        {
         /*   if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }*/

            var usuarios = _mapper.Map<Usuario>(usuarioDto);
            if (id != usuarios.Id)
            {
                return null;
            }
            
            usuarios = _usuarioService.Update(usuarios);
            //No seria mejor un redirectoaction?
            return _mapper.Map<UsuarioDTO>(usuarios);
        }
        /*
        // DELETE: Usuarios/{id}
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }

            var deleted = _usuarioService.DeleteById(id); //value?

            if(deleted ==null)
            {
                return NotFound();
            }
            //segun el de ejemplo el cual no pone la parte de delete, seria hacer return del mapper 
            var UsuDTO = _mapper.Map<UsuariosDTO>(deleted);

            return View(UsuDTO);

             
        }
        */
          [HttpDelete("Delete/{id}")]
        public string Delete(int id)
        {
           /* if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }*/
            var deleted = _usuarioService.DeleteById(id);
          /*   if(deleted ==null)
            {
                return NotFound();
            }*/
            if (deleted)
            {
                return "Se ha eliminado el usuario con id: " + id;
            }

            return "No se ha podido eliminar el usuario con id: " + id;
        }
    }
}
