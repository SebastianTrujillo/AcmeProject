/*
 * Nombre de la Clase: ClientesViewModel
 * Descripcion: Clase que define las propiedades de cliente
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> ClienteViewModel Cliente
 * >> string NumeroDocumento
 * >> ICommand BuscarClienteCommand
 * >> void BuscarClienteExecute()
 * >> bool CanBuscarCliente
 * >> void LimpiarClienteViewModel()
 */

using Business_Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace User_Interface_WPF.ViewModels
{
    public class ClientesViewModel : BaseViewModel
    {
        string cs = ConfigurationManager.ConnectionStrings[0].ConnectionString;

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo ClienteViewModel
         * Entrada: void
         * Salida: ClienteViewModel
         */
        ClienteViewModel _cliente;
        public ClienteViewModel Cliente
        {
            get
            {
                return (_cliente);
            }
            set
            {
                _cliente = value;
                OnPropertyChanged("Cliente");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo string
         * Entrada: void
         * Salida: string
         */
        private string _numeroDocumento;
        public string NumeroDocumento
        {
            get
            {
                return (_numeroDocumento);
            }
            set
            {
                _numeroDocumento = value;
                OnPropertyChanged("NumeroDocumento");
            }
        }

        /* 
         * Metodo
         * Descripcion: Expone un comando de nombre BuscarClienteCommand y lo relaciona con el data binding del view
         * Entrada: void
         * Salida: ICommand
         */
        RelayCommand _BuscarClienteCommand;
        public ICommand BuscarClienteCommand
        {
            get
            {
                if (_BuscarClienteCommand == null)
                    _BuscarClienteCommand = new RelayCommand(param => this.BuscarClienteExecute(), param => this.CanBuscarCliente);
                return (_BuscarClienteCommand);
            }
        }

        /* 
         * Metodo
         * Descripcion: Especifica la implementacion del comando BuscarClienteCommand - Busca un cliente en particular
         * Entrada: void
         * Salida: void
         */
        private void BuscarClienteExecute()
        {
            bool clienteEncontrado = false;
            ClientesBL contexto = new ClientesBL();
            var clientesBL = contexto.ObtenerClientes(cs);
            if (Cliente == null)
                Cliente = new ClienteViewModel();

            foreach (var item in clientesBL)
            {
                if (item.NumeroDocumento == this.NumeroDocumento)
                {
                    Cliente = new ClienteViewModel(item);
                    clienteEncontrado = true;
                }
            }

            if(clienteEncontrado == false)
                MessageBox.Show("Numero de documento no registrado.", "Cliente Invalido", MessageBoxButton.OK, MessageBoxImage.Warning);

            this.NumeroDocumento = "";
        }

        /* 
         * Metodo
         * Descripcion: Especifica que se puede ejecutar el comando BuscarClienteCommand
         * Entrada: void
         * Salida: bool
         */
        public bool CanBuscarCliente
        {
            get
            {
                return (true);
            }
        }

        /* 
         * Metodo
         * Descripcion: Actualiza la propiedad Cliente
         * Entrada: void
         * Salida: void
         */
        public void LimpiarClienteViewModel()
        {
            Cliente = null;
        }
    }
}
