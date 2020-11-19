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

        public DataTable tabla;
        Usuario us = new Usuario();
        int fila;

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                Response.Write("<script>alert('Falta llenar el campo obligatorio *')</script>");
            }// se comprueba si el campo esta vacio, si lo esta manda mensaje, sino prosigue
            else
            {
                
                tabla = us.ObtenerSolicitudes(txtnombre.Text);// asignacion de la tabla a la variable
                fila = 0;
                lblclaveusuario.Text = "" + tabla.Rows[fila]["ClaveUsuario"];// se obtienen los valores de la tabla y se asignan a las etiquetas
                lblNombre.Text = "" + tabla.Rows[fila]["Nombre"];
                lblNoc.Text = "" + tabla.Rows[fila]["NoControl"];
                lblTelefono.Text = "" + tabla.Rows[fila]["Telefono"]; 
                lblCorreo.Text = "" + tabla.Rows[fila]["Correo"];
                lblEsal.Text = "" + tabla.Rows[fila]["EsAlumno"];
                lblclaveqsf.Text = "" + tabla.Rows[fila]["ClaveQSF"];
                lblFecha.Text = "" + tabla.Rows[fila]["Fecha"];
                lblTipoServ.Text = "" + tabla.Rows[fila]["Tipo_Servicio"];
                lbldepartamento.Text = "" + tabla.Rows[fila]["Departamento"];
                lblPrio.Text = "" + tabla.Rows[fila]["Prioridad"];
                lblestatus.Text = "" + tabla.Rows[fila]["Estatus"];
                lblDescrip.Text = "" + tabla.Rows[fila]["Descripcion"];
                lblobservaciones.Text = "" + tabla.Rows[fila]["Observaciones"];
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            /*if (!txtnombre.Text.Equals(lblNombre.Text))
            {
                Response.Write("<script>alert('El nombre no corresponde con el usuario propietario de las solicitudes')</script>");
            }// se comprueba si el campo esta vacio, si lo esta manda mensaje, sino prosigue
            else
            {
                tabla = us.ObtenerSolicitudes(txtnombre.Text);// asignacion de la tabla a la variable
                fila--;
                Response.Write("<script>alert(" + fila + ")</script>");
                lblclaveusuario.Text = "" + tabla.Rows[fila]["ClaveUsuario"];// se obtienen los valores de la tabla y se asignan a las etiquetas
                lblNombre.Text = "" + tabla.Rows[fila]["Nombre"];
                lblNoc.Text = "" + tabla.Rows[fila]["NoControl"];
                lblTelefono.Text = "" + tabla.Rows[fila]["Telefono"];
                lblCorreo.Text = "" + tabla.Rows[fila]["Correo"];
                lblEsal.Text = "" + tabla.Rows[fila]["EsAlumno"];
                lblclaveqsf.Text = "" + tabla.Rows[fila]["ClaveQSF"];
                lblFecha.Text = "" + tabla.Rows[fila]["Fecha"];
                lblTipoServ.Text = "" + tabla.Rows[fila]["Tipo_Servicio"];
                lbldepartamento.Text = "" + tabla.Rows[fila]["Departamento"];
                lblPrio.Text = "" + tabla.Rows[fila]["Prioridad"];
                lblestatus.Text = "" + tabla.Rows[fila]["Estatus"];
                lblDescrip.Text = "" + tabla.Rows[fila]["Descripcion"];
                lblobservaciones.Text = "" + tabla.Rows[fila]["Observaciones"];
            }*/
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            /*if (!txtnombre.Text.Equals(lblNombre.Text))
            {
                Response.Write("<script>alert('El nombre no corresponde con el usuario propietario de las solicitudes')</script>");
            }// se comprueba si el campo esta vacio, si lo esta manda mensaje, sino prosigue
            else
            {
                tabla = us.ObtenerSolicitudes(txtnombre.Text);// asignacion de la tabla a la variable
                fila++;
                Response.Write("<script>alert("+fila+")</script>");
                lblclaveusuario.Text = "" + tabla.Rows[fila]["ClaveUsuario"];// se obtienen los valores de la tabla y se asignan a las etiquetas
                lblNombre.Text = "" + tabla.Rows[fila]["Nombre"];
                lblNoc.Text = "" + tabla.Rows[fila]["NoControl"];
                lblTelefono.Text = "" + tabla.Rows[fila]["Telefono"];
                lblCorreo.Text = "" + tabla.Rows[fila]["Correo"];
                lblEsal.Text = "" + tabla.Rows[fila]["EsAlumno"];
                lblclaveqsf.Text = "" + tabla.Rows[fila]["ClaveQSF"];
                lblFecha.Text = "" + tabla.Rows[fila]["Fecha"];
                lblTipoServ.Text = "" + tabla.Rows[fila]["Tipo_Servicio"];
                lbldepartamento.Text = "" + tabla.Rows[fila]["Departamento"];
                lblPrio.Text = "" + tabla.Rows[fila]["Prioridad"];
                lblestatus.Text = "" + tabla.Rows[fila]["Estatus"];
                lblDescrip.Text = "" + tabla.Rows[fila]["Descripcion"];
                lblobservaciones.Text = "" + tabla.Rows[fila]["Observaciones"];
            }*/
        }
    }
}