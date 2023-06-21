using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Melgoza4Ever.Vistas
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipalCliente.xaml
    /// </summary>
    public partial class MenuPrincipalCliente : Page
    {
        string username;

        public MenuPrincipalCliente(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void itemProductos_Click(object sender, RoutedEventArgs e)
        {
            Container.NavigationService.Navigate(new ConsultarProductoCliente(username));
        }

        private void itemCarrito_Click(object sender, RoutedEventArgs e) 
        {
            Container.NavigationService.Navigate(new CarritoCliente(username));
        }

        private void itemAgregarBilletera_Click(object sender, RoutedEventArgs e) 
        {
            AgregarBilletera agregarBilletera = new AgregarBilletera(username);
            agregarBilletera.ShowDialog();
        }

        private void itemConsultarBilletera_Click(object sender, RoutedEventArgs e)
        {
            Container.NavigationService.Navigate(new ConsultarBilleteras(username));
        }

        private void itemExit_Click(object sender, RoutedEventArgs e) 
        {
            var window = (MainWindow)App.Current.MainWindow;
            window.PrimaryContainer.Navigate(new InicioSesion());
        }

    }
}
