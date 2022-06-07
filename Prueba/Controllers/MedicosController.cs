using AutoMapper;
using Prueba.DTO;
using Prueba.Entity;
using Prueba.Service;
using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    [Route("api/Medicos")]
    [ApiController]
    public class MedicosController : Controller
    {
        private readonly IMedicoService _medicoService;
        private readonly IMapper _mapper;

        public MedicosController(IMedicoService medicoService, IMapper mapper)
        {
            _medicoService = medicoService;
            _mapper = mapper;
        }

        // GET: Medicos
        [HttpGet("GetMedicos")]
        public IList<MedicosDTO> Index()
        {

            //CON LOG RECUERDA
              /*
             * var medser = _medicoService.FindAll();
             * var MedDTO = medser.Select(x=>_mapper.Map<MedicosDTO>(x));
             * return View(MedDTO.ToList());
             */
            IList<MedicosDTO> medicosDTO = new List<MedicosDTO>();
            var medicos = _medicoService.FindAll();
            foreach (Medicos m in medicos)
            {
                medicosDTO.Add(_mapper.Map<MedicosDTO>(m));
            }
            return medicosDTO;
        }

        // GET: Medicos/{id}
        [HttpGet("Detalles/{id}")]
        public MedicosDTO Details(int id)
         {
          /*  if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }*/
            var medico = _medicoService.FindById(id); //Probar id.Value
           /* if (medico is null)
            {
                return NotFound(); //httpNotFound
            }*/

            return _mapper.Map<MedicosDTO>(medico);
        }

        // POST: Medicos
        [HttpPost("Create")]
        public MedicosDTO Create(MedicosConexDTO medicoDto)
              /*Sin automapper el codigo seria asi
             *  Medicos medico = new Medicos{
             *   valores medicos = MedicosDTO.valor,
             *  };
             *  medico = _medicoService.Insert(medico);
             *
             *return RedirectToAction("Index");
             *
             * 
             * 
             * */
        {
            Medicos medico = _mapper.Map<Medicos>(medicoDto);
            medico = _medicoService.Insert(medico);

            //Preguntar si seria mejor que en vez de este return fuese uno de redirectiontoaction o View(DiagnosticoDTO)
            return _mapper.Map<MedicosDTO>(medico);
        }

        // PUT: Medicos/{id}
        [HttpPut("Edit/{id}")]
        public MedicosDTO Edit(int id, MedicosDTO medicoDto)
        {
          /*  if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }*/

            var medico = _mapper.Map<Medicos>(medicoDto);
            if (id != medico.Id)
            {
                return null;
            }
            
            medico = _medicoService.Update(medico);
            //No seria mejor un redirectoaction?
            return _mapper.Map<MedicosDTO>(medico);
        }

         /*
        // DELETE: Medicos/{id}
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }

            var deleted = _medicoService.DeleteById(id); //value?

            if(deleted ==null)
            {
                return NotFound();
            }
            //segun el de ejemplo el cual no pone la parte de delete, seria hacer return del mapper 
            var MedDTO = _mapper.Map<MedicosDTO>(deleted);

            return View(MedDTO);

             
        }
        */
          [HttpDelete("Delete/{id}")]
        public string Delete(int id)
        {
          /*  if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }*/
            var deleted = _medicoService.DeleteById(id);
          /*   if(deleted ==null)
            {
                return NotFound();
            }*/
            if (deleted)
            {
                return "Se ha eliminado el medico con id: " + id;
            }

            return "No se ha podido eliminar el medico con id: " + id;
        }
    }
}
