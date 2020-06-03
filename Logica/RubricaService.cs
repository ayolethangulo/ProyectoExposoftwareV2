using System;
using Datos;
using Entity;
using System.Collections.Generic;

namespace Logica
{
    public class RubricaService
    {
        private readonly ConnectionManager _conexion;
        private readonly RubricaRepository _repositorio;

        public RubricaService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new RubricaRepository(_conexion);
        }

        public GuardarRubricaResponse Guardar(Rubrica rubrica)
        {
            try
            {
                var rubricaBuscada = this.BuscarxId(rubrica.IdRubrica);
                var areaBuscada = this.BuscarxArea(rubrica.IdArea);
                if (rubricaBuscada != null)
                {
                    return new GuardarRubricaResponse("Error el codigo de la rúbrica ya se encuentra registrada");
                }
                else if (areaBuscada != null)
                {
                    return new GuardarRubricaResponse("Error el area ya tiene una rubrica registrada");
                }
                else
                {
                    _conexion.Open();
                    _repositorio.Guardar(rubrica);
                    _conexion.Close();
                    return new GuardarRubricaResponse(rubrica);
                }
            }
            catch (Exception e)
            {
                return new GuardarRubricaResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public List<Rubrica> ConsultarTodos()
        {
            _conexion.Open();
            List<Rubrica> rubricas = _repositorio.ConsultarTodos();
            _conexion.Close();
            return rubricas;
        }
        public string Eliminar(string id)
        {
            try
            {
                _conexion.Open();
                var rubrica = _repositorio.BuscarPorId(id);
                if (rubrica != null)
                {
                    _repositorio.Eliminar(rubrica);
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
        public string Modificar(Rubrica rubricaNueva)
        {
            try
            {
                _conexion.Open();
                var rubricaVieja = _repositorio.BuscarPorId(rubricaNueva.IdRubrica);
                if (rubricaVieja != null)
                {
                    _repositorio.Modificar(rubricaNueva);
                    _conexion.Close();
                    return ($"El registro {rubricaNueva.IdRubrica} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {rubricaNueva.IdRubrica} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { _conexion.Close(); }

        }

        public Rubrica BuscarxId(string id)
        {
            _conexion.Open();
            Rubrica rubrica = _repositorio.BuscarPorId(id);
            _conexion.Close();
            return rubrica;
        }

        public Rubrica BuscarxArea(string idArea)
        {
            _conexion.Open();
            Rubrica rubrica = _repositorio.BuscarPorArea(idArea);
            _conexion.Close();
            return rubrica;
        }

    }
    public class GuardarRubricaResponse
    {
        public GuardarRubricaResponse(Rubrica rubrica)
        {
            Error = false;
            Rubrica = rubrica;
        }
        public GuardarRubricaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Rubrica Rubrica { get; set; }

    }

}