/*
 * Nombre de la Clase: DetallePedidoViewModel
 * Descripcion: Clase que representa la logica del detalle del pedido dentro de la vista 
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> int ID_DetallePedido
 * >> int ID_Pedido
 * >> int ID_Producto
 * >> string Codigo
 * >> string NombreProducto
 * >> string Descripcion
 * >> int Cantidad
 * >> decimal ValorUnitario
 * >> decimal Impuesto
 * >> decimal SubTotal
 * >> DetallePedidoViewModel()
 * >> DetallePedidoViewModel(DetallePedidos detallePedido)
 * >> DetallePedidos ObtenerEntidad()
 */

using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace User_Interface_WPF.ViewModels
{
    public class DetallePedidoViewModel : BaseViewModel
    {
        private int iD_DetallePedido;
        private int iD_Pedido;
        private int iD_Producto;
        private string codigo;
        private string nombreProducto;
        private string descripcion;
        private int cantidad;
        private decimal valorUnitario;
        private decimal impuesto;
        private decimal subTotal;

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo int
         * Entrada: void
         * Salida: int
         */
        public int ID_DetallePedido
        {
            get
            {
                return (this.iD_DetallePedido);
            }
            set
            {
                this.iD_DetallePedido = value;
                OnPropertyChanged("ID_DetallePedido");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo int
         * Entrada: void
         * Salida: int
         */
        public int ID_Pedido
        {
            get
            {
                return (this.iD_Pedido);
            }
            set
            {
                this.iD_Pedido = value;
                OnPropertyChanged("ID_Pedido");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo int
         * Entrada: void
         * Salida: int
         */
        public int ID_Producto
        {
            get
            {
                return (this.iD_Producto);
            }
            set
            {
                this.iD_Producto = value;
                OnPropertyChanged("ID_Producto");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo string
         * Entrada: void
         * Salida: string
         */
        public string Codigo
        {
            get
            {
                return (this.codigo);
            }
            set
            {
                this.codigo = value;
                OnPropertyChanged("Codigo");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo string
         * Entrada: void
         * Salida: string
         */
        public string NombreProducto
        {
            get
            {
                return (this.nombreProducto);
            }
            set
            {
                this.nombreProducto = value;
                OnPropertyChanged("NombreProducto");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo string
         * Entrada: void
         * Salida: string
         */
        public string Descripcion
        {
            get
            {
                return (this.descripcion);
            }
            set
            {
                this.descripcion = value;
                OnPropertyChanged("Descripcion");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo int
         * Entrada: void
         * Salida: int
         */
        public int Cantidad
        {
            get
            {
                return (this.cantidad);
            }
            set
            {
                this.cantidad = value;
                OnPropertyChanged("Cantidad");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo decimal
         * Entrada: void
         * Salida: decimal
         */
        public decimal ValorUnitario
        {
            get
            {
                return (this.valorUnitario);
            }
            set
            {
                this.valorUnitario = value;
                OnPropertyChanged("ValorUnitario");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo decimal
         * Entrada: void
         * Salida: decimal
         */
        public decimal Impuesto
        {
            get
            {
                return (this.impuesto);
            }
            set
            {
                this.impuesto = value;
                OnPropertyChanged("Impuesto");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo decimal
         * Entrada: void
         * Salida: decimal
         */
        public decimal SubTotal
        {
            get
            {
                return (this.subTotal);
            }
            set
            {
                this.subTotal = value;
                OnPropertyChanged("SubTotal");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo constructor por defecto 
         * Entrada: void
         * Salida: void
         */
        public DetallePedidoViewModel()
        { }

        /* 
         * Metodo
         * Descripcion: Metodo constructor que recibe un objeto de tipo DetallePedidos e hidrata el view model detallePedido
         * Entrada: DetallePedidos
         * Salida: void
         */
        public DetallePedidoViewModel(DetallePedidos detallePedido)
        {
            ID_DetallePedido = detallePedido.ID_DetallePedido;
            ID_Pedido = detallePedido.ID_Pedido;
            ID_Producto = detallePedido.ID_Producto;
            Codigo = detallePedido.Codigo;
            NombreProducto = detallePedido.NombreProducto;
            Descripcion = detallePedido.Descripcion;
            Cantidad = detallePedido.Cantidad;
            ValorUnitario = detallePedido.ValorUnitario;
            Impuesto = detallePedido.Impuesto;
            SubTotal = detallePedido.SubTotal;
        }

        /* 
         * Metodo
         * Descripcion: Genera una entidad para ser transportada por las capas
         * Entrada: void
         * Salida: DetallePedidos
         */
        public DetallePedidos ObtenerEntidad()
        {
            return (new DetallePedidos
            {
                ID_DetallePedido = this.iD_DetallePedido,
                ID_Pedido = this.iD_Pedido,
                ID_Producto = this.iD_Producto,
                Codigo = this.codigo,
                NombreProducto = this.nombreProducto,
                Descripcion = this.descripcion,
                Cantidad = this.cantidad,
                ValorUnitario = this.valorUnitario,
                Impuesto = this.impuesto,
                SubTotal = this.subTotal
        });
        }
    }
}
