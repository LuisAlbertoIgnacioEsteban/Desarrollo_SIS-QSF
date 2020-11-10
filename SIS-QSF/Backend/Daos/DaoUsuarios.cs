using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//referencia para usar los metodos mysql
using Backend.Clases;

namespace Backend.Daos
{
    public class DaoUsuarios
    {
        public void InsertarUsuario(Usuario usuario)
        {
            try
            {
                string strSQL = "insert into usuarios(ClaveUsuario,NoControl,Nombre,EsAlumno,Telefono,Correo)" +
                                "values (null,@nocontrol,@nombre,@alumno,@telefono,@correo)";//consulta sql que va a realizarse
                MySqlCommand comando = new MySqlCommand(strSQL, Conexión.ObtenerConexion());//asigna la consulta y la conexion a la variable comando
                comando.Parameters.AddWithValue("@nocontrol", usuario.NoControl);
                comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@alumno", usuario.EsAlumno);
                comando.Parameters.AddWithValue("@telefono", usuario.Telefono);
                comando.Parameters.AddWithValue("@correo", usuario.Correo);//parametrisa las variables de comando, asignandoles los valores que la pagina web envio
                comando.ExecuteNonQuery();//ejecuta el comando sql
                comando.Dispose();//libera el comando utilizado
                Conexión.ObtenerConexion().Close();//cierra conexion
                Conexión.ObtenerConexion().Dispose();//libera la variable de conexion
            }
            catch (Exception)
            {
                throw;//arroja un error si no se puede hacer la consulta sql
            }
        }// metodo usado para insertar un usuario en mysql, recibe los atributos de un usuario como parametros

        public int ObtenerClaveUsuario(string nombre)
        {
            try
            {
                int clave = 0;//se crea una variable numerica
                string strSQL = "select ClaveUsuario from usuarios where Nombre=@nombre";//consulta sql que va a realizarse
                MySqlCommand comando = new MySqlCommand(strSQL, Conexión.ObtenerConexion());//asigna la consulta y la conexion a la variable comando
                comando.Parameters.AddWithValue("@nombre", nombre);//parametrisa la variable de comando, asignandole el valor que la pagina web envio
                comando.ExecuteNonQuery();//ejecuta el comando sql
                MySqlDataReader reader = comando.ExecuteReader();//crea un lector y lo ejecuta
                while (reader.Read())//empieza a leer las filas que muestra la consulta sql 
                {
                    clave = reader.GetInt16(0);//asigna el valor de la columna que muestra la consulta
                }
                comando.Dispose();//libera el comando utilizado
                Conexión.ObtenerConexion().Close();//cierra conexion
                Conexión.ObtenerConexion().Dispose();//libera la variable de conexion
                return clave;//devuelve la lista con todos los valores que tiene
            }
            catch (Exception)
            {
                throw;//arroja un error si no se puede hacer la consulta sql
            }
        }// metodo usado para obtener la clave del usuario que realizo la qsf actualmente, recibe 1 parametro

    }
}
