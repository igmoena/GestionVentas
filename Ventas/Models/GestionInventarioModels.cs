using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.conexionBD;
using Ventas.Helpers;

namespace Ventas.Models
{
    public class GestionInventarioModels
    {
        FormatoJson fj = new FormatoJson();
        ConexionBD_ bd = new ConexionBD_();
        string resp = string.Empty;
        public string crearInventario()
        {
            try
            {
                string sql = "";
                
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            return resp;
        }
    }
}
