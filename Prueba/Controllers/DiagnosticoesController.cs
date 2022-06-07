using AutoMapper;
using Prueba.DTO;
using Prueba.Entity;
using Prueba.Service;
using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    [Route("api/Diagnosticos")]
    [ApiController]
    public class DiagnosticosController : Controller
    {
        private readonly IDiagnosticoService _diagnosticoService;
        private readonly IMapper _mapper;

        public DiagnosticosController(IDiagnosticoService diagnosticoService, IMapper mapper)
        {
            _diagnosticoService = diagnosticoService;
            _mapper = mapper;
        }

        // GET: Diagnosticos
        [HttpGet]
        public IList<DiagnosticoDTO> Index()
        {
            /*En vez de la primera linea y el foreach, probar con:
             * var diagser = _diagnosticoService.FindAll();
             * var DiagDTO = diagser.Select(x=>_mapper.Map<DiagnosticoDTO>(x));
             * return View(DiagDTO.ToList());
             */
            IList<DiagnosticoDTO> diagnosticosDTO = new List<DiagnosticoDTO>();
            var diagnosticos = _diagnosticoService.FindAll();
            foreach (Diagnostico d in diagnosticos)
            {
                diagnosticosDTO.Add(_mapper.Map<DiagnosticoDTO>(d));
            }
            return diagnosticosDTO;
        }

        // GET: Diagnosticos/{id}
        [HttpGet("{id}")]
        public DiagnosticoDTO Details(long id)
        {
         /*   if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }*/
            var diagnostico = _diagnosticoService.FindById(id); //Probar id.Value
           /*  if (diagnostico is null)
           {
                return NotFound(); //httpNotFound
            }*/

            return _mapper.Map<DiagnosticoDTO>(diagnostico);
        }

        // POST: Diagnosticos
        [HttpPost]
        //
        public DiagnosticoDTO Create(DiagnosticoDTO diagnosticoDto)
            /*Sin automapper el codigo seria asi
             *  Diagnostico diagnostico = new Diagnostico{
             *   DiagID = DiagnosticoDTO.ID,
             *   Enfermedad = DiagnosticoDTO.Enfermedad,
             *   Valora = DiagnosticoDTO.Valoracion
             *  };
             *  diagnostico = _diagnosticoService.Insert(diagnostico);
             *
             *return RedirectToAction("Index");
             *
             * 
             * 
             * */
        {
            Diagnostico diagnostico = _mapper.Map<Diagnostico>(diagnosticoDto);
            diagnostico = _diagnosticoService.Insert(diagnostico);

            //Preguntar si seria mejor que en vez de este return fuese uno de redirectiontoaction o View(DiagnosticoDTO)
            return _mapper.Map<DiagnosticoDTO>(diagnostico);
        }

        // PUT: Diagnosticos/{id}
        [HttpPut("{id}")]
        public DiagnosticoDTO Edit(long id, DiagnosticoDTO diagnosticoDto)
        {
          /*  if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }*/

            var diagnostico = _mapper.Map<Diagnostico>(diagnosticoDto);
            if (id != diagnostico.Id)
            {
                return null;
            }
            
            diagnostico = _diagnosticoService.Update(diagnostico);
            //No seria mejor un redirectoaction?
            return _mapper.Map<DiagnosticoDTO>(diagnostico);
        }
        /*
        // DELETE: Diagnosticos/{id}
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }

            var deleted = _diagnosticoService.DeleteById(id); //value?

            if(deleted ==null)
            {
                return NotFound();
            }
            //segun el de ejemplo el cual no pone la parte de delete, seria hacer return del mapper 
            var DigDTO = _mapper.Map<DiagnosticoDTO>(deleted);

            return View(DigDTO);

             
        }
        */
          [HttpDelete("{id}")]
        public string Delete(long id)
        {
         /*   if (id == null)
            {
                return new StatusCodeResult(StatusCode.BadRequest);
            }*/
            var deleted = _diagnosticoService.DeleteById(id);
           /*  if(deleted ==null)
            {
                return NotFound();
            }*/
            if (deleted)
            {
                return "Se ha eliminado el diagnostico con id: " + id;
            }

            return "No se ha podido eliminar el diagnostico con id: " + id;
        }


    }
}
