/*
 * Nombre de la Clase: ProductoViewModel
 * Descripcion: Clase que representa la logica del producto dentro de la vista 
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> int ID_Producto
 * >> int ID_Categoria
 * >> int ID_Promocion
 * >> string NombreProducto
 * >> string Codigo
 * >> string Descripcion
 * >> string Fabricante
 * >> int Stock
 * >> decimal Impuesto
 * >> decimal ValorUnitario
 * >> bool Estado
 * >> ProductoViewModel()
 * >> ProductoViewModel(Productos producto)
 * >> Productos ObtenerEntidad()
 */

using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace User_Interface_WPF.ViewModels
{
    public class ProductoViewModel : BaseViewModel
    {
        private int iD_Producto;
        private int iD_Categoria;
        private int iD_Promocion;
        private string nombreProducto;
        private string codigo;
        private string descripcion;
        private string fabricante;
        private int stock;
        private decimal impuesto;
        private decimal valorUnitario;
        private bool estado;

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
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo int
         * Entrada: void
         * Salida: int
         */
        public int ID_Categoria
        {
            get
            {
                return (this.iD_Categoria);
            }
            set
            {
                this.iD_Categoria = value;
                OnPropertyChanged("ID_Categoria");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo int
         * Entrada: void
         * Salida: int
         */
        public int ID_Promocion
        {
            get
            {
                return (this.iD_Promocion);
            }
            set
            {
                this.iD_Promocion = value;
                OnPropertyChanged("ID_Promocion");
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
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo string
         * Entrada: void
         * Salida: string
         */
        public string Fabricante
        {
            get
            {
                return (this.fabricante);
            }
            set
            {
                this.fabricante = value;
                OnPropertyChanged("Fabricante");
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo descriptor de acceso que declara una propiedad de tipo int
         * Entrada: void
         * Salida: int
         */
        public int Stock
        {
            get
            {
                return (this.stock);
            }
            set
            {
                this.stock = value;
                OnPropertyChanged("Stock");
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
        public ProductoViewModel()
        { }

        /* 
         * Metodo
         * Descripcion: Metodo constructor que recibe un objeto de tipo Productos e hidrata el view model producto
         * Entrada: Productos
         * Salida: void
         */
        public ProductoViewModel(Productos producto)
        {
            ID_Producto = producto.ID_Producto;
            ID_Categoria = producto.ID_Categoria;
            ID_Promocion = producto.ID_Promocion;
            NombreProducto = producto.NombreProducto;
            Codigo = producto.Codigo;
            Descripcion = producto.Descripcion;
            Fabricante = producto.Fabricante;
            Stock = producto.Stock;
            Impuesto = producto.Impuesto;
            ValorUnitario = producto.ValorUnitario;
            Estado = producto.Estado;
        }

        /* 
         * Metodo
         * Descripcion: Genera una entidad para ser transportada por las capas
         * Entrada: void
         * Salida: Productos
         */
        public Productos ObtenerEntidad()
        {
            return (new Productos
            {
                ID_Producto = this.iD_Producto,
                ID_Categoria = this.iD_Categoria,
                ID_Promocion = this.iD_Promocion,
                NombreProducto = this.nombreProducto,
                Codigo = this.codigo,
                Descripcion = this.descripcion,
                Fabricante = this.fabricante,
                Stock = this.stock,
                Impuesto = this.impuesto,
                ValorUnitario = this.valorUnitario,
                Estado = this.estado
            });
        }
    }
}
