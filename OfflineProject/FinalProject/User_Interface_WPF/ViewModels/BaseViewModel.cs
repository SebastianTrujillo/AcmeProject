/*
 * Nombre de la Clase: BaseViewModel
 * Descripcion: Clase base para las notificaciones y los bindings
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> bool EstaOcupado
 * >> ObservableCollection<string> Error
 * >> void OnPropertyChanged(string propertyName)
 * >> void Dispose()
 * >> virtual void OnDispose()
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace User_Interface_WPF.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        #region atributos
        private bool _estaOcupado;
        ObservableCollection<string> _error;
        #endregion

        #region propiedades
        /* 
         * Metodo
         * Descripcion: Esta propiedad indica si se esta haciendo alguna operacion que necesite sincronizacion con la vista
         * Entrada: void
         * Salida: bool
         */
        public bool EstaOcupado
        {
            get
            {
                return _estaOcupado;
            }
            set
            {
                _estaOcupado = value;
                OnPropertyChanged("EstaOcupado");
            }
        }

        /* 
         * Metodo
         * Descripcion: Mensaje de error cuando ocurre
         * Entrada: void
         * Salida: ObservableCollection<string>
         */
        public ObservableCollection<string> Error
        {
            get
            {
                if (_error == null)
                    _error = new ObservableCollection<string>();
                return _error;
            }
            set
            {
                _error = value;
                OnPropertyChanged("Error");
            }
        }
        #endregion

        /* 
         * Metodo
         * Descripcion: Crear el metodo OnPropertyChanged para el evento
         * Entrada: string
         * Salida: void
         */
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /* 
         * Metodo
         * Descripcion: Llamado al metodo OnDispose()
         * Entrada: void
         * Salida: void
         */
        public void Dispose()
        {
            this.OnDispose();
        }

        /* 
         * Metodo
         * Descripcion: Lanza una excepcion para metodo que no ha sido desarrollado
         * Entrada: void
         * Salida: void
         */
        protected virtual void OnDispose()
        {
            throw new NotImplementedException();
        }
    }
}
