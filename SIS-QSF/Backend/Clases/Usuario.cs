﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Daos;

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
        public void Insertar(Usuario us)
        {
            du.InsertarUsuario(us);
        }

        // Método que nos permite enlazar los atributos para poder obtener la clave del usuario que acaba de solicitar la QSF
        public int ObtenerClave(string nombre)
        {
            return du.ObtenerClaveUsuario(nombre);
        }

    }
}