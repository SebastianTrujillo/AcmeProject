using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Pedidos
    {
        public int ID_Pedido { get; set; }
        public int ID_Cliente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal TotalBruto { get; set; }
        public decimal Impuesto { get; set; }
        public decimal ValorNeto { get; set; }
        public bool Estado { get; set; }
    }
}
