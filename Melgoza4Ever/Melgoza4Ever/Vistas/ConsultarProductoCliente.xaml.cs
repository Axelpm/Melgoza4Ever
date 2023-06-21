using Dominio;
using Logica;
using Newtonsoft.Json;
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
    /// Lógica de interacción para ConsultarProductoCliente.xaml
    /// </summary>
    public partial class ConsultarProductoCliente : Page
    {

        private List<Producto> productos = new List<Producto>();
        private List<string> _listaNombres = new List<string>();
        private List<string> _listaCategorias = new List<string>();
        private Persona persona = new Persona();



        private void IniciarTabla()
        {
            string respuesta = ConexionAPI.GetNoToken("http://localhost:8080/api/getAllProducts");
            if(respuesta == null)
            {
                MessageBox.Show("No existen registros de Productos. Favor de intentarlo más tarde.");
            }
            else
            {
                productos = JsonConvert.DeserializeObject<List<Producto>>(respuesta);
                productos.ForEach(producto => _listaNombres.Add(producto.name));
                productos.ForEach(producto => _listaCategorias.Add(producto.category));

                tableProductos.ItemsSource = productos;
            }
            
        }

        public ConsultarProductoCliente(string username)
        {
            InitializeComponent();
            comBox_TypeSearch.Items.Add("Categoria");
            comBox_TypeSearch.Items.Add("Nombre del producto");
            BuscarUsuario(username);
            IniciarTabla();
        }

        private void BuscarUsuario(string username)
        {
            string respuestaUsuario = ConexionAPI.GetNoToken("http://localhost:8080/api/getUser/"+username);
            persona = JsonConvert.DeserializeObject<Persona>(respuestaUsuario);
            if(persona == null)
            {
                MessageBox.Show("Error al inicializar la ventana, favor de intentarlo más tarde");
                this.Content = null;
            }
        }

        private void Button_ConsultarProducto_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                var row = DataGridRow.GetRowContainingElement(btn);
                var item = row.Item;
                if (item != null && tableProductos.Items.Contains(item))
                {
                    var producto = tableProductos.SelectedItem as Producto;
                    ConsultarProducto consultarProducto = new ConsultarProducto(producto);
                    consultarProducto.ShowDialog();
                }
            }
        }
        private void Button_AgregarCarrito_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                var row = DataGridRow.GetRowContainingElement(btn);
                var item = row.Item;
                if (item != null && tableProductos.Items.Contains(item))
                {
                    var producto = tableProductos.SelectedItem as Producto;
                    string json = "{\"state\": \"" + true + "\",\"idPerson\": \"" + persona.idPerson +
                    "\",\"idProduct\": \"" + producto.idProduct + "\"}";
                    dynamic respuesta = ConexionAPI.PostNoToken("http://localhost:8080/api/Shopping", json);
                    RespuestaAPI auth = JsonConvert.DeserializeObject<RespuestaAPI>(respuesta.Content);
                    if (auth.message.Equals("ShoppingCar created"))
                    {
                        MessageBox.Show("Se ha agregado un producto al carrito de compras");
                    }
                }
            }
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            tableProductos.ItemsSource = productos;
            switch (comBox_TypeSearch.SelectedIndex)
            {
                case -1:
                    MessageBox.Show("Favor de seleccionar el tipo de dato con el que desea buscar el producto");
                    break;

                case 0:
                    if (!Utilidades.ValidateFormat(text_SearchBy.Text.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\\s]+$"))
                    {
                        MessageBox.Show("Solo se aceptan letras para esta busqueda");
                    }
                    else
                    {
                        SearchByCategory();
                    }
                    break;

                case 1:
                    if (!Utilidades.ValidateFormat(text_SearchBy.Text.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\\s]+$"))
                    {
                        MessageBox.Show("Solo se aceptan letras para esta busqueda");
                    }
                    else
                    {
                        SearchByName();
                    }
                    break;
            }
        }

        private void SearchByCategory()
        {
            if (!String.IsNullOrEmpty(text_SearchBy.Text.Trim()))
            {
                List<Producto> ProductosEquals = (_listaCategorias.Where(stringCategoria =>
                stringCategoria.StartsWith(text_SearchBy.Text.Trim())).Select(stringCategoria =>
                productos.Find(productoEncontrado => productoEncontrado.category.Contains(stringCategoria)))).ToList();
                tableProductos.ItemsSource = ProductosEquals;
            }
            else if (text_SearchBy.Text.Trim() == "")
            {
                tableProductos.ItemsSource = productos;
            }
        }

        private void SearchByName()
        {
            if (!String.IsNullOrEmpty(text_SearchBy.Text.Trim()))
            {
                List<Producto> ProductosEquals = (_listaNombres.Where(stringName =>
                stringName.StartsWith(text_SearchBy.Text.Trim())).Select(stringName =>
                productos.Find(productoEncontrado => productoEncontrado.name.Contains(stringName)))).ToList();
                tableProductos.ItemsSource = ProductosEquals;
            }
            else if (text_SearchBy.Text.Trim() == "")
            {
                tableProductos.ItemsSource = productos;
            }
        }

        private void Btn_Restore_Click(object sender, RoutedEventArgs e)
        {
            text_SearchBy.Text = "";
            _listaNombres.Clear();
            _listaCategorias.Clear();
            IniciarTabla();
        }
    }
}
