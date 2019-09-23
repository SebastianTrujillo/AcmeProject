/*
 * Nombre de la Clase: SQLVendedores
 * Descripcion: Establecer una conexión a la base de datos
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> SQLVendedores()
 * >> SQLVendedores(string cs)
 * >> List<Vendedores> ObtenerVendedor()
 * >> bool AutenticarVendedor(string nombreUsuario, string contrasenia)
 * >> Vendedores MapearVendedor(TB_Vendedor item)
 */

using Entities;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace Data_Access_Layer
{
    public class SQLVendedores
    {
        private string cs;

        /* 
         * Metodo
         * Descripcion: Metodo constructor por defecto
         * Entrada: void
         * Salida: void
         */
        public SQLVendedores()
        { }

        /* 
         * Metodo
         * Descripcion: Metodo constructor que recibe un parametro string
         * Entrada: string
         * Salida: void
         */
        public SQLVendedores(string cs)
        {
            this.cs = cs;
        }

        /* 
         * Metodo
         * Descripcion: Retorna un listado de vendedores
         * Entrada: void
         * Salida: List<Vendedores>
         */
        public List<Vendedores> ObtenerVendedor()
        {
            List<Vendedores> vendedores = new List<Vendedores>();

            using (DB_AcmeEntities contexto = new DB_AcmeEntities())
            {
                var SQLVendedor = from vendedor in contexto.TB_Vendedor select vendedor;

                foreach (var item in SQLVendedor)
                {
                    Vendedores vendedorActual = MapearVendedor(item);
                    vendedores.Add(vendedorActual);
                }
            }

            return (vendedores);
        }

        /* 
         * Metodo
         * Descripcion: Autentica a un vendedor 
         * Entrada: string, string
         * Salida: bool
         */
        public bool AutenticarVendedor(string nombreUsuario, string contrasenia)
        {
            ObjectParameter resultado = new ObjectParameter("Resultado", typeof(String));

            using (DB_AcmeEntities contexto = new DB_AcmeEntities())
            {
                contexto.AutenticarVendedor(nombreUsuario, contrasenia, resultado);
            }

                return ((bool) resultado.Value);
        }

        /* 
         * Metodo
         * Descripcion: Mapea los atributos de un vendedor
         * Entrada: TB_Vendedor
         * Salida: Vendedores
         */
        private Vendedores MapearVendedor(TB_Vendedor item)
        {
            Vendedores vendedor = new Vendedores();

            vendedor.ID_Vendedor = item.ID_Vendedor;
            vendedor.NombreCompleto = item.NombreCompleto;
            vendedor.NumeroDocumento = item.NumeroDocumento;
            vendedor.NombreUsuario = item.NombreUsuario;
            vendedor.Contrasenia = item.Contrasenia;

            return (vendedor);
        }
    }
}
