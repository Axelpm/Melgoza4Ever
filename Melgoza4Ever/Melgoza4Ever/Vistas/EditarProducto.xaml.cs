using Dominio;
using Logica;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
    /// Lógica de interacción para EditarProducto.xaml
    /// </summary>
    public partial class EditarProducto : Window
    {

        bool imageValidation = false;
        string pathProfilePhoto = "";
        S3Service service = new S3Service();
        int idProducto = 0;

        public EditarProducto(Producto producto)
        {
            InitializeComponent();
            comBox_Categoria.Items.Add("Tennis");
            comBox_Categoria.Items.Add("Zapato");
            comBox_Categoria.Items.Add("Botas");
            IniciarElementos(producto);
        }

        private void IniciarElementos(Producto producto)
        {
            text_Nombre.Text = producto.name;
            text_Talla.Text = "" + producto.size;
            text_Precio.Text = "" + producto.price;
            text_Disponibilidad.Text = "" + producto.available;
            text_Descripcion.Text = producto.description;
            idProducto = producto.idProduct;
            imagenProducto.Source = new BitmapImage(new Uri(producto.productPhoto));
            switch (producto.category)
            {
                case "Tennis":
                    comBox_Categoria.SelectedIndex = 0;
                    break;
                case "Zapato":
                    comBox_Categoria.SelectedIndex = 1;
                    break;
                case "Botas":
                    comBox_Categoria.SelectedIndex = 2;
                    break;
            }
        }

        private void Btn_AddImage1_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == true)
            {
                pathProfilePhoto = openFileDialog.FileName;
                ImageSourceConverter converter = new ImageSourceConverter();
                imagenProducto.Source = (ImageSource)converter.ConvertFromString(pathProfilePhoto);
                imageValidation = true;
            }
        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            var window = (MainWindow)App.Current.MainWindow;
            window.PrimaryContainer.Navigate(new ConsultarProductoAdministrador());
        }

        private void Btn_Editar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCampos())
            {
                EditarProductoAsync();
            }
        }

        private async Task EditarProductoAsync()
        {
            bool uploadSuccess = await service.UploadImage(pathProfilePhoto, text_Nombre.Text.Trim());
            if (uploadSuccess)
            {
                string imageUrl = service.GetImageURL(text_Nombre.Text.Trim());
                string category = comBox_Categoria.SelectedItem.ToString();
                string json = "{\"name\": \"" + text_Nombre.Text.Trim() + "\",\"category\": \"" + category +
                    "\",\"price\": \"" + text_Precio.Text.Trim() + "\",\"description\": \"" + text_Descripcion.Text.Trim() +
                    "\",\"available\": \"" + text_Disponibilidad.Text.Trim() + "\",\"size\": \"" + text_Talla.Text.Trim() +
                    "\",\"productPhoto\": \"" + imageUrl + "\"}";
                string respuesta = ConexionAPI.PutNoToken("http://localhost:8080/api/UpdateProduct/"+idProducto, json);
                RespuestaAPI respuestaRegistrar = JsonConvert.DeserializeObject<RespuestaAPI>(respuesta);
                if(respuestaRegistrar.message.Equals("Producto Actualizado con exito"))
                {
                    MessageBox.Show("Se ha editado el producto con exito");
                    Close();
                }
                else
                {
                    MessageBox.Show("Error al editar el producto en la base de datos");
                }
            }
        }

        private bool ValidarCampos()
        {
            bool resultado = true;
            string camposInvalidos = "";

            if (!Utilidades.ValidateFormat(text_Nombre.Text.Trim(), "^[a-zA-Z]+([ \\-][a-zA-Z]+)*$"))
            {
                camposInvalidos += " Nombre,";
                resultado = false;
            }
            if (!Utilidades.ValidateFormat(text_Descripcion.Text.Trim(), "^[a-zA-Z]+([ \\-][a-zA-Z]+)*$"))
            {
                camposInvalidos += " Descripción,";
                resultado = false;
            }
            if (!Utilidades.ValidateFormat(text_Disponibilidad.Text.Trim(), "^[0-9]+$"))
            {
                camposInvalidos += " Disponibilidad,";
                resultado = false;
            }
            if (!Utilidades.ValidateFormat(text_Precio.Text.Trim(), "^[0-9]+$"))
            {
                camposInvalidos += " Precio,";
                resultado = false;
            }
            if (!Utilidades.ValidateFormat(text_Talla.Text.Trim(), "^[0-9]+$"))
            {
                camposInvalidos += " Talla,";
                resultado = false;
            }
            if (comBox_Categoria.SelectedIndex == -1)
            {
                camposInvalidos += " Categoria,";
                resultado = false;
            }
            if (!imageValidation)
            {
                camposInvalidos += " Imagen";
                resultado = false;
            }
            if (!resultado)
            {
                MessageBox.Show("Favor de verificar los siguientes campos: " + camposInvalidos);
            }
            return resultado;
        }


    }
}
