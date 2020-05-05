using System;
using Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class UsuarioRepository
    {
          private readonly SqlConnection _connection;
        private readonly List<Usuario> _usuarios = new List<Usuario>();
        public UsuarioRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Usuario usuario)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Usuario (Identificacion,Usuario,Contrasena,TipoDocente)"+
                                        "values (@Identificacion,@Usuario,@Contrasena,@TipoDocente)";
                command.Parameters.AddWithValue("@Identificacion", usuario.Identificacion);                        
                command.Parameters.AddWithValue("@Usuario", usuario.UsuarioNombre);
                command.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                command.Parameters.AddWithValue("@TipoDocente", usuario.TipoDocente);
            
                var filas = command.ExecuteNonQuery();
            }
        }

         public void Eliminar(Usuario usuario)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Usuario where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", usuario.Identificacion);
                command.ExecuteNonQuery();
            }
        }
        public List<Usuario> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Usuario> usuarios = new List<Usuario>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Usuario ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Usuario usuario = DataReaderMapToPerson(dataReader);
                        usuarios.Add(usuario);
                    }
                }
            }
            return usuarios;
        }
        public Usuario BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Usuario where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }
        private Usuario DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Usuario usuario = new Usuario();
            usuario.Identificacion = (string)dataReader["Identificacion"];
            usuario.UsuarioNombre = (string)dataReader["UsuarioNombre"];
            usuario.Contrasena = (string)dataReader["Contrasena"];
            usuario.TipoDocente = (string)dataReader["TipoDocente"];
           
            return usuario;
        }


    }
}