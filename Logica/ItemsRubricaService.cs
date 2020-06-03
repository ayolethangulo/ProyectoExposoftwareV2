using System;
using Datos;
using Entity;
using System.Collections.Generic;

namespace Logica
{
    public class ItemsRubricaService
    {
        private readonly ConnectionManager _conexion;
        private readonly ItemsRubricaRepository _repositorio;

        public ItemsRubricaService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new ItemsRubricaRepository(_conexion);
        }

        public GuardarItemsRubricaResponse Guardar(ItemsRubrica item)
        {
            try
            {
                _conexion.Open();
                _repositorio.Guardar(item);
                _conexion.Close();
                return new GuardarItemsRubricaResponse(item);
            }
            catch (Exception e)
            {
                return new GuardarItemsRubricaResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public List<ItemsRubrica> ConsultarTodos(string id)
        {
            _conexion.Open();
            List<ItemsRubrica> items = _repositorio.ConsultarTodos(id);
            _conexion.Close();
            return items;
        }

        public string Eliminar(string id)
        {
            try
            {
                _conexion.Open();
                _repositorio.Eliminar(id);
                _conexion.Close();
                return ($"El registro se ha eliminado satisfactoriamente.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { _conexion.Close(); }

        }
        public string Modificar(ItemsRubrica itemNueva)
        {
            try
            {
                _conexion.Open();
                _repositorio.Modificar(itemNueva);
                _conexion.Close();
                return ($"El registro {itemNueva.IdRubrica} se ha modificado satisfactoriamente.");
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { _conexion.Close(); }
        }

    }
    public class GuardarItemsRubricaResponse
    {
        public GuardarItemsRubricaResponse(ItemsRubrica item)
        {
            Error = false;
            ItemsRubrica = item;
        }
        public GuardarItemsRubricaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public ItemsRubrica ItemsRubrica { get; set; }

    }
}