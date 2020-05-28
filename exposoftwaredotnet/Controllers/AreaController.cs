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
        public ActionResult<AreaViewModel> Get(string idArea)
        {
            var area = _areaService.BuscarxId(idArea);
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
        public ActionResult<string> Delete(string idArea)
        {
            string mensaje = _areaService.Eliminar(idArea);
            return Ok(mensaje);
        }
        private Area MapearArea(AreaInputModel areaInput)
        {
            var area = new Area
            {
                IdArea = areaInput.IdArea,
                Nombre = areaInput.Nombre
            };
            return area;
        }
        // PUT: api/Area/5
        [HttpPut("{idArea}")]
        public ActionResult<string> Put(string idArea, Area area)
        {
           var id=_areaService.BuscarxId(area.IdArea);
            if(id==null){
                return BadRequest("No encontrado");
            }
            var mensaje=_areaService.Modificar(area);
           return Ok(mensaje) ;
        }
        
    }
}