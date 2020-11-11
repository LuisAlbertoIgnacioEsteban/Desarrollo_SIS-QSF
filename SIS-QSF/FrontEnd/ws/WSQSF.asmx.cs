using Backend.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace FrontEnd.ws
{
    /// <summary>
    /// Descripción breve de WSQSF
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSQSF : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public String getAll()
        {          
                JavaScriptSerializer jss = new JavaScriptSerializer();
                return jss.Serialize(new DaoQSF().getAll());
                       
        }
    }
}
