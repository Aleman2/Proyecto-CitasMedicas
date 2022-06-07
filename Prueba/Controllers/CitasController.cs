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
using AutoMapper;
using Prueba.DTO;

namespace Prueba.Controllers
{
    [Route("api/Citas")]
    [ApiController]
    public class CitasController : Controller
    {
        private readonly ICitaService _citaService;
        private readonly IMedicoService _medicoService;
        private readonly IPacienteService _pacienteService;

        private readonly IMapper _mapper;

        public CitasController(ICitaService citaService, IMedicoService medicoService, IPacienteService pacienteService, IMapper mapper)
        {
            _citaService = citaService;
            _medicoService = medicoService;
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        // GET: Citas
        [HttpGet("GetCitas")]
        public IList<CitaDTO> Index()
        {
            /*var citser = _citaService.FindAll();
             * var CitDTO = citser.Select(x=>_mapper.Map<CitaDTO>(x));
             * return View(CitaDTO.ToList());
             */
            IList<CitaDTO> citasDTO = new List<CitaDTO>();
            var citas = _citaService.FindAll();
            foreach (Cita c in citas)
            {
                citasDTO.Add(_mapper.Map<CitaDTO>(c));
            }
            return citasDTO;
        }

        // GET: Citas/{id}
        [HttpGet("Detalles/{id}")]
        public CitaDTO Details(int id)
        {
          /*  if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }*/
            var cita = _citaService.FindById(id); //Probar id.Value
         /*   if (cita is null)
            {
                return NotFound(); //httpNotFound
            }*/

            return _mapper.Map<CitaDTO>(cita);
        }
        [HttpGet("DetallesMed/{id}")]
        public CitaDTO DetailsMed(int id)
        {
            /*  if (id == null)
              {
                  return new StatusCodeResult(StatusCode.BadRequest);
              }*/
            var cita = _citaService.FindByMedId(id); //Probar id.Value
            /*   if (cita is null)
               {
                   return NotFound(); //httpNotFound
               }*/

            return _mapper.Map<CitaDTO>(cita);
        }
        [HttpGet("DetallesPac/{id}")]
        public CitaDTO DetailsPac(int id)
        {
            /*  if (id == null)
              {
                  return new StatusCodeResult(StatusCode.BadRequest);
              }*/
            var cita = _citaService.FindByPacId(id); //Probar id.Value
            /*   if (cita is null)
               {
                   return NotFound(); //httpNotFound
               }*/

            return _mapper.Map<CitaDTO>(cita);
        }

        // POST: Citas
        [HttpPost("Create")]
        public CitaDTO Create(CitaConexDTO citaDto)
            /*Sin automapper el codigo seria asi
             *  Cita cita = new Cita{
             *   valores cita = CitaDTO.valor,
             *  };
             *  cita = _citaService.Insert(cita);
             *
             *return RedirectToAction("Index");
             *
             * 
             * 
             * */
        {
            Cita cita = _mapper.Map<Cita>(citaDto);
            cita = _citaService.Insert(cita);

            //Preguntar si seria mejor que en vez de este return fuese uno de redirectiontoaction o View(DiagnosticoDTO)
            return _mapper.Map<CitaDTO>(cita);
        }

        // POST: Citas/{id}
        [HttpPost("Insertar/{id}")]
        public CitaDTO AddDiagnosticoToCita(long id, DiagnosticoConexDTO diagnosticoDto2)
        {
          /*  if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }*/
            Diagnostico diag = _mapper.Map<Diagnostico>(diagnosticoDto2);
            Cita c = _citaService.InsertDiagnosticoToCita(diag, id);
            if (c is null) 
            {
                return null;
            }
            return _mapper.Map<CitaDTO>(c);
        }

        // PUT: Citas/{id}
        [HttpPut("Edit/{id}")]
        public CitaDTO Edit(long id, CitaDTO citaDto)
        {
            //if (id == null)
           // {
           //     return new StatusCodeResult(StatusCode.BadRequest);
           // }

            var cita = _mapper.Map<Cita>(citaDto);
            if (id != cita.Id)
            {
                return null;
            }
            
            cita = _citaService.Update(cita);
            //No seria mejor un redirectoaction?
            return _mapper.Map<CitaDTO>(cita);
        }
          /*
        // DELETE: Cita/{id}
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }

            var deleted = _citaService.DeleteById(id); //value?

            if(deleted ==null)
            {
                return NotFound();
            }
            //segun el de ejemplo el cual no pone la parte de delete, seria hacer return del mapper 
            var CitDTO = _mapper.Map<CitaDTO>(deleted);

            return View(CigDTO);

             
        }
        */
          [HttpDelete("Delete/{id}")]
        public string Delete(long id)
        {
           /* if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }*/
            var deleted = _citaService.DeleteById(id);
            /* if(deleted ==null)
            {
                return NotFound();
            }*/
            if (deleted)
            {
                return "Se ha eliminado la cita con id: " + id;
            }

            return "No se ha podido eliminar la cita con id: " + id;
        }
    }
}
