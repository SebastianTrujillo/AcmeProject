/*
 * Nombre de la Clase: SQLProductos
 * Descripcion: Establecer una conexión a la base de datos
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> SQLProductos(string cs)
 * >> List<Productos> ObtenerProducto()
 * >> Productos MapearProducto(TB_Producto item)
 */

using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Access_Layer
{
    public class SQLProductos
    {
        private string cs;

        /* 
         * Metodo
         * Descripcion: Metodo constructor que recibe un parametro string
         * Entrada: string
         * Salida: void
         */
        public SQLProductos(string cs)
        {
            this.cs = cs;
        }

        /* 
         * Metodo
         * Descripcion: Retorna un listado de productos
         * Entrada: void
         * Salida: List<Productos>
         */
        public List<Productos> ObtenerProducto()
        {
            List<Productos> productos = new List<Productos>();

            using (DB_AcmeEntities contexto = new DB_AcmeEntities())
            {
                var SQLProducto = from producto in contexto.TB_Producto select producto;

                foreach (var item in SQLProducto)
                {
                    Productos productoActual = MapearProducto(item);
                    productos.Add(productoActual);
                }
            }

            return (productos);
        }

        /* 
         * Metodo
         * Descripcion: Mapea los atributos de un producto
         * Entrada: TB_Producto
         * Salida: Productos
         */
        private Productos MapearProducto(TB_Producto item)
        {
            Productos producto = new Productos();

            producto.ID_Producto = item.ID_Producto;
            producto.ID_Categoria = item.ID_Categoria;
            producto.ID_Promocion = item.ID_Promocion;
            producto.NombreProducto = item.NombreProducto;
            producto.Codigo = item.Codigo;
            producto.Descripcion = item.Descripcion;
            producto.Fabricante = item.Fabricante;
            producto.Stock = item.Stock;
            producto.Impuesto = item.Impuesto;
            producto.ValorUnitario = item.ValorUnitario;
            producto.Estado = item.Estado;

            return (producto);
        }
    }
}
