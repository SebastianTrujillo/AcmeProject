/*
 * Nombre de la Clase: PedidosBL
 * Descripcion: Toma objetos de tipo SQLPedidos creado desde la capa Data_Access_Layer y lo pasa a la capa User_Interface
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> List<Pedidos> ObtenerPedidos(string cs)
 * >> int ConsultarIdentificadorPedidos()
 * >> void InsertarPedidos(int iD_Cliente, decimal totalBruto, decimal impuesto, decimal valorNeto)
 */

using Data_Access_Layer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business_Logic
{
    public class PedidosBL
    {
        /* 
         * Metodo
         * Descripcion: Retornar un listado de pedidos
         * Entrada: string
         * Salida: List<Pedidos>
         */
        public List<Pedidos> ObtenerPedidos(string cs)
        {
            SQLPedidos contexto = new SQLPedidos(cs);
            List<Pedidos> pedidos = contexto.ObtenerPedido();
            return (pedidos);
        }

        /* 
         * Metodo
         * Descripcion: Retornar el identificador de un pedido
         * Entrada: void
         * Salida: int
         */
        public int ConsultarIdentificadorPedidos()
        {
            SQLPedidos contexto = new SQLPedidos();
            int iD_Pedido = contexto.ConsultarIdentificadorPedido();
            return (iD_Pedido);
        }

        /* 
         * Metodo
         * Descripcion: Inserta atributos de un pedido
         * Entrada: int, decimal, decimal, decimal
         * Salida: void
         */
        public void InsertarPedidos(int iD_Cliente, decimal totalBruto, decimal impuesto, decimal valorNeto)
        {
            SQLPedidos contexto = new SQLPedidos();
            contexto.InsertarPedido(iD_Cliente, totalBruto, impuesto, valorNeto);
        }
    }
}
