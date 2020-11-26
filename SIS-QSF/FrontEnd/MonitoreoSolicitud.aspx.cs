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



        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                Response.Write("<script>alert('Falta llenar el campo obligatorio *')</script>");
            }// se comprueba si el campo esta vacio, si lo esta manda mensaje, sino prosigue
            else
            {
                DataTable tabla;
                Usuario us = new Usuario();
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

        protected void Btnatras_Click(object sender, EventArgs e)
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
                    DataTable tabla2;
                    Usuario us2 = new Usuario();
                    tabla2 = us2.ObtenerAnterior(Convert.ToInt16(lblclaveqsf.Text), txtnombre.Text);// asignacion de la tabla a la variable
                    if (tabla2.Rows.Count == 0)
                    {
                        Response.Write("<script>alert('Esta es la solicitud más reciente')</script>");
                    }
                    else
                    {
                        lblclaveusuario.Text = "" + tabla2.Rows[0]["ClaveUsuario"];// se obtienen los valores de la tabla y se asignan a las etiquetas
                        lblNombre.Text = "" + tabla2.Rows[0]["Nombre"];
                        lblNoc.Text = "" + tabla2.Rows[0]["NoControl"];
                        lblTelefono.Text = "" + tabla2.Rows[0]["Telefono"];
                        lblCorreo.Text = "" + tabla2.Rows[0]["Correo"];
                        lblEsal.Text = "" + tabla2.Rows[0]["EsAlumno"];
                        lblclaveqsf.Text = "" + tabla2.Rows[0]["ClaveQSF"];
                        lblFecha.Text = "" + tabla2.Rows[0]["Fecha"];
                        lblTipoServ.Text = "" + tabla2.Rows[0]["Tipo_Servicio"];
                        lbldepartamento.Text = "" + tabla2.Rows[0]["Departamento"];
                        lblPrio.Text = "" + tabla2.Rows[0]["Prioridad"];
                        lblestatus.Text = "" + tabla2.Rows[0]["Estatus"];
                        lblDescrip.Text = "" + tabla2.Rows[0]["Descripcion"];
                        lblobservaciones.Text = "" + tabla2.Rows[0]["Observaciones"];
                    }
                }
            }
        }

        protected void Btnadelante_Click(object sender, EventArgs e)
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
                    DataTable tabla3;
                    Usuario us3 = new Usuario();
                    tabla3 = us3.ObtenerSiguiente(Convert.ToInt16(lblclaveqsf.Text), txtnombre.Text);// asignacion de la tabla a la variable
                    if (tabla3.Rows.Count == 0)
                    {
                        Response.Write("<script>alert('No hay más solicitudes por ver')</script>");
                    }
                    else
                    {
                        lblclaveusuario.Text = "" + tabla3.Rows[0]["ClaveUsuario"];// se obtienen los valores de la tabla y se asignan a las etiquetas
                        lblNombre.Text = "" + tabla3.Rows[0]["Nombre"];
                        lblNoc.Text = "" + tabla3.Rows[0]["NoControl"];
                        lblTelefono.Text = "" + tabla3.Rows[0]["Telefono"];
                        lblCorreo.Text = "" + tabla3.Rows[0]["Correo"];
                        lblEsal.Text = "" + tabla3.Rows[0]["EsAlumno"];
                        lblclaveqsf.Text = "" + tabla3.Rows[0]["ClaveQSF"];
                        lblFecha.Text = "" + tabla3.Rows[0]["Fecha"];
                        lblTipoServ.Text = "" + tabla3.Rows[0]["Tipo_Servicio"];
                        lbldepartamento.Text = "" + tabla3.Rows[0]["Departamento"];
                        lblPrio.Text = "" + tabla3.Rows[0]["Prioridad"];
                        lblestatus.Text = "" + tabla3.Rows[0]["Estatus"];
                        lblDescrip.Text = "" + tabla3.Rows[0]["Descripcion"];
                        lblobservaciones.Text = "" + tabla3.Rows[0]["Observaciones"];
                    }
                }
            }
        }
    }
}