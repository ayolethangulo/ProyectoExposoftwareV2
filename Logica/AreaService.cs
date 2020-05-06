using System;
using Datos;
using Entity;
using System.Collections.Generic;
namespace Logica
{
    public class AreaService
    {
        private readonly ConnectionManager _conexion;
        private readonly AreaRepository _repositorio;

        public AreaService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new AreaRepository(_conexion);
        }
        
        public GuardarAreaResponse Guardar(Area area)
        {
            try
            {
                 var areaBuscada = this.BuscarxId(area.IdArea);
                if (areaBuscada!= null)
                {
                    return new GuardarAreaResponse("Error el area ya se encuentra registrada");
                }
                _conexion.Open();
                _repositorio.Guardar(area);
                _conexion.Close();
                return new GuardarAreaResponse(area);
            }
            catch (Exception e)
            {
                return new GuardarAreaResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }
        public List<Area> ConsultarTodos()
        {
            _conexion.Open();
            List<Area> areas = _repositorio.ConsultarTodos();
            _conexion.Close();
            return areas;
        }
        public string Eliminar(string id)
        {
            try
            {
                _conexion.Open();
                var area = _repositorio.BuscarPorId(id);
                if (area != null)
                {
                    _repositorio.Eliminar(area);
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
        public Area BuscarxId(string id)
        {
            _conexion.Open();
            Area area = _repositorio.BuscarPorId(id);
            _conexion.Close();
            return area;
        }

    }
     public class GuardarAreaResponse 
    {
        public GuardarAreaResponse(Area area)
        {
            Error = false;
            Area = area;
        }
        public GuardarAreaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Area Area { get; set; }

    }
        
    
}