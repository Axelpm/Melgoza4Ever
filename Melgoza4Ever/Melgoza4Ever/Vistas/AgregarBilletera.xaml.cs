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
using System.Windows.Shapes;

namespace Melgoza4Ever.Vistas
{
    /// <summary>
    /// Lógica de interacción para AgregarBilletera.xaml
    /// </summary>
    public partial class AgregarBilletera : Window
    {
        string username;

        public AgregarBilletera(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCampos())
            {
                string respuestaUsuario = ConexionAPI.GetNoToken("http://localhost:8080/api/getUser/"+username);
                Persona persona = JsonConvert.DeserializeObject<Persona>(respuestaUsuario);


                string json = "{\"direction\": \"" + text_Direccion.Text.Trim() + "\",\"numberCard\": \"" + text_NumeroTarjeta.Text.Trim() +
                    "\",\"idPerson\": \"" + persona.idPerson + "\"}";
                
                dynamic respuesta = ConexionAPI.PostNoToken("http://localhost:8080/api/wallet", json);
                RespuestaAPI respuestaAPI = JsonConvert.DeserializeObject<RespuestaAPI>(respuesta.Content);
                if(respuestaAPI.message.Equals("Wallet created"))
                {
                    MessageBox.Show("Se ha creado la cartera con exito");
                    Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar la cartera en la base de datos");
                }
            }
        }


        private bool ValidarCampos()
        {
            bool resultado = true;
            string stringCamposError = "";
            if(!Utilidades.ValidateFormat(text_Direccion.Text.Trim(), "^[a-zA-Z]+([ \\-][a-zA-Z]+)*$"))
            {
                stringCamposError += " Dirección,";
                resultado = false;
            }
            if(!Utilidades.ValidateFormat(text_NumeroTarjeta.Text.Trim(), "^[0-9]+$") )
            {
                stringCamposError += " Numero de Tarjeta";
                resultado = false;
            }
            if(text_NumeroTarjeta.Text.Length < 16 || text_NumeroTarjeta.Text.Length > 28)
            {
                stringCamposError += " Numero de Tarjeta longitud deber ser mayor a 15 y menor a 29";
                resultado = false;
            }
            if (!resultado)
            {
                MessageBox.Show("Error en los formatos de los campos: " + stringCamposError);
            }
            return resultado;
        }
    }
}
