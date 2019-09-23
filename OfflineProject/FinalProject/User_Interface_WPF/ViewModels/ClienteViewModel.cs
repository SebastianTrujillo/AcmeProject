/*
 * Nombre de la Clase: ClienteViewModel
 * Descripcion: Clase que representa la logica del cliente dentro de la vista 
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> int ID_Cliente
 * >> int ID_Vendedor
 * >> int ID_Ciudad
 * >> int ID_Documento
 * >> string NombreCompleto
 * >> string NumeroDocumento
 * >> string Telefono
 * >> string Celular
 * >> string Email
 * >> string Direccion
 * >> ClienteViewModel()
 * >> ClienteViewModel(Clientes cliente)
 * >> Clientes ObtenerEntidad()
 */

using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace User_Interface_WPF.ViewModels
{
    public class ClienteViewModel : BaseViewModel
    { 
        private int iD_Cliente;
        private int iD_Vendedor;
        private int iD_Ciudad;
        private int iD_Documento;
        private string nombreCompleto;
        private string numeroDocumento;
        private string telefono;
        private string celular;
        private string email;
        private string direccion;

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
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo int
         * Entrada: void
         * Salida: int
         */
        public int ID_Vendedor
        {
            get
            {
                return (this.iD_Vendedor);
            }
            set
            {
                this.iD_Vendedor = value;
                OnPropertyChanged("ID_Vendedor");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo int
         * Entrada: void
         * Salida: int
         */
        public int ID_Ciudad
        {
            get
            {
                return (this.iD_Ciudad);
            }
            set
            {
                this.iD_Ciudad = value;
                OnPropertyChanged("ID_Ciudad");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo int
         * Entrada: void
         * Salida: int
         */
        public int ID_Documento
        {
            get
            {
                return (this.iD_Documento);
            }
            set
            {
                this.iD_Documento = value;
                OnPropertyChanged("ID_Documento");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo string
         * Entrada: void
         * Salida: string
         */
        public string NombreCompleto
        {
            get
            {
                return (this.nombreCompleto);
            }
            set
            {
                this.nombreCompleto = value;
                OnPropertyChanged("NombreCompleto");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo string
         * Entrada: void
         * Salida: string
         */
        public string NumeroDocumento
        {
            get
            {
                return (this.numeroDocumento);
            }
            set
            {
                this.numeroDocumento = value;
                OnPropertyChanged("NumeroDocumento");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo string
         * Entrada: void
         * Salida: string
         */
        public string Telefono
        {
            get
            {
                return (this.telefono);
            }
            set
            {
                this.telefono = value;
                OnPropertyChanged("Telefono");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo string
         * Entrada: void
         * Salida: string
         */
        public string Celular
        {
            get
            {
                return (this.celular);
            }
            set
            {
                this.celular = value;
                OnPropertyChanged("Celular");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo string
         * Entrada: void
         * Salida: string
         */
        public string Email
        {
            get
            {
                return (this.email);
            }
            set
            {
                this.email = value;
                OnPropertyChanged("Email");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo string
         * Entrada: void
         * Salida: string
         */
        public string Direccion
        {
            get
            {
                return (this.direccion);
            }
            set
            {
                this.direccion = value;
                OnPropertyChanged("Direccion");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo constructor por defecto 
         * Entrada: void
         * Salida: void
         */
        public ClienteViewModel()
        { }

        /* 
         * Metodo
         * Descripcion: Metodo constructor que recibe un objeto de tipo Clientes e hidrata el view model cliente
         * Entrada: Clientes
         * Salida: void
         */
        public ClienteViewModel(Clientes cliente)
        {
            ID_Cliente = cliente.ID_Cliente;
            ID_Vendedor = cliente.ID_Vendedor;
            ID_Ciudad = cliente.ID_Ciudad;
            ID_Documento = cliente.ID_Documento;
            NombreCompleto = cliente.NombreCompleto;
            NumeroDocumento = cliente.NumeroDocumento;
            Telefono = cliente.Telefono;
            Celular = cliente.Celular;
            Email = cliente.Email;
            Direccion = cliente.Direccion;
        }

        /* 
         * Metodo
         * Descripcion: Genera una entidad para ser transportada por las capas
         * Entrada: void
         * Salida: Clientes
         */
        public Clientes ObtenerEntidad()
        {
            return (new Clientes
            {
                ID_Cliente = this.iD_Cliente,
                ID_Vendedor = this.iD_Vendedor,
                ID_Ciudad = this.iD_Ciudad,
                ID_Documento = this.iD_Documento,
                NombreCompleto = this.nombreCompleto,
                NumeroDocumento = this.numeroDocumento,
                Telefono = this.telefono,
                Celular = this.celular,
                Email = this.email,
                Direccion = this.direccion
            });
        }
    }
}
