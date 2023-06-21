using Dominio;
using Logica;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Lógica de interacción para CarritoCliente.xaml
    /// </summary>
    public partial class CarritoCliente : Page
    {

        private List<ProductoCarrito> productos = new List<ProductoCarrito>();
        private Persona persona = new Persona();
        private int precioVenta = 0;
        private List<Billetera> billeteras = new List<Billetera>();

        public CarritoCliente(string username)
        {
            InitializeComponent();
            if (RecuperarPersona(username))
            {
                IniciarTabla();
            }
            else
            {
                MessageBox.Show("Error al recuperar los productos del carrito");
            }
            
        }

        private bool RecuperarPersona(string username)
        {
            bool resultado = true; 
            string respuestaUsuario = ConexionAPI.GetNoToken("http://localhost:8080/api/getUser/"+username);
            persona = JsonConvert.DeserializeObject<Persona>(respuestaUsuario);
            if(persona == null)
            {
                resultado = false;
            }
            return resultado;
        }

        private void IniciarTabla()
        {
            string respuesta = ConexionAPI.GetNoToken("http://localhost:8080/api/person/"+persona.idPerson+"/shoppings");
            if (respuesta == null)
            {
                MessageBox.Show("No existen registros de Productos. Favor de intentarlo más tarde.");
            }
            else
            {
                List<Carrito> carritos = new List<Carrito>();
                carritos = JsonConvert.DeserializeObject<List<Carrito>>(respuesta);
                foreach (Carrito carrito in carritos)
                {
                    string respuestaProductos = ConexionAPI.GetNoToken("http://localhost:8080/api/getProduct/" + carrito.idProduct);
                    Producto producto = JsonConvert.DeserializeObject<Producto>(respuestaProductos);
                    ProductoCarrito productoCarrito = new ProductoCarrito()
                    {
                        idProduct = producto.idProduct,
                        available = producto.available,
                        category = producto.category,
                        description = producto.description,
                        idShopping = carrito.idShopping,
                        name = producto.name,
                        price = producto.price,
                        productPhoto = producto.productPhoto,
                        size = producto.size
                    };
                    
                    precioVenta += producto.price;
                    productos.Add(productoCarrito);
                }

                tableProductos.ItemsSource = productos;
                precioTotal.Content = "Precio a pagar: $"+ precioVenta;
            }
        }

        private void Btn_RealizarCompra_Click(object sender, RoutedEventArgs e)
        {
            string respuesta = ConexionAPI.GetNoToken("http://localhost:8080/api/getWalletByUser/" + persona.idPerson);

            if (respuesta.Equals("[]"))
            {
                MessageBox.Show("No existen billeteras registradas. Favor de registrar alguna antes de continuar.");
            }
            else
            {
                if(productos.Count == 0)
                {
                    MessageBox.Show("Favor de agregar productos al carrito antes de realizar una compra");
                }
                else
                {
                    billeteras = JsonConvert.DeserializeObject<List<Billetera>>(respuesta);
                    RealizarCompra realizarCompra = new RealizarCompra(persona, productos, precioVenta, billeteras);
                    realizarCompra.ShowDialog();
                    precioVenta = 0;
                    productos = new List<ProductoCarrito>();
                    IniciarTabla();
                }
            }
        }
        
        private void Button_EliminarDelCarrito_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                var row = DataGridRow.GetRowContainingElement(btn);
                var item = row.Item;
                if (item != null && tableProductos.Items.Contains(item))
                {
                    var producto = tableProductos.SelectedItem as ProductoCarrito;
                    dynamic respuesta = ConexionAPI.DeleteToken("http://localhost:8080/api/shopping/" + producto.idShopping);
                    RespuestaAPI auth = JsonConvert.DeserializeObject<RespuestaAPI>(respuesta.Content);
                    if (auth.message.Equals("Shopping deleted"))
                    {
                        MessageBox.Show("Se ha eliminado con exito el producto");
                        precioVenta = 0;
                        productos = new List<ProductoCarrito>();
                        IniciarTabla();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el producto, favor de intentarlo más tarde");
                    }
                }
            }
        }
    }
}
