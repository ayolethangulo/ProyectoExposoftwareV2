using System;
using Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class ItemsRubricaRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<ItemsRubrica> _itemsrubricas = new List<ItemsRubrica>();    

        public ItemsRubricaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }  

         public void Guardar(ItemsRubrica item)
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

         public void Eliminar(string id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from ItemsRubrica where IdRubrica=@IdRubrica";
                command.Parameters.AddWithValue("@IdRubrica", id);
                command.ExecuteNonQuery();
            }
        }
         public void Modificar(ItemsRubrica item)
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
         public List<ItemsRubrica> ConsultarTodos(string id)
        {
            SqlDataReader dataReader;
            List<ItemsRubrica> items = new List<ItemsRubrica>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from ItemsRubrica where IdRubrica=@IdRubrica";
                command.Parameters.AddWithValue("@IdRubrica", id);
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