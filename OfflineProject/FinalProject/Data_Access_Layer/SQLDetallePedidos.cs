/*
 * Nombre de la Clase: SQLDetallePedidos
 * Descripcion: Establecer una conexión a la base de datos
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> Counter getNumberClassMethods(string className)
 * >> Counter getNumberClassLines(string className, int classNumber)
 * >> Counter getNumberProgramLines()
 */

using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Data_Access_Layer
{
    public class SQLDetallePedidos
    {
        private string cs;

        /* 
         * Metodo
         * Descripcion: Metodo constructor por defecto
         * Entrada: void
         * Salida: void
         */
        public SQLDetallePedidos()
        { }

        /* 
         * Metodo
         * Descripcion: Metodo constructor que recibe un parametro string
         * Entrada: string
         * Salida: void
         */
        public SQLDetallePedidos(string cs)
        {
            this.cs = cs;
        }

        /* 
         * Metodo
         * Descripcion: Retorna un listado de detalle de pedidos
         * Entrada: void
         * Salida: List<DetallePedidos>
         */
        public List<DetallePedidos> ObtenerDetallePedido()
        {
            List<DetallePedidos> detallePedidos = new List<DetallePedidos>();

            using (DB_AcmeEntities contexto = new DB_AcmeEntities())
            {
                var SQLDetallePedidos = from detallePedido in contexto.TB_DetallePedido select detallePedido;

                foreach (var item in SQLDetallePedidos)
                {
                    DetallePedidos detallePedidoActual = MapearDetallePedido(item);
                    detallePedidos.Add(detallePedidoActual);
                }
            }

            return (detallePedidos);
        }

        /* 
         * Metodo
         * Descripcion: Actualiza el stock de un producto
         * Entrada: int, int
         * Salida: void
         */
        public void ActualizarStockProducto(int iD_Producto, int cantidad)
        {
            using (DB_AcmeEntities contexto = new DB_AcmeEntities())
            {
                contexto.ActualizarStockProducto(iD_Producto, cantidad);
            }
        }

        /* 
         * Metodo
         * Descripcion: Inserta un detalle de pedido en la base de datos
         * Entrada: int, int, int
         * Salida: void
         */
        public void InsertarDetallePedido(int iD_Pedido, int iD_Producto, int cantidad)
        {
            using (DB_AcmeEntities contexto = new DB_AcmeEntities())
            {
                contexto.InsertarDetallePedido(iD_Pedido, iD_Producto, cantidad);
            }
        }

        /* 
         * Metodo
         * Descripcion: Retorna una coleccion de detalle de pedido
         * Entrada: int, string, string, string, int, decimal, decimal, decimal
         * Salida: ObservableCollection<DetallePedidos>
         */
        public ObservableCollection<DetallePedidos> ObtenerDetallePedido(int iD_Producto, string codigo, string nombreProducto, string descripcion, int cantidadProducto, decimal valorUnitario, decimal impuesto, decimal subTotal)
        {
            ObservableCollection<DetallePedidos> detallePedidos = new ObservableCollection<DetallePedidos>();

            detallePedidos.Add(new DetallePedidos
            {                
                ID_Producto = iD_Producto,
                Codigo = codigo,
                NombreProducto = nombreProducto,
                Descripcion = descripcion,
                Cantidad = cantidadProducto,
                ValorUnitario = valorUnitario,
                Impuesto = impuesto,
                SubTotal = subTotal
            });
            
            return (detallePedidos);
        }

        /* 
         * Metodo
         * Descripcion: Mapea los atributos de un detalle de pedido
         * Entrada: TB_DetallePedido
         * Salida: DetallePedidos
         */
        private DetallePedidos MapearDetallePedido(TB_DetallePedido item)
        {
            DetallePedidos detallePedido = new DetallePedidos();

            detallePedido.ID_DetallePedido = item.ID_DetallePedido;
            detallePedido.ID_Pedido = item.ID_Pedido;
            detallePedido.ID_Producto = item.ID_Producto;
            detallePedido.Codigo = item.Codigo;
            detallePedido.NombreProducto = item.NombreProducto;
            detallePedido.Descripcion = item.Descripcion;
            detallePedido.Cantidad = item.Cantidad;
            detallePedido.ValorUnitario = item.ValorUnitario;
            detallePedido.Impuesto = item.Impuesto;
            detallePedido.SubTotal = item.SubTotal;

            return (detallePedido);
        }
    }
}
