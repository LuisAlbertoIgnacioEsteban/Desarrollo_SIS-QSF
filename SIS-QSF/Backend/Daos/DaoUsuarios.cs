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
        public bool InsertarUsuario(Usuario usuario)
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                // Cerramos la conexión
                Conexion.ObtenerConexion().Close();
                Conexion.ObtenerConexion().Dispose();
                
            }
        }// metodo usado para insertar un usuario en mysql, recibe los atributos de un usuario como parametros

        public int ControlUsuarios(string correo)
        {
            try
            {
                int usuario = 0;//se crea una variable numerica
                string strSQL = "select count(*) from usuarios where Correo=@correo";//consulta sql que va a realizarse
                MySqlCommand comando = new MySqlCommand(strSQL, Conexion.ObtenerConexion());//asigna la consulta y la conexion a la variable comando
                comando.Parameters.AddWithValue("@correo", correo);//parametrisa la variable de comando, asignandole el valor que la pagina web envio
                comando.ExecuteNonQuery();//ejecuta el comando sql
                MySqlDataReader reader = comando.ExecuteReader();//crea un lector y lo ejecuta
                while (reader.Read())//empieza a leer las filas que muestra la consulta sql 
                {
                    usuario = reader.GetInt16(0);//asigna el valor de la columna que muestra la consulta
                }
                comando.Dispose();//libera el comando utilizado
                Conexion.ObtenerConexion().Close();//cierra conexion
                Conexion.ObtenerConexion().Dispose();//libera la variable de conexion
                return usuario;//devuelve la lista con todos los valores que tiene
            }
            catch (Exception)
            {
                throw;//arroja un error si no se puede hacer la consulta sql
            }
        }// metodo usado para obtener la clave del usuario que realizo la qsf actualmente, recibe 1 parametro

        public int ObtenerClaveUsuario(string correo)
        {
            try
            {
                int clave = 0;//se crea una variable numerica
                string strSQL = "select ClaveUsuario from usuarios where Correo=@correo";//consulta sql que va a realizarse
                MySqlCommand comando = new MySqlCommand(strSQL, Conexion.ObtenerConexion());//asigna la consulta y la conexion a la variable comando
                comando.Parameters.AddWithValue("@correo", correo);//parametrisa la variable de comando, asignandole el valor que la pagina web envio
                comando.ExecuteNonQuery();//ejecuta el comando sql
                MySqlDataReader reader = comando.ExecuteReader();//crea un lector y lo ejecuta
                while (reader.Read())//empieza a leer las filas que muestra la consulta sql 
                {
                    clave = reader.GetInt16(0);//asigna el valor de la columna que muestra la consulta
                }
                comando.Dispose();//libera el comando utilizado
                Conexion.ObtenerConexion().Close();//cierra conexion
                Conexion.ObtenerConexion().Dispose();//libera la variable de conexion
                return clave;
            }
            catch (Exception)
            {
                throw;//arroja un error si no se puede hacer la consulta sql
            }
        }// metodo usado para obtener la clave del usuario que realizo la qsf actualmente, recibe 1 parametro

        public DataTable ObtenerSolicitudesUsuario(string correo)//metodo que obtiene la informacion de las solicitudes del usuario
        {
            MySqlDataAdapter mda = null;//se crea un adapatador
            DataTable ds = null;//VARIABLE TIPO TABLA PARA ALMACENAR Y RETORNARLA
            try
            {
                ds = new DataTable("La tabla");//ASIGNACION A LA VARIABLE

                string strSQL = "select u.ClaveUsuario, u.Nombre, u.NoControl, u.Telefono, u.Correo, u.EsAlumno," +
                    " q.ClaveQSF, q.Fecha, q.Tipo_Servicio, q.Departamento, q.Prioridad, q.Estatus, q.Descripcion, q.Observaciones " +
                    "from usuarios u join qsf q on u.ClaveUsuario=q.UsuarioSolicitante where u.Correo=@correo order by q.fecha desc, q.ClaveQSF desc;";
                //consulta sql que va a realizarse
                MySqlCommand comando = new MySqlCommand(strSQL, Conexion.ObtenerConexion());//ASIGNACION DE SCRIP Y CONEXION A LA BASE DE DATOS
                comando.Parameters.AddWithValue("@correo", correo);//se asignan los parametros al script
                mda = new MySqlDataAdapter(comando);//se ejecuta el comando


                mda.Fill(ds);//se asigna la tabla
                comando.Dispose();//libera el comando
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // Cerramos la conexión
                Conexion.ObtenerConexion().Close();
                Conexion.ObtenerConexion().Dispose();
            }
            return ds;//RETORNO DE LA TABLA
        }

        public DataTable ObtenerSolicitudSiguiente(int clave, string correo)//metodo que obtiene la siguiente solicitud del usuario
        {
            MySqlDataAdapter mda = null;//se crea un adapatador
            DataTable ds = null;//VARIABLE TIPO TABLA PARA ALMACENAR Y RETORNARLA
            try
            {
                ds = new DataTable("La tabla");//ASIGNACION A LA VARIABLE

                string strSQL = "select u.ClaveUsuario, u.Nombre, u.NoControl, u.Telefono, u.Correo, u.EsAlumno," +
                    " q.ClaveQSF, q.Fecha, q.Tipo_Servicio, q.Departamento, q.Prioridad, q.Estatus, q.Descripcion, q.Observaciones " +
                    "from usuarios u join qsf q on u.ClaveUsuario=q.UsuarioSolicitante where u.Correo=@correo and not q.ClaveQSF=@clave and q.ClaveQSF<@clave order by q.fecha desc, q.ClaveQSF desc limit 1";
                //consulta sql que va a realizarse
                MySqlCommand comando = new MySqlCommand(strSQL, Conexion.ObtenerConexion());//ASIGNACION DE SCRIP Y CONEXION A LA BASE DE DATOS
                comando.Parameters.AddWithValue("@clave", clave);//se asignan los parametros al script
                comando.Parameters.AddWithValue("@correo", correo);//se asignan los parametros al script
                mda = new MySqlDataAdapter(comando);//se ejecuta el comando
                mda.Fill(ds);//se asigna la tabla
                comando.Dispose();//libera el comando
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // Cerramos la conexión
                Conexion.ObtenerConexion().Close();
                Conexion.ObtenerConexion().Dispose();
            }
            return ds;//RETORNO DE LA TABLA
        }

        public DataTable ObtenerSolicitudAnterior(int clave, string correo)//metodo que obtiene la anterior solicitud del usuario
        {
            MySqlDataAdapter mda = null;//se crea un adapatador
            DataTable ds = null;//VARIABLE TIPO TABLA PARA ALMACENAR Y RETORNARLA
            try
            {
                ds = new DataTable("La tabla");//ASIGNACION A LA VARIABLE

                string strSQL = "select u.ClaveUsuario, u.Nombre, u.NoControl, u.Telefono, u.Correo, u.EsAlumno," +
                    " q.ClaveQSF, q.Fecha, q.Tipo_Servicio, q.Departamento, q.Prioridad, q.Estatus, q.Descripcion, q.Observaciones " +
                    "from usuarios u join qsf q on u.ClaveUsuario=q.UsuarioSolicitante where u.Correo=@correo and not q.ClaveQSF=@clave and q.ClaveQSF>@clave order by q.fecha asc, q.ClaveQSF asc limit 1";
                //consulta sql que va a realizarse
                MySqlCommand comando = new MySqlCommand(strSQL, Conexion.ObtenerConexion());//ASIGNACION DE SCRIP Y CONEXION A LA BASE DE DATOS
                comando.Parameters.AddWithValue("@clave", clave);//se asignan los parametros al script
                comando.Parameters.AddWithValue("@correo", correo);//se asignan los parametros al script
                mda = new MySqlDataAdapter(comando);//se ejecuta el comando
                mda.Fill(ds);//se asigna la tabla
                comando.Dispose();//libera el comando
            }
            catch (Exception)
            {
                throw;
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