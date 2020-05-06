using System;
using Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
namespace Datos
{
    public class AreaRepository
    {
         private readonly SqlConnection _connection;
        private readonly List<Area> _areas = new List<Area>();
        
        public AreaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        
        public void Guardar(Area area)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Area (IdArea,Nombre) values (@IdArea, @Nombre)";
                command.Parameters.AddWithValue("@IdArea", area.IdArea);
                command.Parameters.AddWithValue("@Nombre", area.Nombre);
                var filas = command.ExecuteNonQuery();
            }
        }
        public void Eliminar(Area area)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Area where IdArea=@IdArea";
                command.Parameters.AddWithValue("@IdArea", area.IdArea);
                command.ExecuteNonQuery();
            }
        }
        public List<Area> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Area> areas = new List<Area>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Area ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Area area = DataReaderMapToPerson(dataReader);
                        areas.Add(area);
                    }
                }
            }
            return areas;
        }
        public Area BuscarPorId(string id)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Area where IdArea=@IdArea";
                command.Parameters.AddWithValue("@IdArea", id);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }
        private Area DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Area area = new Area();
            area.IdArea = (string)dataReader["IdArea"];
            area.Nombre = (string)dataReader["Nombre"];
            return area;
        }
    }
}