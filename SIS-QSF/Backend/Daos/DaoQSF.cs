using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//referencia para usar los metodos mysql
using Backend.Clases;

namespace Backend.Daos
{
    public class DaoQSF
    {
        public void InsertarQSF(QSF qsf)
        {
            try
            {
                string strSQL = "insert into qsf(ClaveQSF,Fecha,Prioridad,Estatus,Tipo_Servicio,Departamento,Descripcion,Observaciones,UsuarioSolicitante)" +
                                "values (null,@Fecha,@Prioridad,@Estatus,@TipoServicio,@Departamento,@Descripcion,@Observaciones,@UsuarioSolicitante)";//consulta sql que va a realizarse
                MySqlCommand comando = new MySqlCommand(strSQL, Conexión.ObtenerConexion());//asigna la consulta y la conexion a la variable comando
                comando.Parameters.AddWithValue("@Fecha", qsf.Fecha);
                comando.Parameters.AddWithValue("@Prioridad", qsf.Prioridad);
                comando.Parameters.AddWithValue("@Estatus", qsf.Estatus);
                comando.Parameters.AddWithValue("@TipoServicio", qsf.TipoServicio);
                comando.Parameters.AddWithValue("@Departamento", qsf.Departamento);
                comando.Parameters.AddWithValue("@Descripcion", qsf.Descripcion);
                comando.Parameters.AddWithValue("@Observaciones", qsf.Observaciones);
                comando.Parameters.AddWithValue("@UsuarioSolicitante", qsf.UsuarioSolicitante);//parametrisa las variables de comando, asignandoles los valores que la pagina web envio
                comando.ExecuteNonQuery();//ejecuta el comando sql
                comando.Dispose();//libera el comando utilizado
                Conexión.ObtenerConexion().Close();//cierra conexion
                Conexión.ObtenerConexion().Dispose();//libera la variable de conexion
            }
            catch (Exception)
            {
                throw;//arroja un error si no se puede hacer la consulta sql
            }
        }// metodo usado para insertar los datos de la qsf en mysql, recibe los atributos de una qsf como parametros
    }
}
