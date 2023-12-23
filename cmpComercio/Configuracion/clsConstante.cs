using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmpComercio.Configuracion
{
    public class clsConstante
    {
        public string strCadenaConexionSIC = ConfigurationManager.ConnectionStrings["ConDB"].ToString();
    }
}
