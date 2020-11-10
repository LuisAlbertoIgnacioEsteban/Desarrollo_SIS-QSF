using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Backend.Clases;

namespace Backend.Daos
{
    class DaoAdministrador
    {
        public bool verificarAdmin(Administrador admin)
        {
            bool existeUsuario = false;
            string strSQL = "SELECT Nombre_usuario, Clave_usuario FROM administrador WHERE Nombre_usuario = @usuario  AND Clave_usuario = sha1(@pass)";//consulta sql que va a realizarse
            MySqlCommand comando = new MySqlCommand(strSQL, Conexión.ObtenerConexion());//asigna la consulta y la conexion a la variable comando
            comando.Parameters.AddWithValue("@usuario", admin.NombreUsuario);//parametrisa la variable de comando, asignandole el valor que la pagina web envio
            comando.Parameters.AddWithValue("@pass", admin.ClaveUsuario);
            comando.ExecuteNonQuery();//ejecuta el comando sql
            MySqlDataReader reader = comando.ExecuteReader();//crea un lector y lo ejecuta
            if (reader.Read())
            {
                existeUsuario = true;
            }
            comando.Dispose();//libera el comando utilizado
            Conexión.ObtenerConexion().Close();//cierra conexion
            Conexión.ObtenerConexion().Dispose();//libera la variable de conexion
            return existeUsuario;
        }
    }
}
