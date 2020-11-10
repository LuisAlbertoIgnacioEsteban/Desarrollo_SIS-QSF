using Backend.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Clases
{
    public class Administrador
    {
        public string NombreUsuario { get; set; }// geters y seters de cada atributo de la clase Usuario, para asignar u obtener datos
        public string ClaveUsuario { get; set; }

        DaoAdministrador daoAdministrador = new DaoAdministrador();

        public bool verificarAdmin(Administrador admin)
        {
            return daoAdministrador.verificarAdmin(admin);
        }
    }
}
