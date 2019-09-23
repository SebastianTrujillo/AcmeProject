using Business_Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace User_Interface_WPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();           
        }

        private void autenticarVendedores(object sender, RoutedEventArgs e)
        {
            VendedoresBL contexto = new VendedoresBL();

            string nombreUsuario = txtNombreUsuario.Text;

            string contrasenia = passContrasenia.Password;

            bool resultado = contexto.AutenticarVendedores(nombreUsuario, contrasenia);
        
            if (resultado)
            {
                MainWindow mainWindow = new MainWindow();
                this.Hide();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña no validos.", "Login Invalido", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtNombreUsuario.Clear();
                passContrasenia.Clear();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtNombreUsuario.Focus();
        }

        private void txtNombreUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                passContrasenia.Focus();
            }
        }

        private void passContrasenia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnIngresar.Focus();
            }
        }
    }
}
