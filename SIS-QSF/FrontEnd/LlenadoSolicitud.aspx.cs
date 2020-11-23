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
            
            
        }

        Usuario usuario = new Usuario();//instancia de la clase Usuario
        QSF qsf = new QSF();// instancia de la clase QSF
        DateTime fecha = DateTime.Now;//asignacion de la variable de la fecha actual


        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "" || txtdescripcion.Text == "" || (!rbsi.Checked && !rbno.Checked)
                || (!rbqueja.Checked && !rbfelicitacion.Checked && !rbsugerencia.Checked))
            {
                Response.Write("<script>alert('Falta llenar los campos obligatorios *')</script>");
            }//compara si los campos obligatorios estan vacios, si lo estan manda un mensaje, sino realiza el proceso de insertar
            else
            {
                if ((rbsi.Checked && rbno.Checked) || (rbqueja.Checked && rbfelicitacion.Checked && rbsugerencia.Checked)
                    || (rbqueja.Checked && rbfelicitacion.Checked) || (rbqueja.Checked && rbsugerencia.Checked)
                    || (rbsugerencia.Checked && rbfelicitacion.Checked))
                {//verifica que solo se marque una opcion por grupo de radiobutons, si hay mas de 1 manda mensaje
                    Response.Write("<script>alert('Solo puedes marcar una opcion(circulo) por pregunta')</script>");
                    if (rbsi.Checked && rbno.Checked)
                    {
                        rbsi.Checked = false;
                        rbno.Checked = false;
                    }//si hay mas de un radiobuton de tipo "Es Alumno" los devuelve a su estado inicial
                    else
                    {
                        rbqueja.Checked = false;
                        rbfelicitacion.Checked = false;
                        rbsugerencia.Checked = false;
                    }//si hay mas de un radiobuton de tipo "Tipo Servicio" los devuelve a su estado inicial
                }
                else//si no hay mas de 1 radiobuton, prosige con el proceso de insertar
                {
                    if (rbsi.Checked)//asignaciones del radiobuton seleccionado
                    {
                        usuario.EsAlumno = rbsi.Text;
                    }
                    if (rbno.Checked)
                    {
                        usuario.EsAlumno = rbno.Text;
                    }
                    if (rbqueja.Checked)
                    {
                        qsf.TipoServicio = rbqueja.Text;
                    }
                    if (rbfelicitacion.Checked)
                    {
                        qsf.TipoServicio = rbfelicitacion.Text;
                    }
                    if (rbsugerencia.Checked)
                    {
                        qsf.TipoServicio = rbsugerencia.Text;
                    }
                    usuario.Nombre = txtnombre.Text;//asignaciones de las cajas de texto a cada atributo de la lista Usuario
                    usuario.Telefono = txttelefono.Text;
                    usuario.Correo = txtcorreo.Text;
                    usuario.NoControl = txtnocontrol.Text;
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
                    qsf.Fecha = fecha.ToString("yyyy/MM/dd");//se establece el formato para la fecha actual
                    qsf.Prioridad = "Baja";//asignaciones de las cajas de texto a cada atributo de la lista QSF
                    qsf.Estatus = "No iniciada";
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
                    rbsi.Checked = false;
                    rbno.Checked = false;
                    rbqueja.Checked = false;
                    rbfelicitacion.Checked = false;
                    rbsugerencia.Checked = false;//se regresan las cajas de texto,variables y radiobutons a su estado inicial
                }
            }
        }
    }
}