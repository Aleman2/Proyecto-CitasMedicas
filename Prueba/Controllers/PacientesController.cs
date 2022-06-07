using AutoMapper;
using Prueba.DTO;
using Prueba.Entity;
using Prueba.Service;
using Microsoft.AspNetCore.Mvc;


namespace Prueba.Controllers
{
    [Route("api/Paciente")]
    [ApiController]

    public class PacientesController : Controller
    {
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public PacientesController(IPacienteService pacienteService, IMapper mapper)
        {
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        // GET: Pacientes
        [HttpGet("GetPacientes")]
        public IList<PacienteDTO> Index()
        {
            /*En vez de la primera linea y el foreach, probar con:
             * var pacser = _pacienteService.FindAll();
             * var PacDTO = pacser.Select(x=>_mapper.Map<PacienteDTO>(x));
             * return View(PacDTO.ToList());
             */
           
            IList<PacienteDTO> pacienteDTO = new List<PacienteDTO>();

            var paciente = _pacienteService.FindAll();
   

            foreach (Paciente p in paciente)
            {
               
                pacienteDTO.Add(_mapper.Map<PacienteDTO>(p));
            }
            return pacienteDTO;
        }

        // GET: Pacientes/{id}
        [HttpGet("Detalles/{id}")]
        public PacienteDTO Details(long id)
        {
          /*  if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }*/
            var paciente = _pacienteService.FindById(id); //Probar id.Value
          /*  if (paciente is null)
            {
                return NotFound(); //httpNotFound
            }*/

            return _mapper.Map<PacienteDTO>(paciente);
        }

        // POST: Pacientes
        [HttpPost("Create")]
        public PacienteDTO Create(PacienteConexDTO pacienteDto)
          /*Sin automapper el codigo seria asi
             *  Paciente paciente = new Paciente{
             *   valores pacientes = PacienteDTO.valor,
             *  };
             *  paciente = _pacienteService.Insert(diagnostico);
             *
             *return RedirectToAction("Index");
             *
             * 
             * 
             * */
        {
            Paciente paciente = _mapper.Map<Paciente>(pacienteDto);
            paciente = _pacienteService.Insert(paciente);

            //Preguntar si seria mejor que en vez de este return fuese uno de redirectiontoaction o View(DiagnosticoDTO)
            return _mapper.Map<PacienteDTO>(paciente);
        }

        // PUT: Pacientes/{id}
        [HttpPut("Edit/{id}")]
        public PacienteDTO Edit(long id, PacienteDTO pacienteDto)
         {
           /* if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }*/

            var paciente = _mapper.Map<Paciente>(pacienteDto);
            if (id != paciente.Id)
            {
                return null;
            }
            
            paciente = _pacienteService.Update(paciente);
            //No seria mejor un redirectoaction?
            return _mapper.Map<PacienteDTO>(paciente);
        }
        /*
        // DELETE: Paciente/{id}
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }

            var deleted = _pacienteService.DeleteById(id); //value?

            if(deleted ==null)
            {
                return NotFound();
            }
            //segun el de ejemplo el cual no pone la parte de delete, seria hacer return del mapper 
            var PacDTO = _mapper.Map<PacienteDTO>(deleted);

            return View(PacDTO);

             
        }
        */
          [HttpDelete("Delete/{id}")]
        public string Delete(long id)
        {
         /*   if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }*/
            var deleted = _pacienteService.DeleteById(id);
           /*  if(deleted ==null)
            {
                return NotFound();
            }*/
            if (deleted)
            {
                return "Se ha eliminado el paciente con id: " + id;
            }

            return "No se ha podido eliminar el paciente con id: " + id;
        }
    }
}
