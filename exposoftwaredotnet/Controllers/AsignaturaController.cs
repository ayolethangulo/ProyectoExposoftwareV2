using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using exposoftwaredotnet.Models;

namespace exposoftwaredotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignaturaController: ControllerBase
    {
        private readonly AsignaturaService _asignaturaService;
        public IConfiguration Configuration { get; }
        public AsignaturaController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _asignaturaService = new AsignaturaService(connectionString);
        }
        // GET: api/Asignatura
        [HttpGet]
        public IEnumerable<AsignaturaViewModel> Gets()
        {
            var asignaturas = _asignaturaService.ConsultarTodos().Select(a=> new AsignaturaViewModel(a));
            return asignaturas;
        }

        // GET: api/Asignatura/5
        [HttpGet("{idAsignatura}")]
        public ActionResult<AsignaturaViewModel> Get(string id)
        {
            var asignatura = _asignaturaService.BuscarxId(id);
            if (asignatura == null) return NotFound();
            var asignaturaViewModel = new AsignaturaViewModel(asignatura);
            return asignaturaViewModel;
        }
        // POST: api/Asignatura
        [HttpPost]
        public ActionResult<AsignaturaViewModel> Post(AsignaturaInputModel asignaturaInput)
        {
            Asignatura asignatura = MapearAsignatura(asignaturaInput);
            var response = _asignaturaService.Guardar(asignatura);
            if (response.Error) 
            {
               ModelState.AddModelError("Guardar Asignatura", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.Asignatura);
        }
        // DELETE: api/Asignatura/5
        [HttpDelete("{idAsignatura}")]
        public ActionResult<string> Delete(string id)
        {
            string mensaje = _asignaturaService.Eliminar(id);
            return Ok(mensaje);
        }
        private Asignatura MapearAsignatura(AsignaturaInputModel asignaturaInput)
        {
            var asignatura = new Asignatura
            {
                IdAsignatura = asignaturaInput.IdAsignatura,
                NombreAsignatura = asignaturaInput.NombreAsignatura,
                IdArea = asignaturaInput.IdArea
            };
            return asignatura;
        }
        // PUT: api/Asignatura/5
        [HttpPut("{idAsignatura}")]
        public ActionResult<string> Put(string id, Asignatura asignatura)
        {
            throw new NotImplementedException();
        }
        
    }
}