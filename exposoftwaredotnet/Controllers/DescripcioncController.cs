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
    public class DescripcioncController:ControllerBase
    {
         private readonly DescripcionesCService _descripcionService;

        public DescripcioncController(ExposoftwareContext context)
        {
            _descripcionService = new DescripcionesCService(context);
        }
        // GET: api/DescripcionC
        [HttpGet("{idProyecto}")]
        public IEnumerable<DescripcionCViewModel> Gets(int idProyecto)
        {
            var descripciones = _descripcionService.ConsultarTodos(idProyecto).Select(c => new DescripcionCViewModel(c));
            return descripciones;
        }

        // POST: api/DescripcionC
        [HttpPost]
        public ActionResult<DescripcionCViewModel> Post(DescripcionCInputModel descripcionInput)
        {
            DescripcionCalificacion descripcion = MapearDescripcionC(descripcionInput);
            var response = _descripcionService.Guardar(descripcion);
            if (response.Error)
            {
                ModelState.AddModelError("Guardar descripcion resultados", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.DescripcionCalificacion);
        }
        // DELETE: api/DescripcionC/5
        [HttpDelete("{idDescripcion}")]
        public ActionResult<string> Delete(int idDescripcion)
        {
            string mensaje = _descripcionService.Eliminar(idDescripcion);
            return Ok(mensaje);
        }
        private DescripcionCalificacion MapearDescripcionC(DescripcionCInputModel descripcionCInput)
        {
            var descripcion = new DescripcionCalificacion
            {
                IdCalificacion = descripcionCInput.IdCalificacion,
                Descripcion = descripcionCInput.Descripcion,
                Valor = descripcionCInput.Valor,
                IdProyecto = descripcionCInput.IdProyecto,
            };
            return descripcion;
        }
        // PUT: api/DescripcionC/5
        [HttpPut("{idDescripcion}")]
        public ActionResult<string> Put(int idDescripcion, DescripcionCalificacion descripcion)
        {
            var id = _descripcionService.BuscarxId(descripcion.IdDescripcion);
            if (id == null)
            {
                return BadRequest("No encontrado");
            }
            var mensaje = _descripcionService.Modificar(descripcion);
            return Ok(mensaje);
        }
    }
}