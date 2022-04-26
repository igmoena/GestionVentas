using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpreadsheetLight;
using System.IO;

namespace Ventas.Controller
{
    public class GestionInventarioController : Page
    {
        [HttpPost]
        protected void SubirArchivo()
        {
            string respuesta = "";
            string path = "";
            string filename = "";
            foreach (string upload in Request.Files)
            {
                if (Request.Files[upload].FileName != "")
                {
                    DateTime fecha = DateTime.Now;
                    string year = fecha.Year.ToString();
                    string mes = fecha.Month.ToString();
                    string dia = fecha.Day.ToString();
                    string hora = fecha.Hour.ToString();
                    string minuto = fecha.Minute.ToString();
                    path = AppDomain.CurrentDomain.BaseDirectory + "/Archivos/";
                    filename = year + mes + dia + hora + minuto + "-" + Path.GetFileName(Request.Files[upload].FileName);
                    Request.Files[upload].SaveAs(Path.Combine(path, filename));
                    respuesta = LeerDocumentoExcel(Path.Combine(path, filename), Path.GetExtension(Request.Files[upload].FileName));
                }
            }
        }
        public string LeerDocumentoExcel(string FilePath, string Extension)
        {
            SLDocument sl = new SLDocument(FilePath);
            int iRow = 2;
            try
            {
                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    if (iRow >= 2)
                    {
                        string invtId = sl.GetCellValueAsString(iRow, 1).ToString().Trim();
                        string Marca = sl.GetCellValueAsString(iRow, 2).ToString().Trim();
                        string FormatoPrecio = sl.GetCellValueAsString(iRow, 3).ToString().Trim();
                        string PrecioZonoExtrema = sl.GetCellValueAsString(iRow, 4).ToString().Trim();
                        string PrecioLista = sl.GetCellValueAsString(iRow, 5).Trim();
                        string PrecioMinimo = sl.GetCellValueAsString(iRow, 6).Trim();
                        string FormatoVenta = sl.GetCellValueAsString(iRow, 7).ToString().Trim();
                        string Obs = sl.GetCellValueAsString(iRow, 8).ToString().Trim();
                        string DescrMejorada = sl.GetCellValueAsString(iRow, 9).ToString().Trim();
                        //if (existeInvtID(invtId))
                        //{
                        //    UpdatecargaMasiva(invtId, Marca, FormatoPrecio, PrecioZonoExtrema, PrecioLista, PrecioMinimo, FormatoVenta, Obs, DescrMejorada);
                        //}
                        //else
                        //{
                        //    if (!cargaMasiva(invtId, Marca, FormatoPrecio, PrecioZonoExtrema, PrecioLista, PrecioMinimo, FormatoVenta, Obs, DescrMejorada))
                        //        return "Error al Actualizar en fila:" + iRow + "";
                        //}
                        iRow++;
                    }
                }
            }
            catch (Exception ex)
            {
                return "Excepcion del sistema ,contacte a Informatica";
                throw;
            }
            return "";
        }
    }
}
