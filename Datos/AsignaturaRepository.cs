using System;
using Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class AsignaturaRepository
    {
         private readonly SqlConnection _connection;
        private readonly List<Asignatura> _asignaturas = new List<Asignatura>();
        
        public AsignaturaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        
        public void Guardar(Asignatura asignatura)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Asignatura (IdAsignatura,Nombre, IdArea) values (@IdAsignatura, @Nombre, @IdArea)";
                command.Parameters.AddWithValue("@IdAsignatura", asignatura.IdAsignatura);
                command.Parameters.AddWithValue("@Nombre", asignatura.Nombre);
                command.Parameters.AddWithValue("@IdArea", asignatura.IdArea);
                var filas = command.ExecuteNonQuery();
            }
        }
        public void Eliminar(Asignatura asignatura)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Asignatura where IdAsignatura=@IdAsignatura";
                command.Parameters.AddWithValue("@IdAsignatura", asignatura.IdAsignatura);
                command.ExecuteNonQuery();
            }
        }
        public List<Asignatura> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Asignatura> asignaturas = new List<Asignatura>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Asignatura";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Asignatura asignatura = DataReaderMapToPerson(dataReader);
                        asignaturas.Add(asignatura);
                    }
                }
            }
            return asignaturas;
        }
        public Asignatura BuscarPorId(string id)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Asignatura where IdAsignatura=@IdAsignatura";
                command.Parameters.AddWithValue("@IdAsignatura", id);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }
        private Asignatura DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Asignatura asignatura = new Asignatura();
            asignatura.IdAsignatura = (string)dataReader["IdAsignatura"];
            asignatura.Nombre = (string)dataReader["Nombre"];
            asignatura.IdArea = (string)dataReader["IdArea"];
            return asignatura;
        }
    }
        
}
