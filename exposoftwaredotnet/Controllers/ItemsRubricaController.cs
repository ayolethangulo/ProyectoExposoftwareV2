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
    public class ItemsRubricaControllers: ControllerBase
    {
        private readonly RubricaService _rubricaService;
        public IConfiguration Configuration { get; }
        public ItemsRubricaControllers(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _rubricaService = new RubricaService(connectionString);
        }
        // GET: api/ItemsRubrica
        [HttpGet]
        public IEnumerable<ItemsRubricaViewModel> Gets()
        {
            var items = _rubricaService.ConsultarTodosItem().Select(i=> new ItemsRubricaViewModel(i));
            return items;
        }

        // POST: api/ItemsRubrica
        [HttpPost]
        public ActionResult<ItemsRubricaViewModel> Post(ItemsRubricaInputModel itemRubricaInput)
        {
            ItemsRubrica item = MapearItemRubrica(itemRubricaInput);
            var response = _rubricaService.GuardarItem(item);
            if (response.Error) 
            {
               ModelState.AddModelError("Guardar itemRubrica", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.ItemsRubrica);
        }
        // DELETE: api/ItemsRubrica/5
        [HttpDelete("{idRubrica}")]
        public ActionResult<string> Delete(string idRubrica)
        {
            string mensaje = _rubricaService.EliminarItem(idRubrica);
            return Ok(mensaje);
        }
        
        private ItemsRubrica MapearItemRubrica(ItemsRubricaInputModel itemRubricaInput)
        {
            var item = new ItemsRubrica
            {
                IdRubrica = itemRubricaInput.IdRubrica,
                Item = itemRubricaInput.Item,
                Descripcion = itemRubricaInput.Descripcion
            };
            return item;
        }
        // PUT: api/ItemsRubrica/5
        [HttpPut("{idRubrica}")]
        public ActionResult<string> Put(string idRubrica, ItemsRubrica item)
        {
            var mensaje=_rubricaService.ModificarItem(item);
           return Ok(mensaje) ;
        }
        
    }
}