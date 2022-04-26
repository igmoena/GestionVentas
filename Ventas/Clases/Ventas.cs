using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Clases
{
    public class Ventas
    {
        public string NombreProducto { get; set; }
        public DateTime FechaVenta { get; set; }
        public double ValorProducto { get; set; }
        public int IdVenta { get; set; }
        public double totalVenta { get; set; }
    }
}
