using Business_Logic;
using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace User_Interface_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = ConfigurationManager.ConnectionStrings[0].ConnectionString;

            try
            {
                ClientesBL contexto = new ClientesBL();

                List<Clientes> clientes = contexto.ObtenerClientes(cs);
                foreach (var cliente in clientes)
                {
                    Console.WriteLine("Cliente: ID = {0} -- Nombre = {1}", cliente.ID_Cliente, cliente.NombreCompleto);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("");
            Console.WriteLine("=======================================================");
            Console.WriteLine("");

            try
            {
                VendedoresBL contexto = new VendedoresBL();

                List<Vendedores> vendedores = contexto.ObtenerVendedores(cs);
                foreach (var vendedor in vendedores)
                {
                    Console.WriteLine("Vendedore: ID = {0} -- Nombre = {1}", vendedor.ID_Vendedor, vendedor.NombreCompleto);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("");
            Console.WriteLine("=======================================================");
            Console.WriteLine("");

            VendedoresBL contexto2 = new VendedoresBL();

            bool resultado = contexto2.AutenticarVendedores("Juansrt", "Juan3456");
            Console.WriteLine("Autenticando al Vendedor: "+resultado);

            Console.WriteLine("");
            Console.WriteLine("=======================================================");
            Console.WriteLine("");

            try
            {
                ProductosBL contexto = new ProductosBL();

                List<Productos> productos = contexto.ObtenerProductos(cs);
                foreach (var producto in productos)
                {
                    Console.WriteLine("Producto: ID = {0} -- Stock = {1}", producto.ID_Producto, producto.Stock);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("");
            Console.WriteLine("=======================================================");
            Console.WriteLine("");

            try
            {
                PedidosBL contexto = new PedidosBL();

                List<Pedidos> pedidos = contexto.ObtenerPedidos(cs);
                foreach (var pedido in pedidos)
                {
                    Console.WriteLine("Pedido: ID = {0} -- FechaRegistro = {1}", pedido.ID_Pedido, pedido.FechaRegistro);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("");
            Console.WriteLine("=======================================================");
            Console.WriteLine("");

            try
            {
                DetallePedidosBL contexto = new DetallePedidosBL();

                List<DetallePedidos> detallePedidos = contexto.ObtenerDetallePedidos(cs);
                foreach (var detallePedido in detallePedidos)
                {
                    Console.WriteLine("DetallePedidos: ID = {0} -- NombreProducto = {1}", detallePedido.ID_DetallePedido, detallePedido.NombreProducto);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("");
            Console.WriteLine("=======================================================");
            Console.WriteLine("");

            try
            {
                PedidosBL contexto = new PedidosBL();

                Console.WriteLine("ID_Pedido: "+contexto.ConsultarIdentificadorPedidos());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            //Console.WriteLine("");
            //Console.WriteLine("=======================================================");
            //Console.WriteLine("");

            //DetallePedidosBL contexto3 = new DetallePedidosBL();
            //contexto3.ActualizarStockProductos(1, 50);

            Console.ReadLine();
        }
    }
}
