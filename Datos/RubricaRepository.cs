using System;
using Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class RubricaRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Rubrica> _rubricas = new List<Rubrica>();
        private readonly List<ItemsRubrica> _itemsrubricas = new List<ItemsRubrica>();
        
        public RubricaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        
        public void Guardar(Rubrica rubrica)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Rubrica (IdRubrica,IdArea) values (@IdRubrica, @IdArea)";
                command.Parameters.AddWithValue("@IdRubrica", rubrica.IdRubrica);
                command.Parameters.AddWithValue("@IdArea", rubrica.IdArea);
                var filas = command.ExecuteNonQuery();
            }
        }

        public void GuardarItem(ItemsRubrica item)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into ItemsRubrica (IdRubrica,Item,Descripcion) values (@IdRubrica, @Item,@Descripcion)";
                command.Parameters.AddWithValue("@IdRubrica", item.IdRubrica);
                command.Parameters.AddWithValue("@Item", item.Item);
                command.Parameters.AddWithValue("@Descripcion", item.Descripcion);
                var filas = command.ExecuteNonQuery();
            }
        }

        public void Eliminar(Rubrica rubrica)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Rubrica where IdRubrica=@IdRubrica";
                command.Parameters.AddWithValue("@IdRubrica", rubrica.IdRubrica);
                command.ExecuteNonQuery();
            }
        }
        public void EliminarItem(string id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from ItemsRubrica where IdRubrica=@IdRubrica";
                command.Parameters.AddWithValue("@IdRubrica", id);
                command.ExecuteNonQuery();
            }
        }
        public void Modificar( Rubrica rubrica)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "update Rubrica set idRubrica=@IdRubrica, idArea=@IdArea where IdRubrica=@IdRubrica";
                command.Parameters.AddWithValue("@IdRubrica", rubrica.IdRubrica);
                command.Parameters.AddWithValue("@IdArea", rubrica.IdArea);
                command.ExecuteNonQuery();
            }
        }
        public void ModificarItem(ItemsRubrica item)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "update ItemsRubrica set idRubrica=@IdRubrica, item=@Item, descripcion=@Descripcion where IdRubrica=@IdRubrica";
                command.Parameters.AddWithValue("@IdRubrica", item.IdRubrica);
                command.Parameters.AddWithValue("@Item", item.Item);
                command.Parameters.AddWithValue("@Descripcion", item.Descripcion);
                command.ExecuteNonQuery();
            }
        }
        public List<Rubrica> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Rubrica> rubricas = new List<Rubrica>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Rubrica";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Rubrica rubrica = DataReaderMapToRubrica(dataReader);
                        rubricas.Add(rubrica);
                    }
                }
            }
            return rubricas;
        }

        public List<ItemsRubrica> ConsultarTodosItem()
        {
            SqlDataReader dataReader;
            List<ItemsRubrica> items = new List<ItemsRubrica>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from ItemsRubrica";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ItemsRubrica item = DataReaderMapToItem(dataReader);
                        items.Add(item);
                    }
                }
            }
            return items;
        }

        public Rubrica BuscarPorId(string id)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Rubrica where IdRubrica=@IdRubrica";
                command.Parameters.AddWithValue("@IdRubrica", id);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToRubrica(dataReader);
            }
        }
        private Rubrica DataReaderMapToRubrica(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Rubrica rubrica = new Rubrica();
            rubrica.IdRubrica = (string)dataReader["IdRubrica"];
            rubrica.IdArea = (string)dataReader["IdArea"];
            return rubrica;
        }

        private ItemsRubrica DataReaderMapToItem(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            ItemsRubrica item = new ItemsRubrica();
            item.IdRubrica = (string)dataReader["IdRubrica"];
            item.Item = (string)dataReader["Item"];
            item.Descripcion = (string)dataReader["Descripcion"];
            return item;
        }
        
    }
}