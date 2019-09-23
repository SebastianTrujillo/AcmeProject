/*
 * Nombre de la Clase: SQLPedidos
 * Descripcion: Establecer una conexión a la base de datos
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> SQLPedidos()
 * >> SQLPedidos(string cs)
 * >> List<Pedidos> ObtenerPedido()
 * >> int ConsultarIdentificadorPedido()
 * >> void InsertarPedido(int iD_Cliente, decimal totalBruto, decimal impuesto, decimal valorNeto)
 * >> Pedidos MapearPedido(TB_Pedido item)
 */

using Entities;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace Data_Access_Layer
{
    public class SQLPedidos
    {
        private string cs;

        /* 
         * Metodo
         * Descripcion: Metodo constructor por defecto
         * Entrada: void
         * Salida: void
         */
        public SQLPedidos()
        { }

        /* 
         * Metodo
         * Descripcion: Metodo constructor que recibe un parametro string
         * Entrada: string
         * Salida: void
         */
        public SQLPedidos(string cs)
        {
            this.cs = cs;
        }

        /* 
         * Metodo
         * Descripcion: Retorna un listado de pedidos
         * Entrada: void
         * Salida: List<Pedidos>
         */
        public List<Pedidos> ObtenerPedido()
        {
            List<Pedidos> pedidos = new List<Pedidos>();

            using (DB_AcmeEntities contexto = new DB_AcmeEntities())
            {
                var SQLPedido = from pedido in contexto.TB_Pedido select pedido;

                foreach (var item in SQLPedido)
                {
                    Pedidos pedidoActual = MapearPedido(item);
                    pedidos.Add(pedidoActual);
                }
            }

            return (pedidos);
        }

        /* 
         * Metodo
         * Descripcion: Consulta el identificador de un pedido
         * Entrada: void
         * Salida: int
         */
        public int ConsultarIdentificadorPedido()
        {
            ObjectParameter iD_Pedido = new ObjectParameter("ID_Pedido", typeof(int));

            using (DB_AcmeEntities contexto = new DB_AcmeEntities())
            {
                contexto.ConsultarIdentificadorPedido(iD_Pedido);
            }

            return ((int)iD_Pedido.Value);
        }

        /* 
         * Metodo
         * Descripcion: Inserta un pedido en la base de datos
         * Entrada: int, decimal, decimal, decimal,
         * Salida: void
         */
        public void InsertarPedido(int iD_Cliente, decimal totalBruto, decimal impuesto, decimal valorNeto)
        {
            using (DB_AcmeEntities contexto = new DB_AcmeEntities())
            {
                contexto.InsertarPedido(iD_Cliente, totalBruto, impuesto, valorNeto);
            }
        }

        /* 
         * Metodo
         * Descripcion: Mapea los atributos de un pedido
         * Entrada: TB_Pedido
         * Salida: Pedidos
         */
        private Pedidos MapearPedido(TB_Pedido item)
        {
            Pedidos pedido = new Pedidos();

            pedido.ID_Pedido = item.ID_Pedido;
            pedido.ID_Cliente = item.ID_Cliente;
            pedido.FechaRegistro = item.FechaRegistro;
            pedido.TotalBruto = item.TotalBruto;
            pedido.Impuesto = item.Impuesto;
            pedido.ValorNeto = item.ValorNeto;
            pedido.Estado = item.Estado;

            return (pedido);
        }
    }
}
