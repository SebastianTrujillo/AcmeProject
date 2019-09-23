/*
 * Nombre de la Clase: DetallePedidosBL
 * Descripcion: Toma objetos de tipo SQLDetallePedidos creado desde la capa Data_Access_Layer y lo pasa a la capa User_Interface
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> List<DetallePedidos> ObtenerDetallePedidos(string cs)
 * >> void ActualizarStockProductos(int iD_Producto, int cantidad)
 * >> void InsertarDetallePedidos(int iD_Pedido, int iD_Producto, int cantidad)
 * >> ObservableCollection<DetallePedidos> ObtenerDetallePedidos(int iD_Producto, string codigo, string nombreProducto, string descripcion, int cantidadProducto, decimal valorUnitario, decimal impuesto, decimal subTotal)
 */

using Data_Access_Layer;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Business_Logic
{
    public class DetallePedidosBL
    {
        /* 
         * Metodo
         * Descripcion: Retornar un listado de detalle pedidos
         * Entrada: string
         * Salida: List<DetallePedidos>
         */
        public List<DetallePedidos> ObtenerDetallePedidos(string cs)
        {
            SQLDetallePedidos contexto = new SQLDetallePedidos(cs);
            List<DetallePedidos> detallePedidos = contexto.ObtenerDetallePedido();
            return (detallePedidos);
        }

        /* 
         * Metodo
         * Descripcion: Actualiza el stock de un producto
         * Entrada: int, int
         * Salida: void
         */
        public void ActualizarStockProductos(int iD_Producto, int cantidad)
        {
            SQLDetallePedidos contexto = new SQLDetallePedidos();
            contexto.ActualizarStockProducto(iD_Producto, cantidad);
        }

        /* 
         * Metodo
         * Descripcion: Inserta atributos de un detalle pedido
         * Entrada: int, int, int
         * Salida: void
         */
        public void InsertarDetallePedidos(int iD_Pedido, int iD_Producto, int cantidad)
        {
            SQLDetallePedidos contexto = new SQLDetallePedidos();
            contexto.InsertarDetallePedido(iD_Pedido, iD_Producto, cantidad);
        }

        /* 
         * Metodo
         * Descripcion: Retorna una coleccion de detalle pedidos
         * Entrada: int, string, string, string, string, int, decimal, decimal, decimal
         * Salida: ObservableCollection<DetallePedidos>
         */
        public ObservableCollection<DetallePedidos> ObtenerDetallePedidos(int iD_Producto, string codigo, string nombreProducto, string descripcion, int cantidadProducto, decimal valorUnitario, decimal impuesto, decimal subTotal)
        {
            SQLDetallePedidos contexto = new SQLDetallePedidos();
            ObservableCollection<DetallePedidos> detallePedidos = contexto.ObtenerDetallePedido(iD_Producto, codigo, nombreProducto, descripcion, cantidadProducto, valorUnitario, impuesto, subTotal);
            return (detallePedidos);
        }
    }
}
