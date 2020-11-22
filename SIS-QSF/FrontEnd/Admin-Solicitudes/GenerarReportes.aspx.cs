using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Daos;

namespace FrontEnd.Admin_Solicitudes
{
    public partial class GenerarReportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected String TiposdeSolicitud()
        {
            DataTable Datos = new DataTable();
            Datos.Columns.Add(new DataColumn("Solicitud",typeof(string)));
            Datos.Columns.Add(new DataColumn("Cantidad", typeof(string)));

            DaoQSF obj = new DaoQSF();
            String depa = "";

            if (int.Parse(DropDownList1.SelectedIndex.ToString()) == 0)
            {
                depa = "Academico";
            }else if (int.Parse(DropDownList1.SelectedIndex.ToString()) == 1)
            {
                depa = "Vinculacion";
            }else if (int.Parse(DropDownList1.SelectedIndex.ToString()) == 2)
            {
                depa = "Planeacion";
            }else if (int.Parse(DropDownList1.SelectedIndex.ToString()) == 3)
            {
                depa = "Calidad";
            }else if (int.Parse(DropDownList1.SelectedIndex.ToString()) == 4)
            {
                depa = "Administracion";
            }

            string[] array = obj.getTipoS(depa).Split(',');
            

            Datos.Rows.Add(new Object[] {"Queja",array[0] });
            Datos.Rows.Add(new Object[] {"Sugerencia", array[1] });
            Datos.Rows.Add(new Object[] {"Felicitacion", array[2] });

            string Data;

            Data = "[['Task','Hours per Day'],";

            foreach (DataRow dr in Datos.Rows)
            {
                Data += "[";
                Data += "'" + dr[0] + "'" + "," + dr[1];
                Data += "],";
            }

            Data += "]";

            return Data;
        }

        protected void CambioSeleccion(object sender, EventArgs e)
        {
            TiposdeSolicitud();
                       
        }
    }
}