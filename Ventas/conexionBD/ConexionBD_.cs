using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Helpers;

namespace Ventas.conexionBD
{
    public class ConexionBD_
    {
        private static SqlConnection Conex = new SqlConnection("Data Source=200.6.76.250;Initial Catalog=SLAPPHOFMANN;;Persist Security Info=True;User ID=us;Max Pool Size=20; Min Pool Size = 1; Pooling=True;");
        private SqlCommand Comando = new SqlCommand("", Conex);
        private SqlDataReader Rec;
        public void AbrirConexion()
        {
            try
            {
                if (Conex.State == System.Data.ConnectionState.Open)
                {
                    Conex.Close();
                }
                if (Conex.State == System.Data.ConnectionState.Closed)
                {
                    Conex.Open();
                }
            }
            catch
            {
                Conex.Close();
                Conex.Open();
            }
        }
        public void CerrarConexion()
        {
            try
            {
                if (Conex.State == System.Data.ConnectionState.Closed)
                {
                    Conex.Open();
                }
                if (Conex.State == System.Data.ConnectionState.Open)
                {
                    Conex.Close();
                }
            }
            catch
            {
                Conex.Close();
            }
        }
        public int EjecutarIUD(string CadSql)
        {
            int filas = 0;
            try
            {
                AbrirConexion();
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = CadSql;
                filas = Comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                filas = 0;
            }
            finally
            {
                CerrarConexion();
            }
            return (filas);
        }

        public SqlDataReader EjecutarConsulta(string CadSql)
        {
            try
            {
                AbrirConexion();
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = CadSql;
                Rec = Comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                Rec = null;
            }
            return (Rec);
        }
        public string EjecutarConsultaSQLServer(string CadSql)
        {
            string respuesta = "";
            FormatoJson fj = new FormatoJson();
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=200.6.76.250;pooling=true;Max Pool Size=200;Initial Catalog=SLAPPHOFMANN;User ID=sa;Password=Hofmann2010"))
                {
                    conn.Open();
                    String query = CadSql;
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();
                    var r = fj.SerializeSqlServer(sdr);
                    respuesta = JsonConvert.SerializeObject(r, Formatting.Indented);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                respuesta = "";
            }
            return respuesta;
        }
    }
}
