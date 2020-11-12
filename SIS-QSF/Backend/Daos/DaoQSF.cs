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


        public List<QSF> getAll()
        {
            List<QSF> qsf = new List<QSF>();
            MySqlConnection con = new Conexión().getConexion();
                try
                {
               
                
                String strSql = "select Prioridad, Estatus, ClaveQSF, Fecha, Tipo_Servicio, Departamento,Descripcion, Observaciones,UsuarioSolicitante from qsf;";

                MySqlCommand comando = new MySqlCommand(strSql, con);

                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                foreach (DataRow fila in tabla.Rows)
                {
                    QSF queja = new QSF();

                    queja.ClaveQSF= int.Parse(fila["ClaveQSF"].ToString());
                    queja.Prioridad = fila["Prioridad"].ToString();
                    queja.Estatus = fila["Estatus"].ToString();
                    queja.Departamento = fila["Departamento"].ToString();
                    queja.TipoServicio = fila["Tipo_Servicio"].ToString();
                    queja.Descripcion = fila["Descripcion"].ToString();
                    queja.Observaciones = fila["Observaciones"].ToString();
                    queja.Fecha = fila["Fecha"].ToString();
                    queja.UsuarioSolicitante = int.Parse(fila["UsuarioSolicitante"].ToString());
                    Console.WriteLine(queja.ClaveQSF+" ");
                    qsf.Add(queja);

                }

                return qsf;
            }
            catch (Exception e)
            {

                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }


        public QSF getOnebyID(String id)
        {
            MySqlConnection con = new Conexión().getConexion();
            
            try
            {
                QSF qsf = new QSF();

                string strSQL = 
                "select Prioridad, Estatus, ClaveQSF, Fecha, Tipo_Servicio, Departamento, Descripcion, Observaciones,UsuarioSolicitante from qsf where ClaveQSF = 1;";
                MySqlCommand comando = new MySqlCommand(strSQL, con);
                comando.Parameters.AddWithValue("@ClaveQSF", id);
                comando.ExecuteNonQuery();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                DataRow row = tabla.Rows[0];

                QSF queja = new QSF();

                queja.ClaveQSF = int.Parse(row["ClaveQSF"].ToString());
                queja.Prioridad = row["Prioridad"].ToString();
                queja.Estatus = row["Estatus"].ToString();
                queja.Departamento = row["Departamento"].ToString();
                queja.TipoServicio = row["TipoServicio"].ToString();
                queja.Descripcion = row["Descripcion"].ToString();
                queja.Observaciones = row["Observaciones"].ToString();
                queja.Fecha = row["Fecha"].ToString();
                queja.UsuarioSolicitante = int.Parse(row["UsuarioSolicitante"].ToString());


                return queja;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

        }

        public bool update(QSF qsf)
        {
            MySqlConnection con = new Conexión().getConexion();
            
            try
            {
                con.Open();

                String sql = "update qsf set Prioridad = @Prioridad, Estatus = @Estatus, " +
                "Fecha = @Fecha' ,Tipo_Servicio = @Tipo_Servicio, " +
                "Departamento = @Departamento,Descripcion = @Descripcion," +
                "Observaciones = @Observaciones, UsuarioSolicitante = @UsuarioSolicitante where ClaveQSF = @ClaveQSF;";


                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("Prioridad",qsf.Prioridad);
                comando.Parameters.AddWithValue("Estatus",qsf.Estatus);
                comando.Parameters.AddWithValue("Fecha",qsf.Fecha);
                comando.Parameters.AddWithValue("Tipo_Servicio", qsf.TipoServicio);
                comando.Parameters.AddWithValue("Departamento", qsf.Departamento);
                comando.Parameters.AddWithValue("Descripcion", qsf.Descripcion);
                comando.Parameters.AddWithValue("Observaciones", qsf.Observaciones);
                comando.Parameters.AddWithValue("UsuarioSolicitante", qsf.UsuarioSolicitante);
                comando.Parameters.AddWithValue("ClaveQSF", qsf.ClaveQSF);

                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e) { return false; }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }


        public bool delete(String clave)
        {
            MySqlConnection con = new Conexión().getConexion();
           
            try
            {
                con.Open();
                String sql = "delete from qsf where ClaveQSF = @ClaveQSF;";

                MySqlCommand comando = new MySqlCommand(sql, con);
                comando.Parameters.AddWithValue("ClaveQSF", clave);
                comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception e) { return false; }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

    }
}
