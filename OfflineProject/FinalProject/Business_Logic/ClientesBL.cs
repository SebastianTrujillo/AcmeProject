/*
 * Nombre de la Clase: ClientesBL
 * Descripcion: Toma el objeto de tipo SQLClientes creado desde la capa Data_Access_Layer y lo pasa a la capa User_Interface
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> List<Clientes> ObtenerClientes(string cs)
 */

using Data_Access_Layer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business_Logic
{
    public class ClientesBL
    {
        /* 
         * Metodo
         * Descripcion: Retornar un listado de clientes
         * Entrada: string
         * Salida: List<Clientes>
         */
        public List<Clientes> ObtenerClientes(string cs)
        {
            SQLClientes contexto = new SQLClientes(cs);
            List<Clientes> clientes = contexto.ObtenerCliente();
            return (clientes);
        }
    }
}
