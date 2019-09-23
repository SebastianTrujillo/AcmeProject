/*
 * Nombre de la Clase: ProductosViewModel
 * Descripcion: Clase que define las propiedades de producto
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> ProductoViewModel Producto
 * >> string Codigo
 * >> ICommand BuscarProductoCommand
 * >> void BuscarProductoExecute()
 * >> bool CanBuscarProducto
 * >> void LimpiarProductoViewModel()
 */

using Business_Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace User_Interface_WPF.ViewModels
{
    public class ProductosViewModel : BaseViewModel, ProductoInject
    {
        string cs = ConfigurationManager.ConnectionStrings[0].ConnectionString;

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo ProductoViewModel
         * Entrada: void
         * Salida: ProductoViewModel
         */
        ProductoViewModel _producto;
        public ProductoViewModel Producto
        {
            get
            {
                return (_producto);
            }
            set
            {
                _producto = value;
                OnPropertyChanged("Producto");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo string
         * Entrada: void
         * Salida: string
         */
        private string _codigo;
        public string Codigo
        {
            get
            {
                return (_codigo);
            }
            set
            {
                _codigo = value;
                OnPropertyChanged("Codigo");
            }
        }

        /* 
         * Metodo
         * Descripcion: Expone un comando de nombre BuscarProductoCommand y lo relaciona con el data binding del view
         * Entrada: void
         * Salida: ICommand
         */
        RelayCommand _BuscarProductoCommand;
        public ICommand BuscarProductoCommand
        {
            get
            {
                if (_BuscarProductoCommand == null)
                    _BuscarProductoCommand = new RelayCommand(param => this.BuscarProductoExecute(), param => this.CanBuscarProducto);
                return (_BuscarProductoCommand);
            }
        }

        /* 
         * Metodo
         * Descripcion: Especifica la implementacion del comando BuscarProductoCommand - Busca un producto en particular
         * Entrada: void
         * Salida: void
         */
        private void BuscarProductoExecute()
        {
            bool productoEncontrado = false;
            ProductosBL contexto = new ProductosBL();
            var productosBL = contexto.ObtenerProductos(cs);
            if (Producto == null)
                Producto = new ProductoViewModel();

            foreach (var item in productosBL)
            {
                if (item.Codigo == this.Codigo)
                {
                    Producto = new ProductoViewModel(item);
                    productoEncontrado = true;
                }
            }

            if (productoEncontrado == false)
                MessageBox.Show("Codigo no registrado.", "Producto Invalido", MessageBoxButton.OK, MessageBoxImage.Warning);

            this.Codigo = "";
        }

        /* 
         * Metodo
         * Descripcion: Especifica que se puede ejecutar el comando BuscarProductoCommand
         * Entrada: void
         * Salida: bool
         */
        public bool CanBuscarProducto
        {
            get
            {
                return (true);
            }
        }

        /* 
         * Metodo
         * Descripcion: Actualiza la propiedad Producto
         * Entrada: void
         * Salida: void
         */
        public void LimpiarProductoViewModel()
        {
            Producto = null;
        }
    }
}
