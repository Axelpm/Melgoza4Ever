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
    /// Lógica de interacción para RealizarCompra.xaml
    /// </summary>
    public partial class RealizarCompra : Window
    {
        private List<ProductoCarrito> productos = new List<ProductoCarrito>();
        private Persona persona = new Persona();
        private int precioVenta = 0;
        private List<Billetera> billeteras = new List<Billetera>();
        private bool realizarVenta = true;

        public RealizarCompra(Persona persona, List<ProductoCarrito> productos, int precioVenta, List<Billetera> billeteras)
        {
            InitializeComponent();
            this.persona = persona;
            this.productos = productos;
            this.billeteras = billeteras;
            this.precioVenta = precioVenta;
            tableProductos.ItemsSource = productos;
            label_Direccion.Content = "Direccion: " + billeteras[0].direction;
            label_nombreCliente.Content = "Nombre del comprador: " + persona.name + " " + persona.paternalSurname + " " + persona.maternalSurname;
            label_precioTotal.Content = "Precio a pagar: $" + precioVenta;
        }

        private void Btn_RealizarCompra_Click(object sender, RoutedEventArgs e)
        {
            foreach (ProductoCarrito producto in productos)
            {
                string respuestaProductos = ConexionAPI.GetNoToken("http://localhost:8080/api/getProduct/" + producto.idProduct);
                Producto productoNormal = JsonConvert.DeserializeObject<Producto>(respuestaProductos);

                if ((productoNormal.available - 1) < 0)
                {
                    realizarVenta = false;
                    productoNormal.available -= 1;
                    string json = "{\"available\": \"" + productoNormal.available + "\"}";
                    string respuesta = ConexionAPI.PutNoToken("http://localhost:8080/api/UpdateProduct/" + producto.idProduct, json);
                    RespuestaAPI respuestaAPI = JsonConvert.DeserializeObject<RespuestaAPI>(respuesta);
                    
                }
                else
                {

                    productoNormal.available -= 1;
                    string json = "{\"available\": \"" + productoNormal.available + "\"}";
                    string respuesta = ConexionAPI.PutNoToken("http://localhost:8080/api/UpdateProduct/" + producto.idProduct, json);
                    RespuestaAPI respuestaAPI = JsonConvert.DeserializeObject<RespuestaAPI>(respuesta);
                    if (!respuestaAPI.message.Equals("Producto Actualizado con exito"))
                    {
                        realizarVenta = false;
                    }
                }
            }

            if (realizarVenta)
            {
                dynamic respuesta = ConexionAPI.DeleteToken("http://localhost:8080/api//deleteAllShoppings/" + persona.idPerson);
                RespuestaAPI respuestaRegistrar = JsonConvert.DeserializeObject<RespuestaAPI>(respuesta.Content);
                if (respuestaRegistrar.message.Equals("All shoppings deleted"))
                {
                    MessageBox.Show("La compra se ha realizado con exito");
                    Close();
                }
                else
                {
                    MessageBox.Show("Error al realizar la compra, favor de intentarlo más tarde");
                }
            }
            else
            {
                MessageBox.Show("Error al realizar la compra, los productos que intenta comprar no cuentan con el sufiente stock para concretar la compra");

                foreach (ProductoCarrito producto in productos)
                {
                    string respuestaProductos = ConexionAPI.GetNoToken("http://localhost:8080/api/getProduct/" + producto.idProduct);
                    Producto productoNormal = JsonConvert.DeserializeObject<Producto>(respuestaProductos);


                    productoNormal.available += 1;
                    string json = "{\"available\": \"" + productoNormal.available + "\"}";
                    string respuesta = ConexionAPI.PutNoToken("http://localhost:8080/api/UpdateProduct/" + producto.idProduct, json);
                    RespuestaAPI respuestaAPI = JsonConvert.DeserializeObject<RespuestaAPI>(respuesta);
                }
                MessageBox.Show("Regresando al carrito de compras");
                Close();
            }
        }
    }
}
