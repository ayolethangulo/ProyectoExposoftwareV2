using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Logica;
using Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using exposoftwaredotnet.Models;

namespace exposoftwaredotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController: ControllerBase
    {
        private readonly ProyectoService _proyectoService;
        public ProyectoController(ExposoftwareContext context)
        {
            _proyectoService = new ProyectoService(context);
        }
        // GET: api/Proyecto
        [HttpGet]
        public IEnumerable<ProyectoViewModel> Gets()
        {
            var proyectos = _proyectoService.ConsultarTodos().Select(p=> new ProyectoViewModel(p));
            return proyectos;
        }

        // GET: api/Proyecto/5
        [HttpGet("{idProyecto}")]
        public ActionResult<ProyectoViewModel> Get(int idProyecto)
        {
            var proyecto = _proyectoService.BuscarxIdentificacion(idProyecto);
            if (proyecto == null) return NotFound();
            var proyectoViewModel = new ProyectoViewModel(proyecto);
            return proyectoViewModel;
        }
        // POST: api/Proyecto
        [HttpPost]
        public ActionResult<ProyectoViewModel> Post(ProyectoInputModel proyectoInput)
        {
            Proyecto proyecto = MapearProyecto(proyectoInput);
            var response = _proyectoService.Guardar(proyecto);
            if (response.Error) 
            {
                ModelState.AddModelError("Guardar Proyecto", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.Proyecto);
        }
        // DELETE: api/Proyecto/5
        [HttpDelete("{idProyecto}")]
        public ActionResult<string> Delete(int idProyecto)
        {
            string mensaje = _proyectoService.Eliminar(idProyecto);
            return Ok(mensaje);
        }
        private Proyecto MapearProyecto(ProyectoInputModel proyectoInput)
        {
            var proyecto = new Proyecto
            {
                Identificacion = proyectoInput.Identificacion,
                Asignatura = proyectoInput.Asignatura,
                Titulo = proyectoInput.Titulo,
                Semestre = proyectoInput.Semestre,
                Resumen = proyectoInput.Resumen,
                Metodologia = proyectoInput.Metodologia,
                Resultados = proyectoInput.Resultados,
            };
            return proyecto;
        }
        // PUT: api/Proyecto/5
        [HttpPut("{idProyecto}")]
        public ActionResult<string> Put(string idProyecto, Proyecto proyecto)
        {
            var id=_proyectoService.BuscarxIdentificacion(proyecto.IdProyecto);
            if(id==null){
                return BadRequest("No encontrado");
            }
            var mensaje=_proyectoService.Modificar(proyecto);
           return Ok(mensaje) ;
        }
        
    }
}