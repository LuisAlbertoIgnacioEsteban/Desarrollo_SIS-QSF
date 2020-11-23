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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                Response.Write("<script>alert('Falta llenar el campo obligatorio *')</script>");
            }// se comprueba si el campo esta vacio, si lo esta manda mensaje, sino prosigue
            else
            {

                tabla = us.ObtenerSolicitudes(txtnombre.Text);// asignacion de la tabla a la variable
                lblclaveusuario.Text = "" + tabla.Rows[0]["ClaveUsuario"];// se obtienen los valores de la tabla y se asignan a las etiquetas
                lblNombre.Text = "" + tabla.Rows[0]["Nombre"];
                lblNoc.Text = "" + tabla.Rows[0]["NoControl"];
                lblTelefono.Text = "" + tabla.Rows[0]["Telefono"];
                lblCorreo.Text = "" + tabla.Rows[0]["Correo"];
                lblEsal.Text = "" + tabla.Rows[0]["EsAlumno"];
                lblclaveqsf.Text = "" + tabla.Rows[0]["ClaveQSF"];
                lblFecha.Text = "" + tabla.Rows[0]["Fecha"];
                lblTipoServ.Text = "" + tabla.Rows[0]["Tipo_Servicio"];
                lbldepartamento.Text = "" + tabla.Rows[0]["Departamento"];
                lblPrio.Text = "" + tabla.Rows[0]["Prioridad"];
                lblestatus.Text = "" + tabla.Rows[0]["Estatus"];
                lblDescrip.Text = "" + tabla.Rows[0]["Descripcion"];
                lblobservaciones.Text = "" + tabla.Rows[0]["Observaciones"];
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                Response.Write("<script>alert('No has ingresado el usuario')</script>");
            }
            else
            {
                if (!txtnombre.Text.Equals(lblNombre.Text))
                {
                    Response.Write("<script>alert('El nombre no corresponde con el usuario propietario de las solicitudes')</script>");
                }// se comprueba si el campo esta vacio, si lo esta manda mensaje, sino prosigue
                else
                {
                    tabla = us.ObtenerAnterior(Convert.ToInt16(lblclaveqsf.Text), txtnombre.Text);// asignacion de la tabla a la variable
                    if (tabla.Rows.Count == 0)
                    {
                        Response.Write("<script>alert('Esta es la solicitud más reciente')</script>");
                    }
                    else
                    {
                        lblclaveusuario.Text = "" + tabla.Rows[0]["ClaveUsuario"];// se obtienen los valores de la tabla y se asignan a las etiquetas
                        lblNombre.Text = "" + tabla.Rows[0]["Nombre"];
                        lblNoc.Text = "" + tabla.Rows[0]["NoControl"];
                        lblTelefono.Text = "" + tabla.Rows[0]["Telefono"];
                        lblCorreo.Text = "" + tabla.Rows[0]["Correo"];
                        lblEsal.Text = "" + tabla.Rows[0]["EsAlumno"];
                        lblclaveqsf.Text = "" + tabla.Rows[0]["ClaveQSF"];
                        lblFecha.Text = "" + tabla.Rows[0]["Fecha"];
                        lblTipoServ.Text = "" + tabla.Rows[0]["Tipo_Servicio"];
                        lbldepartamento.Text = "" + tabla.Rows[0]["Departamento"];
                        lblPrio.Text = "" + tabla.Rows[0]["Prioridad"];
                        lblestatus.Text = "" + tabla.Rows[0]["Estatus"];
                        lblDescrip.Text = "" + tabla.Rows[0]["Descripcion"];
                        lblobservaciones.Text = "" + tabla.Rows[0]["Observaciones"];
                    }
                }
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                Response.Write("<script>alert('No has ingresado el usuario')</script>");
            }
            else
            {
                if (!txtnombre.Text.Equals(lblNombre.Text))
                {
                    Response.Write("<script>alert('El nombre no corresponde con el usuario propietario de las solicitudes')</script>");
                }// se comprueba si el campo esta vacio, si lo esta manda mensaje, sino prosigue
                else
                {
                    tabla = us.ObtenerSiguiente(Convert.ToInt16(lblclaveqsf.Text), txtnombre.Text);// asignacion de la tabla a la variable
                    if (tabla.Rows.Count == 0)
                    {
                        Response.Write("<script>alert('No hay más solicitudes por ver')</script>");
                    }
                    else
                    {
                        lblclaveusuario.Text = "" + tabla.Rows[0]["ClaveUsuario"];// se obtienen los valores de la tabla y se asignan a las etiquetas
                        lblNombre.Text = "" + tabla.Rows[0]["Nombre"];
                        lblNoc.Text = "" + tabla.Rows[0]["NoControl"];
                        lblTelefono.Text = "" + tabla.Rows[0]["Telefono"];
                        lblCorreo.Text = "" + tabla.Rows[0]["Correo"];
                        lblEsal.Text = "" + tabla.Rows[0]["EsAlumno"];
                        lblclaveqsf.Text = "" + tabla.Rows[0]["ClaveQSF"];
                        lblFecha.Text = "" + tabla.Rows[0]["Fecha"];
                        lblTipoServ.Text = "" + tabla.Rows[0]["Tipo_Servicio"];
                        lbldepartamento.Text = "" + tabla.Rows[0]["Departamento"];
                        lblPrio.Text = "" + tabla.Rows[0]["Prioridad"];
                        lblestatus.Text = "" + tabla.Rows[0]["Estatus"];
                        lblDescrip.Text = "" + tabla.Rows[0]["Descripcion"];
                        lblobservaciones.Text = "" + tabla.Rows[0]["Observaciones"];
                    }
                }
            }
        }
    }
}