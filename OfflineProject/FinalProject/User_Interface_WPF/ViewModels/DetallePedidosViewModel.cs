/*
 * Nombre de la Clase: DetallePedidosViewModel
 * Descripcion: Clase que define las propiedades de detalle pedido
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> ObservableCollection<DetallePedidoViewModel> DetallePedido
 * >> DetallePedidosViewModel(ProductoInject productoActual)
 * >> void CargarDetallePedido(int iD_Producto, string codigo, string nombreProducto, string descripcion, int cantidadProducto, decimal valorUnitario, decimal impuesto, decimal subTotal)
 * >> string CantidadProducto
 * >> string TotalBruto
 * >> string Impuesto
 * >> string ValorNeto
 * >> ICommand AgregarProductoCommand
 * >> void AgregarProductoExecute()
 * >> bool CanAgregarProducto
 * >> void LimpiarDetallePedidoViewModel()
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
    public class DetallePedidosViewModel : BaseViewModel
    {
        ProductoInject _productoActual;
        decimal totalBruto = 0;

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo ObservableCollection<DetallePedidoViewModel>
         * Entrada: void
         * Salida: ObservableCollection<DetallePedidoViewModel>
         */
        ObservableCollection<DetallePedidoViewModel> _detallePedido;
        public ObservableCollection<DetallePedidoViewModel> DetallePedido
        {
            get
            { return _detallePedido; }
            set
            {
                _detallePedido = value;
                OnPropertyChanged("DetallePedido");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo constructor que recibe un parametro de tipo ProductoInject
         * Entrada: ProductoInject
         * Salida: void
         */
        public DetallePedidosViewModel(ProductoInject productoActual)
        {
            _productoActual = productoActual;
        }

        /* 
         * Metodo
         * Descripcion: Metodo que carga el detalle de un pedido
         * Entrada: int, string, string, string, int, decimal, decimal, decimal
         * Salida: void
         */
        private void CargarDetallePedido(int iD_Producto, string codigo, string nombreProducto, string descripcion, int cantidadProducto, decimal valorUnitario, decimal impuesto, decimal subTotal)
        {
            DetallePedidosBL contexto = new DetallePedidosBL();
            var detallePedidosBL = contexto.ObtenerDetallePedidos(iD_Producto, codigo, nombreProducto, descripcion, cantidadProducto, valorUnitario, impuesto, subTotal);
            if (DetallePedido == null)
                DetallePedido = new ObservableCollection<DetallePedidoViewModel>();
            foreach (var item in detallePedidosBL)
            {
                DetallePedido.Add(new DetallePedidoViewModel(item));
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo string
         * Entrada: void
         * Salida: string
         */
        private string _cantidadProducto;
        public string CantidadProducto
        {
            get
            {
                return (_cantidadProducto);
            }
            set
            {
                _cantidadProducto = value;
                OnPropertyChanged("CantidadProducto");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo string
         * Entrada: void
         * Salida: string
         */
        private string _totalBruto;
        public string TotalBruto
        {
            get
            {
                return (_totalBruto);
            }
            set
            {
                _totalBruto = value;
                OnPropertyChanged("TotalBruto");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo string
         * Entrada: void
         * Salida: string
         */
        private string _impuesto;
        public string Impuesto
        {
            get
            {
                return (_impuesto);
            }
            set
            {
                _impuesto = value;
                OnPropertyChanged("Impuesto");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo string
         * Entrada: void
         * Salida: string
         */
        private string _valorNeto;
        public string ValorNeto
        {
            get
            {
                return (_valorNeto);
            }
            set
            {
                _valorNeto = value;
                OnPropertyChanged("ValorNeto");
            }
        }

        /* 
         * Metodo
         * Descripcion: Expone un comando de nombre AgregarProductoCommand y lo relaciona con el data binding del view
         * Entrada: void
         * Salida: ICommand
         */
        RelayCommand _AgregarProductoCommand;
        public ICommand AgregarProductoCommand
        {
            get
            {
                if (_AgregarProductoCommand == null)
                    _AgregarProductoCommand = new RelayCommand(param => this.AgregarProductoExecute(), param => this.CanAgregarProducto);
                return (_AgregarProductoCommand);
            }
        }

        /* 
         * Metodo
         * Descripcion: Especifica la implementacion del comando AgregarProductoCommand - Agrega un Producto al detalle
         * Entrada: void
         * Salida: void
         */
        private void AgregarProductoExecute()
        {
            try
            {
                int cantidadProducto;
                bool resultado = true;
                var producto = _productoActual.Producto;

                if (int.TryParse(this.CantidadProducto, out cantidadProducto) == false)
                {
                    MessageBox.Show("Digite un valor numerico.", "Cantidad Producto Invalido", MessageBoxButton.OK, MessageBoxImage.Warning);
                    this.CantidadProducto = "";
                    resultado = false;
                }
                
                if (resultado)
                {
                    if (producto.Estado == true)
                    {
                        if (cantidadProducto <= producto.Stock)
                        {
                            int iD_Producto = producto.ID_Producto;
                            string codigo = producto.Codigo;
                            string nombreProducto = producto.NombreProducto;
                            string descripcion = producto.Descripcion;
                            decimal valorUnitario = producto.ValorUnitario * cantidadProducto;
                            decimal impuesto = producto.Impuesto;
                            decimal subTotal = decimal.Round(((valorUnitario * impuesto) + valorUnitario), 2);

                            CargarDetallePedido(iD_Producto, codigo, nombreProducto, descripcion, cantidadProducto, valorUnitario, impuesto, subTotal);
                            this.totalBruto += valorUnitario;
                            this.CantidadProducto = "";
                            this.TotalBruto = (this.totalBruto).ToString();
                            this.Impuesto = (impuesto).ToString();
                            this.ValorNeto = (decimal.Round(((this.totalBruto * impuesto) + this.totalBruto), 2)).ToString();
                        }
                        else
                        {
                            MessageBox.Show("La cantidad de producto excede el stock.", "Cantidad Producto Invalido", MessageBoxButton.OK, MessageBoxImage.Warning);
                            this.CantidadProducto = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Producto fuera de stock.", "Producto Invalido", MessageBoxButton.OK, MessageBoxImage.Warning);
                        this.CantidadProducto = "";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Autentique la existencia de un producto para agregarlo al detalle.", "Detalle Producto Invalido", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /* 
         * Metodo
         * Descripcion: Especifica que se puede ejecutar el comando AgregarProductoCommand
         * Entrada: void
         * Salida: bool
         */
        public bool CanAgregarProducto
        {
            get
            {
                return (true);
            }
        }

        /* 
         * Metodo
         * Descripcion: Actualiza la propiedad DetallePedido
         * Entrada: void
         * Salida: void
         */
        public void LimpiarDetallePedidoViewModel()
        {
            DetallePedido = null;
            this.totalBruto = 0;
            this.TotalBruto = "";
            this.Impuesto = "";
            this.ValorNeto = "";
            this.CantidadProducto = "";
        }
    }
}
