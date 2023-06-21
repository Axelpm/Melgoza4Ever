using Logica;
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
using System.Windows.Shapes;

namespace Melgoza4Ever.Vistas
{
    /// <summary>
    /// Lógica de interacción para ConsultarProducto.xaml
    /// </summary>
    public partial class ConsultarProducto : Window
    {
        public ConsultarProducto(Producto producto)
        {
            InitializeComponent();
            label_Nombre.Content = producto.name;
            label_Precio.Content += producto.price.ToString();
            label_Descripcion.Content = producto.description;
            label_Categoria.Content = producto.category;
            label_Disponibilidad.Content = producto.available;
            label_Talla.Content = producto.size;
            imagenProducto.Source = new BitmapImage(new Uri(producto.productPhoto));
        }

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
