using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Clases;
using Backend.Daos;

namespace FrontEnd
{
    public partial class LlenadoSolicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        Usuario usuario = new Usuario();//instancia de la clase Usuario
        QSF qsf = new QSF();// instancia de la clase QSF
        DateTime fecha = DateTime.Now;//asignacion de la variable de la fecha actual


        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                usuario.Nombre = txtnombre.Text;//asignaciones de las cajas de texto a cada atributo de la lista Usuario
                usuario.Telefono = txttelefono.Text;
                usuario.Correo = txtcorreo.Text;
                usuario.NoControl = txtnocontrol.Text;
                usuario.EsAlumno = rblalumno.SelectedItem.Text;
                if (usuario.Telefono == "")//asignaciones de un - como valor si se dejan cajas de texto vacias
                {
                    usuario.Telefono = "-";
                }
                if (usuario.Correo == "")
                {
                    usuario.Correo = "-";
                }
                if (usuario.NoControl == "")
                {
                    usuario.NoControl = "-";
                }
                qsf.Fecha = fecha.ToString("yyyy-MM-dd");//se establece el formato para la fecha actual
                qsf.Prioridad = "Baja";//asignaciones de las cajas de texto a cada atributo de la lista QSF
                qsf.Estatus = "No iniciada";
                qsf.TipoServicio = rblservicio.SelectedItem.Text;
                qsf.Departamento = "Calidad";
                qsf.Descripcion = txtdescripcion.Text;
                qsf.Observaciones = "-";//valor inicial de este campo
                usuario.Insertar(usuario);//llamada del metodo insertar usuario
                qsf.UsuarioSolicitante = usuario.ObtenerClave(usuario.Nombre).ToString();//llamada del metodo para obtener la claveusuario
                qsf.Insertar(qsf);//llamada del metodo insertar qsf
                txtnombre.Text = "";
                txtcorreo.Text = "";
                txttelefono.Text = "";
                txtnocontrol.Text = "";
                txtdescripcion.Text = "";
                rblservicio.SelectedIndex = -1;
                rblalumno.SelectedIndex = -1;
                
            }//compara si los campos obligatorios estan vacios, si lo estan manda un mensaje, sino realiza el proceso de insertar
        }
    }
}