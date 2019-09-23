/*
 * Nombre de la Clase: RelayCommand
 * Descripcion: Clase base para generar comandos en la UI
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 14/12/2015
 */

/*
 * Listado de Metodos:
 * >> RelayCommand(Action<object> execute)
 * >> RelayCommand(Action<object> execute, Predicate<object> canExecute)
 * >> bool CanExecute(object parameter)
 * >> event EventHandler CanExecuteChanged
 * >> void Execute(object parameter)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace User_Interface_WPF.ViewModels
{
    public class RelayCommand : ICommand
    {
        #region Fields
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        #endregion

        #region Constructors
        /* 
         * Metodo
         * Descripcion: Crea un nuevo comando que siempre se puede ejecutar
         * Entrada: Action<object>
         * Salida: void
         */
        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }

        /* 
         * Metodo
         * Descripcion: Crea un nuevo comando
         * Entrada: Action<object>, Predicate<object>
         * Salida: void
         */
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        #region ICommand Members
        /* 
         * Metodo
         * Descripcion: Metodo que indica si se peude ejecutar el comando
         * Entrada: object
         * Salida: bool
         */
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        /* 
         * Metodo
         * Descripcion: Evento que monitorea el cambio en las condiciones de ejecucion del evento
         * Entrada: void
         * Salida: void
         */
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /* 
         * Metodo
         * Descripcion: Metodo que representa la ejecución del evento
         * Entrada: object
         * Salida: void
         */
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        #endregion
    }
}
