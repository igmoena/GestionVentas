using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Helpers
{
    public class FormatoJson
    {
        // Formato Retorna Respuesta Correcta Sin Mensaje
        public string formato_ok()
        {
            return "{ \"respuesta\": \"S\"}";
        }
        // Formato Retorna Respuesta Correcta
        public string formato_ok_id(string ide)
        {
            return "{ \"respuesta\": \"P\",\"ID\": \"" + ide + "\"}";
        }
        public string formato_ok_id_mensaje(string ide, string mensaje)
        {
            return "{ \"respuesta\": \"P\",\"ID\": \"" + ide + "\",\"MENSAJE\": \"" + mensaje + "\"}";
        }
        // Formato Retorna Respuesta Corecta con Mensaje
        public string formato_si_mensaje(string mensaje)
        {
            return "{ \"respuesta\": \"S\",\"mensaje\": \"" + mensaje + "\"}";
        }
        // Formato Retorna Respuesta Incorrecta con Mensaje
        public string formato_no_mensaje(string mensaje)
        {
            return "{ \"respuesta\": \"N\",\"mensaje\": \"" + mensaje + "\"}";
        }
        public string formato_no_mensaje_2(string mensaje)
        {
            return "{ \"resp\": \"N\",\"mensaje\": \"" + mensaje + "\"}";
        }
        // Formato Retorna Respuesta Correcta y Informacion
        public string formato_ok_data(string json)
        {
            string enc = "{ \"respuesta\": \"S\",\"data\": ";
            string nuevo = enc + json + "}";
            return nuevo;
        }
        // Formato Vacio
        public string formato_vacio()
        {
            return "{}";
        }
        // Conversion Data Reader SQL SERVER a JSON
        public IEnumerable<Dictionary<string, object>> SerializeSqlServer(SqlDataReader reader)
        {
            try
            {
                var results = new List<Dictionary<string, object>>();
                var cols = new List<string>();
                if (reader == null)
                    return null;
                for (var i = 0; i < reader.FieldCount; i++)
                    cols.Add(reader.GetName(i));

                while (reader.Read())
                    results.Add(SerializeRowSqlServer(cols, reader));

                return results;
            }
            catch (Exception)
            {

                return null;
            }

        }
        // Conversion Data Reader SQL SERVER a JSON 2
        private Dictionary<string, object> SerializeRowSqlServer(IEnumerable<string> cols, SqlDataReader reader)
        {
            var result = new Dictionary<string, object>();
            foreach (var col in cols)
                result.Add(col, reader[col]);
            return result;
        }
        /*
        // Conversion Data Reader Mysql a JSON
        public IEnumerable<Dictionary<string, object>> SerializeMysql(MySqlDataReader reader)
        {
            var results = new List<Dictionary<string, object>>();
            var cols = new List<string>();
            for (var i = 0; i < reader.FieldCount; i++)
                cols.Add(reader.GetName(i));

            while (reader.Read())
                results.Add(SerializeRowMysql(cols, reader));

            return results;
        }
        // Conversion Data Reader Mysql a JSON
        private Dictionary<string, object> SerializeRowMysql(IEnumerable<string> cols, MySqlDataReader reader)
        {
            var result = new Dictionary<string, object>();
            foreach (var col in cols)
                result.Add(col, reader[col]);
            return result;
        }
        */
        //public ArrayList Obtener_errores(ValidationResult results)
        //{
        //    ArrayList mensaje_errores = new ArrayList();
        //    foreach (ValidationFailure failure in results.ErrorMessage)
        //    {
        //        mensaje_errores.Add(failure.ErrorMessage.ToString());
        //    }
        //    return mensaje_errores;
        //}
    }
}
