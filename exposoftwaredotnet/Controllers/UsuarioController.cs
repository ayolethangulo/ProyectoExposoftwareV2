using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Http;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using exposoftwaredotnet.Models;

namespace exposoftwaredotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController: ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        public IConfiguration Configuration { get; }
        public UsuarioController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _usuarioService = new UsuarioService(connectionString);
        }
        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<UsuarioViewModel> Gets()
        {
            var usuarios = _usuarioService.ConsultarTodos().Select(p=> new UsuarioViewModel(p));
            return usuarios;
        }

        // GET: api/Usuario/5
        [HttpGet("{identificacion}")]
        public ActionResult<UsuarioViewModel> Get(string identificacion)
        {
            var usuario = _usuarioService.BuscarxIdentificacion(identificacion);
            if (usuario == null) return NotFound();
            var usuarioViewModel = new UsuarioViewModel(usuario);
            return usuarioViewModel;
        }
        // POST: api/Usuario
        [HttpPost]
        public ActionResult<UsuarioViewModel> Post(UsuarioInputModel usuarioInput)
        {
            Usuario usuario = MapearUsuario(usuarioInput);
            var response = _usuarioService.Guardar(usuario);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Usuario);
        }
        // DELETE: api/Usuario/5
        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
            string mensaje = _usuarioService.Eliminar(identificacion);
            return Ok(mensaje);
        }
        private Usuario MapearUsuario(UsuarioInputModel usuarioInput)
        {
            var usuario = new Usuario
            {
                Identificacion = usuarioInput.Identificacion,
                UsuarioNombre = usuarioInput.UsuarioNombre,
                Contrasena = usuarioInput.Contrasena,
                TipoDocente = usuarioInput.TipoDocente,
               
            };
            return usuario;
        }
        // PUT: api/Usuario/5
        [HttpPut("{identificacion}")]
        public ActionResult<string> Put(string identificacion, Usuario usuario)
        {
            throw new NotImplementedException();
        }
        
    }
}