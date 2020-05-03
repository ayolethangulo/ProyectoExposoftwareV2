using System;
using Datos;
using Entity;
using System.Collections.Generic;

namespace Logica
{
    public class AsignaturaService
    {
      private readonly ConnectionManager _conexion;
        private readonly AsignaturaRepository _repositorio;

        public AsignaturaService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new AsignaturaRepository(_conexion);
        }
        
        public GuardarAsignaturaResponse Guardar(Asignatura asignatura)
        {
            try
            {
                _conexion.Open();
                _repositorio.Guardar(asignatura);
                _conexion.Close();
                return new GuardarAsignaturaResponse(asignatura);
            }
            catch (Exception e)
            {
                return new GuardarAsignaturaResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }
        public List<Asignatura> ConsultarTodos()
        {
            _conexion.Open();
            List<Asignatura> asignaturas = _repositorio.ConsultarTodos();
            _conexion.Close();
            return asignaturas;
        }
        public string Eliminar(string id)
        {
            try
            {
                _conexion.Open();
                var asignatura = _repositorio.BuscarPorId(id);
                if (asignatura != null)
                {
                    _repositorio.Eliminar(asignatura);
                    _conexion.Close();
                    return ($"El registro se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { _conexion.Close(); }

        }
        public Asignatura BuscarxId(string id)
        {
            _conexion.Open();
            Asignatura asignatura = _repositorio.BuscarPorId(id);
            _conexion.Close();
            return asignatura;
        }

    }
     public class GuardarAsignaturaResponse 
    {
        public GuardarAsignaturaResponse(Asignatura asignatura)
        {
            Error = false;
            Asignatura = asignatura;
        }
        public GuardarAsignaturaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Asignatura Asignatura { get; set; }

    }
}