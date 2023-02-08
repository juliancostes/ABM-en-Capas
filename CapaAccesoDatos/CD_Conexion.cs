using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace CapaAccesoDatos
{
    public class CD_Conexion
    {
        //private OleDbConnection CN = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Edu\\Documents\\Personas.accdb");
        private OleDbConnection CN = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Personas.accdb");

        public OleDbConnection AbrirConexion()
        {
            if (CN.State == ConnectionState.Open )
            {
                CN.Close();
            }
            CN.Open();

            return CN;
        }

        public OleDbConnection CerrarConexion()
        {
            CN.Close();
            return CN;
        }
        

    }
}
