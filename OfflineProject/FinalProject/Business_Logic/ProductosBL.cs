/*
 * Nombre de la Clase: ProductosBL
 * Descripcion: Toma el objeto de tipo SQLProductos creado desde la capa Data_Access_Layer y lo pasa a la capa User_Interface
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> List<Productos> ObtenerProductos(string cs)
 */

using Data_Access_Layer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business_Logic
{
    public class ProductosBL
    {
        /* 
         * Metodo
         * Descripcion: Retornar un listado de productos
         * Entrada: string
         * Salida: List<Productos>
         */
        public List<Productos> ObtenerProductos(string cs)
        {
            SQLProductos contexto = new SQLProductos(cs);
            List<Productos> productos = contexto.ObtenerProducto();
            return (productos);
        }
    }
}
