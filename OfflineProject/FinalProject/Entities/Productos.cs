using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Productos
    {
        public int ID_Producto { get; set; }
        public int ID_Categoria { get; set; }
        public int ID_Promocion { get; set; }
        public string NombreProducto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Fabricante { get; set; }
        public int Stock { get; set; }
        public decimal Impuesto { get; set; }
        public decimal ValorUnitario { get; set; }
        public bool Estado { get; set; }
    }
}
