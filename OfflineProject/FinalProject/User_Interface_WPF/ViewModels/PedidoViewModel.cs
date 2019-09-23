/*
 * Nombre de la Clase: PedidoViewModel
 * Descripcion: Clase que representa la logica del pedido dentro de la vista 
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> int ID_Pedido
 * >> int ID_Cliente
 * >> DateTime FechaRegistro
 * >> decimal TotalBruto
 * >> decimal Impuesto
 * >> decimal ValorNeto
 * >> bool Estado
 * >> PedidoViewModel()
 * >> PedidoViewModel(Pedidos pedidos)
 * >> Pedidos ObtenerEntidad()
 */

using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace User_Interface_WPF.ViewModels
{
    public class PedidoViewModel : BaseViewModel
    {
        private int iD_Pedido;
        private int iD_Cliente;
        private DateTime fechaRegistro;
        private decimal totalBruto;
        private decimal impuesto;
        private decimal valorNeto;
        private bool estado;

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
        public int ID_Cliente
        {
            get
            {
                return (this.iD_Cliente);
            }
            set
            {
                this.iD_Cliente = value;
                OnPropertyChanged("ID_Cliente");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo DateTime
         * Entrada: void
         * Salida: DateTime
         */
        public DateTime FechaRegistro
        {
            get
            {
                return (this.fechaRegistro);
            }
            set
            {
                this.fechaRegistro = value;
                OnPropertyChanged("FechaRegistro");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo decimal
         * Entrada: void
         * Salida: decimal
         */
        public decimal TotalBruto
        {
            get
            {
                return (this.totalBruto);
            }
            set
            {
                this.totalBruto = value;
                OnPropertyChanged("TotalBruto");
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
        public decimal ValorNeto
        {
            get
            {
                return (this.valorNeto);
            }
            set
            {
                this.valorNeto = value;
                OnPropertyChanged("ValorNeto");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo bool
         * Entrada: void
         * Salida: bool
         */
        public bool Estado
        {
            get
            {
                return (this.estado);
            }
            set
            {
                this.estado = value;
                OnPropertyChanged("Estado");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo constructor por defecto 
         * Entrada: void
         * Salida: void
         */
        public PedidoViewModel()
        { }

        /* 
         * Metodo
         * Descripcion: Metodo constructor que recibe un objeto de tipo Pedidos e hidrata el view model pedidos
         * Entrada: Pedidos
         * Salida: void
         */
        public PedidoViewModel(Pedidos pedidos)
        {
            ID_Pedido = pedidos.ID_Pedido;
            ID_Cliente = pedidos.ID_Cliente;
            FechaRegistro = pedidos.FechaRegistro;
            TotalBruto = pedidos.TotalBruto;
            Impuesto = pedidos.Impuesto;
            ValorNeto = pedidos.ValorNeto;
            Estado = pedidos.Estado;

        }

        /* 
         * Metodo
         * Descripcion: Genera una entidad para ser transportada por las capas
         * Entrada: void
         * Salida: Pedidos
         */
        public Pedidos ObtenerEntidad()
        {
            return (new Pedidos
            {
                ID_Pedido = this.iD_Pedido,
                ID_Cliente = this.iD_Cliente,
                FechaRegistro = this.fechaRegistro,
                TotalBruto = this.totalBruto,
                Impuesto = this.impuesto,
                ValorNeto = this.valorNeto,
                Estado = this.estado
            });
        }
    }
}
