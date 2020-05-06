using System;
using Datos;
using Entity;
using System.Collections.Generic;


namespace Logica
{
    public class UsuarioService
    {
        private readonly ConnectionManager _conexion;
        private readonly UsuarioRepository _repositorio;

        public UsuarioService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new UsuarioRepository(_conexion);
        }
        
        public GuardarUsuarioResponse Guardar(Usuario usuario)
        {
            try
            {
                _conexion.Open();
                _repositorio.Guardar(usuario);
                _conexion.Close();
                return new GuardarUsuarioResponse(usuario);
            }
            catch (Exception e)
            {
                return new GuardarUsuarioResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }
        public List<Usuario> ConsultarTodos()
        {
            _conexion.Open();
            List<Usuario> usuarios = _repositorio.ConsultarTodos();
            _conexion.Close();
            return usuarios;
        }
        public string Eliminar(string identificacion)
        {
            try
            {
                _conexion.Open();
                var usuario = _repositorio.BuscarPorIdentificacion(identificacion);
                if (usuario != null)
                {
                    _repositorio.Eliminar(usuario);
                    _conexion.Close();
                    return ($"El registro {usuario.UsuarioNombre} se ha eliminado satisfactoriamente.");
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
            finally { _conexion.Close(); }

        }
        public Usuario BuscarxIdentificacion(string identificacion)
        {
            _conexion.Open();
            Usuario usuario = _repositorio.BuscarPorIdentificacion(identificacion);
            _conexion.Close();
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
