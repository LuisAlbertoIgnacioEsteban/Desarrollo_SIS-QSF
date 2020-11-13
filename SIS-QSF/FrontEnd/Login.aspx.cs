using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Clases;

namespace FrontEnd
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        Administrador administrador = new Administrador(); //Instancia de la clase administrador

        protected void inicio_Click(object sender, EventArgs e)
        {
            administrador.NombreUsuario = txtUsuario.Text;
            administrador.ClaveUsuario = txtPass.Text;

            if (administrador.verificarAdmin(administrador)==true)
            {
                Response.Redirect("~/Admin-Solicitudes/visualizarQSF.aspx");
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña no valido";
            }
        }
    }
}