/*
 * Nombre de la Clase: SQLClientes
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
using System.Linq;
using System.Text;

namespace Data_Access_Layer
{
    public class SQLClientes
    {
        private string cs;

        /* 
         * Metodo
         * Descripcion: Metodo constructor que recibe un parametro string
         * Entrada: string
         * Salida: void
         */
        public SQLClientes(string cs)
        {
            this.cs = cs;
        }

        /* 
         * Metodo
         * Descripcion: Retorna un listado de clientes
         * Entrada: void
         * Salida: List<Clientes>
         */
        public List<Clientes> ObtenerCliente()
        {
            List<Clientes> clientes = new List<Clientes>();

            using (DB_AcmeEntities contexto = new DB_AcmeEntities())
            {
                var SQLCliente = from cliente in contexto.TB_Cliente select cliente;

                foreach (var item in SQLCliente)
                {
                    Clientes clienteActual = MapearCliente(item);
                    clientes.Add(clienteActual);
                }
            }

            return (clientes);
        }

        /* 
         * Metodo
         * Descripcion: Mapea los atributos de un cliente
         * Entrada: TB_Cliente
         * Salida: Clientes
         */
        private Clientes MapearCliente(TB_Cliente item)
        {
            Clientes cliente = new Clientes();

            cliente.ID_Cliente = item.ID_Cliente;
            cliente.ID_Vendedor = item.ID_Vendedor;
            cliente.ID_Ciudad = item.ID_Ciudad;
            cliente.ID_Documento = item.ID_Documento;
            cliente.NombreCompleto = item.NombreCompleto;
            cliente.NumeroDocumento = item.NumeroDocumento;
            cliente.Telefono = item.Telefono;
            cliente.Celular = item.Celular;
            cliente.Email = item.Email;
            cliente.Direccion = item.Direccion;

            return (cliente);
        }
    }
}
