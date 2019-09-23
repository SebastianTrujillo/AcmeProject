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
    /// Interaction logic for BuscarProductoView.xaml
    /// </summary>
    public partial class BuscarProductoView : UserControl
    {
        public BuscarProductoView()
        {
            InitializeComponent();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnBuscarProducto.Focus();
            }
        }
    }
}
