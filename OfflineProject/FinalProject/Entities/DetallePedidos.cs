using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class DetallePedidos
    {
        public int ID_DetallePedido { get; set; }
        public int ID_Pedido { get; set; }
        public int ID_Producto { get; set; }
        public string Codigo { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Impuesto { get; set; }
        public decimal SubTotal { get; set; }
    }
}
