using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Daos;
using System.Data;//referencia para usar los metodos data

namespace Backend.Clases
{
    public class Usuario
    {
        public int ClaveUsuario { get; set; }// geters y seters de cada atributo de la clase Usuario, para asignar u obtener datos
        public string NoControl { get; set; }
        public string Nombre { get; set; }
        public string EsAlumno { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        // Creación de objetos para poder acceder a ellos y enlazar los atributos
        DaoUsuarios du = new DaoUsuarios();

        // Método que nos permite enlazar los atributos para poder insertar un registro en la BD
        public bool Insertar(Usuario us)
        {
            return du.InsertarUsuario(us);
        }

        // Método que nos permite enlazar los atributos para poder obtener la clave del usuario que acaba de solicitar la QSF
        public int ObtenerClave(string nombre)
        {
            return du.ObtenerClaveUsuario(nombre);
        }

        public DataTable ObtenerSolicitudes(string nombre)
        {
            return du.ObtenerSolicitudesUsuario(nombre);
        }

        public DataTable ObtenerSiguiente(int clave, string nombre)
        {
            return du.ObtenerSolicitudSiguiente(clave, nombre);
        }

        public DataTable ObtenerAnterior(int clave, string nombre)
        {
            return du.ObtenerSolicitudAnterior(clave, nombre);
        }
    }
}
