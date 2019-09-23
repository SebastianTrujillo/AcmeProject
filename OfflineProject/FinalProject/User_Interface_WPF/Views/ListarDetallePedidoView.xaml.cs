using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace User_Interface_WPF.Views
{
    /// <summary>
    /// Interaction logic for ListarDetallePedidoView.xaml
    /// </summary>
    public partial class ListarDetallePedidoView : UserControl
    {
        public ListarDetallePedidoView()
        {
            InitializeComponent();
        }

        private void txtCantidadProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnAgregarProducto.Focus();
            }
        }
        
        private void AgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            txtCantidadProducto.Focus();
        }
    }
}
