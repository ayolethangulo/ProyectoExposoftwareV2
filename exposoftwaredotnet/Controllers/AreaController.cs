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
    public class AreaController: ControllerBase
    {
        private readonly AreaService _areaService;
        public IConfiguration Configuration { get; }
        public AreaController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _areaService = new AreaService(connectionString);
        }
        // GET: api/Area
        [HttpGet]
        public IEnumerable<AreaViewModel> Gets()
        {
            var areas = _areaService.ConsultarTodos().Select(a=> new AreaViewModel(a));
            return areas;
        }

        // GET: api/Area/5
        [HttpGet("{idArea}")]
        public ActionResult<AreaViewModel> Get(string id)
        {
            var area = _areaService.BuscarxId(id);
            if (area == null) return NotFound();
            var areaViewModel = new AreaViewModel(area);
            return areaViewModel;
        }
        // POST: api/Area
        [HttpPost]
        public ActionResult<AreaViewModel> Post(AreaInputModel areaInput)
        {
            Area area = MapearArea(areaInput);
            var response = _areaService.Guardar(area);
            if (response.Error) 
            {
               ModelState.AddModelError("Guardar Area", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.Area);
        }
        // DELETE: api/Area/5
        [HttpDelete("{idArea}")]
        public ActionResult<string> Delete(string id)
        {
            string mensaje = _areaService.Eliminar(id);
            return Ok(mensaje);
        }
        private Area MapearArea(AreaInputModel areaInput)
        {
            var area = new Area
            {
                IdArea = areaInput.IdArea,
                Nombre = areaInput.Nombre,
            };
            return area;
        }
        // PUT: api/Area/5
        [HttpPut("{idArea}")]
        public ActionResult<string> Put(string id, Area area)
        {
            throw new NotImplementedException();
        }
        
    }
}