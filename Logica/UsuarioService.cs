using System;
using Datos;
using Entity;
using System.Collections.Generic;
using System.Linq;



namespace Logica
{
    public class UsuarioService
    {
     private readonly ExposoftwareContext _context;

        public UsuarioService(ExposoftwareContext context)
        {
            _context = context;
        }
        
        public GuardarUsuarioResponse Guardar(Usuario usuario)
        {
            try
            {
                var usuarioBuscada = _context.Usuarios.Find(usuario.User);
                if (usuarioBuscada != null)
                {
                    return new GuardarUsuarioResponse("Error el usuario ya se encuentra registrada");
                }
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return new GuardarUsuarioResponse(usuario);
            }
            catch (Exception e)
            {
                return new GuardarUsuarioResponse($"Error de la Aplicacion: {e.Message}");
            }
        }
        public List<Usuario> ConsultarTodos()
        {
            List<Usuario> usuarios = _context.Usuarios.ToList();
            return usuarios;
        }
        public string Eliminar(string identificacion)
        {
            try
            {
                var usuario = _context.Usuarios.Find(identificacion);
                if (usuario != null)
                {
                  _context.Usuarios.Remove(usuario);
                  _context.SaveChanges();
                    return ($"El registro {usuario.User} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {identificacion} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
        }
        public Usuario BuscarxIdentificacion(string identificacion)
        {
            Usuario usuario =_context.Usuarios.Find(identificacion);
            return usuario;
        }

    }
     public class GuardarUsuarioResponse 
    {
        public GuardarUsuarioResponse(Usuario usuario)
        {
            Error = false;
            Usuario = usuario;
        }
        public GuardarUsuarioResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Usuario Usuario { get; set; }

    }
    
}
