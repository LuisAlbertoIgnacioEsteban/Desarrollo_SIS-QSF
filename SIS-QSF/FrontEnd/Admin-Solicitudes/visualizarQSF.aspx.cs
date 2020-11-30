using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
namespace FrontEnd.Admin_Solicitudes
{
    public partial class visualizarQSF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["id"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Contents.RemoveAll();
            Session.Clear();
            Session.Abandon();
            Response.Redirect("../LlenadoSolicitud.aspx");
        }
    }
}