using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Clientes
    {
        public int ID_Cliente { get; set; }
        public int ID_Vendedor { get; set; }
        public int ID_Ciudad { get; set; }
        public int ID_Documento { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroDocumento { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}
