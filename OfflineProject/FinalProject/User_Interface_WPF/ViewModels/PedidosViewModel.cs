/*
 * Nombre de la Clase: PedidosViewModel
 * Descripcion: Clase que define las propiedades de pedido
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> ObservableCollection<BaseViewModel> SubPantallas
 * >> PedidosViewModel()
 * >> ICommand GuardarPedidoCommand
 * >> void GuardarPedidoExecute()
 * >> CanGuardarPedido
 * >> void GuardarDetallePedidoExecute()
 * >> ICommand CancelarPedidoCommand
 * >> void CancelarPedidoExecute()
 * >> bool CanCancelarPedido
 * >> void LimpiarViewModels()
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
    public class PedidosViewModel : BaseViewModel
    {
        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo ObservableCollection<BaseViewModel>
         * Entrada: void
         * Salida: ObservableCollection<BaseViewModel>
         */
        ObservableCollection<BaseViewModel> _viewModels;
        public ObservableCollection<BaseViewModel> SubPantallas
        {
            get
            {
                if (_viewModels == null)
                    _viewModels = new ObservableCollection<BaseViewModel>();
                return _viewModels;
            }
            set
            {
                _viewModels = value;
                OnPropertyChanged("SubPantallas");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo constructor por defecto 
         * Entrada: void
         * Salida: void
         */
        public PedidosViewModel()
        {
            ClientesViewModel clientesVM = new ClientesViewModel();
            ProductosViewModel productosVM = new ProductosViewModel();
            DetallePedidosViewModel detallePedidosVM = new DetallePedidosViewModel(productosVM);
            SubPantallas.Add(clientesVM);
            SubPantallas.Add(productosVM);
            SubPantallas.Add(detallePedidosVM);
        }

        /* 
         * Metodo
         * Descripcion: Expone un comando de nombre GuardarPedidoCommand y lo relaciona con el data binding del view
         * Entrada: void
         * Salida: ICommand
         */
        RelayCommand _GuardarPedidoCommand;
        public ICommand GuardarPedidoCommand
        {
            get
            {
                if (_GuardarPedidoCommand == null)
                    _GuardarPedidoCommand = new RelayCommand(param => this.GuardarPedidoExecute(), param => this.CanGuardarPedido);
                return (_GuardarPedidoCommand);
            }
        }

        /* 
         * Metodo
         * Descripcion: Especifica la implementacion del comando GuardarPedidoCommand - Guarda un pedido
         * Entrada: void
         * Salida: void
         */
        private void GuardarPedidoExecute()
        {
            try
            {
                PedidosBL contexto = new PedidosBL();

                var cliente = (SubPantallas[0] as ClientesViewModel).Cliente;
                var detallePedido = (SubPantallas[2] as DetallePedidosViewModel).DetallePedido;

                decimal totalBruto = 0;
                decimal impuesto = detallePedido.FirstOrDefault().Impuesto;
                decimal valorNeto;

                foreach (var item in detallePedido)
                {
                    totalBruto += item.ValorUnitario;                
                }

                valorNeto = decimal.Round(((totalBruto * impuesto) + totalBruto), 2);

                contexto.InsertarPedidos(cliente.ID_Cliente, totalBruto, impuesto, valorNeto);

                GuardarDetallePedidoExecute();

                MessageBox.Show("El pedido fue guardado con éxito.", "Pedido Guardado", MessageBoxButton.OK, MessageBoxImage.Information);

                LimpiarViewModels();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al tratar de guardar un pedido.", "Error Pedido", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /* 
         * Metodo
         * Descripcion: Especifica que se puede ejecutar el comando GuardarPedidoCommand
         * Entrada: void
         * Salida: bool
         */
        public bool CanGuardarPedido
        {
            get
            {
                return (true);
            }
        }

        /* 
         * Metodo
         * Descripcion: Guarda el detalle de pedido
         * Entrada: void
         * Salida: void
         */
        private void GuardarDetallePedidoExecute()
        {
            PedidosBL contextoPedidos = new PedidosBL();
            DetallePedidosBL contextoDetallesPedido = new DetallePedidosBL();

            var detallePedido = (SubPantallas[2] as DetallePedidosViewModel).DetallePedido;

            foreach (var item in detallePedido)
            {
                contextoDetallesPedido.InsertarDetallePedidos(contextoPedidos.ConsultarIdentificadorPedidos(), item.ID_Producto, item.Cantidad);
                contextoDetallesPedido.ActualizarStockProductos(item.ID_Producto, item.Cantidad);
            }
        }

        /* 
         * Metodo
         * Descripcion: Expone un comando de nombre CancelarPedidoCommand y lo relaciona con el data binding del view
         * Entrada: void
         * Salida: ICommand
         */
        RelayCommand _CancelarPedidoCommand;
        public ICommand CancelarPedidoCommand
        {
            get
            {
                if (_CancelarPedidoCommand == null)
                    _CancelarPedidoCommand = new RelayCommand(param => this.CancelarPedidoExecute(), param => this.CanCancelarPedido);
                return (_CancelarPedidoCommand);
            }
        }

        /* 
         * Metodo
         * Descripcion: Especifica la implementacion del comando CancelarPedidoCommand - Limpia las view
         * Entrada: void
         * Salida: void
         */
        private void CancelarPedidoExecute()
        {
            LimpiarViewModels();
        }

        /* 
         * Metodo
         * Descripcion: Especifica que se puede ejecutar el comando CancelarPedidoCommand
         * Entrada: void
         * Salida: bool
         */
        public bool CanCancelarPedido
        {
            get
            {
                return (true);
            }
        }

        /* 
         * Metodo
         * Descripcion: Limpia las views
         * Entrada: void
         * Salida: void
         */
        public void LimpiarViewModels()
        {
            var cliente = (SubPantallas[0] as ClientesViewModel);
            cliente.LimpiarClienteViewModel();

            var producto = SubPantallas[1] as ProductosViewModel;
            producto.LimpiarProductoViewModel();

            var detallePedido = SubPantallas[2] as DetallePedidosViewModel;
            detallePedido.LimpiarDetallePedidoViewModel();
        }
    }
}
