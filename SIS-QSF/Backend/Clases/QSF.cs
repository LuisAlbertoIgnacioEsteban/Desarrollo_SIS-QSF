using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Backend.Daos;

namespace Backend.Clases
{
        public class QSF
        {
            public int ClaveQSF { get; set; }// geters y seters de cada atributo de la clase QSF, para asignar u obtener datos
            public string Prioridad { get; set; }
            public string Estatus { get; set; }
            public string Departamento { get; set; }
            public string TipoServicio { get; set; }
            public string Descripcion { get; set; }
            public string Observaciones { get; set; }
            public string Fecha { get; set; }
            public int UsuarioSolicitante { get; set; }

            // Creación de objetos para poder acceder a ellos y enlazar los atributos
            DaoQSF dqsf = new DaoQSF();

            // Método que nos permite enlazar los atributos para poder insertar un registro en la BD
            public void Insertar(QSF qsf)
            {
                dqsf.InsertarQSF(qsf);
            }

        }
}
