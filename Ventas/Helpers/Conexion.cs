using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Helpers
{
    internal class Conexion
    {
        SqlConnection cn;
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader reader;

        public Conexion()
        {
            cn = new SqlConnection("Data Source=200.6.76.250;Initial Catalog=SLAPPHOFMANN;;Persist Security Info=True;User ID=us");
        }
        public SqlConnection Open()
        {
            if (cn.State == System.Data.ConnectionState.Closed)
            {
                cn.Open();
            }
            return cn;  
        }
        public SqlConnection Close()
        {
            if (cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close();
            }
            return cn;
        }
        public SqlDataReader ejecutarConsulta (string cadena)
        {
            try
            {
                Open();
                Close();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = cadena;
                reader = cmd.ExecuteReader();   
            }
            catch (Exception ex)
            {
                reader = null;
            }
            return reader;
        }
    }
}
