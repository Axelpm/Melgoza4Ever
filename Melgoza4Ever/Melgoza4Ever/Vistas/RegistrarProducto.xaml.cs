using Dominio;
using Logica;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using System.Xml.Linq;

namespace Melgoza4Ever.Vistas
{
    /// <summary>
    /// Lógica de interacción para RegistrarProducto.xaml
    /// </summary>
    public partial class RegistrarProducto : Window
    {
        string pathProfilePhoto = "";
        S3Service service = new S3Service();
        bool imageValidation = false;

        public RegistrarProducto()
        {
            InitializeComponent();
            comBox_Categoria.Items.Add("Tennis");
            comBox_Categoria.Items.Add("Zapato");
            comBox_Categoria.Items.Add("Botas");
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
                componentImageOne.Source = (ImageSource)converter.ConvertFromString(pathProfilePhoto);
                imageValidation = true;
            }
        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
            if(!Utilidades.ValidateFormat(text_Precio.Text.Trim(), "^[0-9]+$"))
            {
                camposInvalidos += " Precio,";
                resultado = false;
            }
            if(!Utilidades.ValidateFormat(text_Talla.Text.Trim(), "^[0-9]+$"))
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
            if(!resultado)
            {
                MessageBox.Show("Favor de verificar los siguientes campos: " + camposInvalidos);
            }
                return resultado;
        }

        private void Btn_Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCampos())
            {
                if (!String.IsNullOrEmpty(pathProfilePhoto))
                {
                    
                    RegistrarNuevoProductoAsync();
                }
            }
        }

        private async Task RegistrarNuevoProductoAsync()
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
                dynamic respuesta = ConexionAPI.PostNoToken("http://localhost:8080/api/product", json);
                RespuestaAPI respuestaRegistrar = JsonConvert.DeserializeObject<RespuestaAPI>(respuesta.Content);
                if (respuestaRegistrar.message.Equals("Product created"))
                {
                    MessageBox.Show("Se ha registrado el producto con exito");
                    Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar el producto en la base de datos");
                }
            }
        }
    }
}
