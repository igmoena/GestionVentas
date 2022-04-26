using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Clases
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string  Descripcion { get; set; }
        public double Valor { get; set; }
        public double Iva { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string  UsuarioRegistro { get; set; }
    }
}
