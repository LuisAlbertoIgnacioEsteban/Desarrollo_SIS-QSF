using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//referencia para usar los metodos mysql

namespace Backend.Daos
{
    public class Conexión
    {
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = null;//declaramos la variable de conexion
            try
            {
                conectar = new MySqlConnection("server=localhost; database=sisqsf; user=root; pwd='root'");
                //se especifica el servidor, la BD, el usuario y la contraseña de la base de datos a la que nos vamos a conectar
                conectar.Open();
                //se abre la conexion
            }
            catch (Exception)
            {
                throw;//arroja un error si no se puede hacer la conexion
            }
            return conectar;//devuelve la conexion
        }

        public MySqlConnection getConexion()
        {
            MySqlConnection conectar = null;//declaramos la variable de conexion
            try
            {
                conectar = new MySqlConnection("server=localhost; database=sisqsf; user=root; pwd='root'");
                //se especifica el servidor, la BD, el usuario y la contraseña de la base de datos a la que nos vamos a conectar
                conectar.Open();
                //se abre la conexion
            }
            catch (Exception)
            {
                throw;//arroja un error si no se puede hacer la conexion
            }
            return conectar;//devuelve la conexion
        }
    }
}
