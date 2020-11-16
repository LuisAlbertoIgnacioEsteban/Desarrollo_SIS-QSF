using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//referencia para usar los metodos mysql
using Backend.Clases;
using System.Data;

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
                MySqlCommand comando = new MySqlCommand(strSQL, Conexion.ObtenerConexion());//asigna la consulta y la conexion a la variable comando
                comando.Parameters.AddWithValue("@nocontrol", usuario.NoControl);
                comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@alumno", usuario.EsAlumno);
                comando.Parameters.AddWithValue("@telefono", usuario.Telefono);
                comando.Parameters.AddWithValue("@correo", usuario.Correo);//parametrisa las variables de comando, asignandoles los valores que la pagina web envio
                comando.ExecuteNonQuery();//ejecuta el comando sql
                comando.Dispose();//libera el comando utilizado
                Conexion.ObtenerConexion().Close();//cierra conexion
                Conexion.ObtenerConexion().Dispose();//libera la variable de conexion
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
                MySqlCommand comando = new MySqlCommand(strSQL, Conexion.ObtenerConexion());//asigna la consulta y la conexion a la variable comando
                comando.Parameters.AddWithValue("@nombre", nombre);//parametrisa la variable de comando, asignandole el valor que la pagina web envio
                comando.ExecuteNonQuery();//ejecuta el comando sql
                MySqlDataReader reader = comando.ExecuteReader();//crea un lector y lo ejecuta
                while (reader.Read())//empieza a leer las filas que muestra la consulta sql 
                {
                    clave = reader.GetInt16(0);//asigna el valor de la columna que muestra la consulta
                }
                comando.Dispose();//libera el comando utilizado
                Conexion.ObtenerConexion().Close();//cierra conexion
                Conexion.ObtenerConexion().Dispose();//libera la variable de conexion
                return clave;//devuelve la lista con todos los valores que tiene
            }
            catch (Exception)
            {
                throw;//arroja un error si no se puede hacer la consulta sql
            }
        }// metodo usado para obtener la clave del usuario que realizo la qsf actualmente, recibe 1 parametro

        public DataTable ObtenerSolicitudesUsuario(string Usuario)//metodo que obtiene la informacion de las solicitudes del usuario
        {
            MySqlDataAdapter mda = null;//se crea un adapatador
            DataTable ds = null;//VARIABLE TIPO TABLA PARA ALMACENAR Y RETORNARLA
            try
            {
                ds = new DataTable("La tabla");//ASIGNACION A LA VARIABLE

                string strSQL = "select usuarios.Nombre, usuarios.NoControl, usuarios.Telefono, usuarios.Correo," +
                    " usuarios.EsAlumno, qsf.Tipo_Servicio, qsf.Prioridad, qsf.Estatus, qsf.Fecha, qsf.Descripcion " +
                    "from usuarios inner join qsf on usuarios.ClaveUsuario = qsf.UsuarioSolicitante where usuarios.Nombre=@Usuario limit 1;";
                //consulta sql que va a realizarse
                MySqlCommand comando = new MySqlCommand(strSQL, Conexion.ObtenerConexion());//ASIGNACION DE SCRIP Y CONEXION A LA BASE DE DATOS
                comando.Parameters.AddWithValue("@Usuario", Usuario);//se asignan los parametros al script
                mda = new MySqlDataAdapter(comando);//se ejecuta el comando
                mda.Fill(ds);//se asigna la tabla
                comando.Dispose();//libera el comando
            }
            catch (Exception io)
            {

            }
            finally
            {
                // Cerramos la conexión
                Conexion.ObtenerConexion().Close();
                Conexion.ObtenerConexion().Dispose();
            }
            return ds;//RETORNO DE LA TABLA
        }

    }
}
