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
    public class ItemsRubricaController: ControllerBase
    {
        private readonly ItemsRubricaService _itemsRubricaService;
        public IConfiguration Configuration { get; }
        public ItemsRubricaController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _itemsRubricaService = new ItemsRubricaService(connectionString);
        }
        // GET: api/ItemsRubrica
        [HttpGet]
        public IEnumerable<ItemsRubricaViewModel> Gets()
        {
            var items = _itemsRubricaService.ConsultarTodos().Select(ir=> new ItemsRubricaViewModel(ir));
            return items;
        }

        // POST: api/ItemsRubrica
        [HttpPost]
        public ActionResult<ItemsRubricaViewModel> Post(ItemsRubricaInputModel itemRubricaInput)
        {
            ItemsRubrica itemsRubrica = MapearItemRubrica(itemRubricaInput);
            var response = _itemsRubricaService.Guardar(itemsRubrica);
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
            string mensaje = _itemsRubricaService.Eliminar(idRubrica);
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
            var mensaje=_itemsRubricaService.Modificar(item);
           return Ok(mensaje) ;
        }
        
    }
}