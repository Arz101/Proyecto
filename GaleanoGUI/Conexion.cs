using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace GUIPrincipal
{
    internal class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("SERVER=DESKTOP-37CKSJ5;DATABASE=PROYECTO_GALEANO;integrated security=true;");
            cn.Open();
            return cn;
        }
    }
}
