using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ventas.conexionBD;
using Ventas.Helpers;

namespace Ventas.Models
{
    public class GestionVentasModels
    {
        FormatoJson fj = new FormatoJson();
        ConexionBD_ bd = new ConexionBD_();
        string resp = string.Empty;
        static readonly string clase_conexion = "Data Source=200.6.76.250;Initial Catalog=SLAPPHOFMANN;;Persist Security Info=True;User ID=us";

        public string ObtenerProductos()
        {
            try
            {
                string sql = "";
                SqlDataReader sdr = bd.EjecutarConsulta(sql);
                if (sdr != null)
                {
                    var r = fj.SerializeSqlServer(sdr);
                    resp = JsonConvert.SerializeObject(r, Formatting.Indented);
                    bd.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            return resp;
        }
        public string guardarVenta()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(clase_conexion))
                {
                    cn.Open();
                    SqlCommand cm = cn.CreateCommand();
                    SqlTransaction transaction = cn.BeginTransaction("tr_guardarVenta");
                    cm.Connection = cn;
                    cm.Transaction = transaction;
                    string sql = "";

                    cm.CommandText = sql;
                    cm.ExecuteNonQuery();
                    transaction.Commit();
                    return resp;
                }
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            return resp;
        }
    }
}
