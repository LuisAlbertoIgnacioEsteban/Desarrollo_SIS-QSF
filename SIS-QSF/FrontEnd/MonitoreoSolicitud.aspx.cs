using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;//referencia para usar los metodos data
using Backend.Clases;

namespace FrontEnd
{
    public partial class MonitoreoSolicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public DataTable tabla;// se crea una variable tipo tabla, ya que el web service nos devolvera una tabla como resultado

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                Response.Write("<script>alert('Falta llenar el campo obligatorio *')</script>");
            }// se comprueba si el campo esta vacio, si lo esta manda mensaje, sino prosigue
            else
            {
                Usuario us = new Usuario();
                tabla = us.ObtenerSolicitudes(txtnombre.Text);// asignacion de la tabla del web service a la variable
                lblNombre.Text = "" + tabla.Rows[0]["Nombre"];// se obtienen los valores de la tabla y se asignan a las etiquetas
                lblTelefono.Text = "" + tabla.Rows[0]["Telefono"];
                lblNoc.Text = "" + tabla.Rows[0]["NoControl"];
                lblCorreo.Text = "" + tabla.Rows[0]["Correo"];
                lblEsal.Text = "" + tabla.Rows[0]["EsAlumno"];
                lblFecha.Text = "" + tabla.Rows[0]["Fecha"];
                lblTipoServ.Text = "" + tabla.Rows[0]["Tipo_Servicio"];
                lblPrio.Text = "" + tabla.Rows[0]["Prioridad"];
                lblestatus.Text = "" + tabla.Rows[0]["Estatus"];
                lblDescrip.Text = "" + tabla.Rows[0]["Descripcion"];
            }
        }
    }
}