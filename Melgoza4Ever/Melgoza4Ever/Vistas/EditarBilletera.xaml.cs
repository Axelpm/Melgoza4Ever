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
    /// Lógica de interacción para EditarBilletera.xaml
    /// </summary>
    public partial class EditarBilletera : Window
    {
        Billetera newBilletera = new Billetera();

        public EditarBilletera(Billetera billetera)
        {
            InitializeComponent();
            newBilletera = billetera;
            text_Direccion.Text = billetera.direction;
            text_NumeroTarjeta.Text = billetera.numberCard;
        }

        private void btn_Editar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCampos())
            {
                string json = "{\"direction\": \"" + text_Direccion.Text.Trim() + "\",\"numberCard\": \"" + text_NumeroTarjeta.Text.Trim() +
                    "\",\"idPerson\": \"" + newBilletera.idPerson + "\"}";
                string respuesta = ConexionAPI.PutNoToken("http://localhost:8080/api/updateWallet/"+ newBilletera.idWallet , json);
                RespuestaAPI respuestaRegistrar = JsonConvert.DeserializeObject<RespuestaAPI>(respuesta);
                if(respuestaRegistrar.message.Equals("Billetera Actualizado con exito"))
                {
                    MessageBox.Show("Se ha actualizado la billetera con exito");
                    Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la billetera en la base de datos");
                }

            }
        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private bool ValidarCampos()
        {
            bool resultado = true;
            string stringCamposError = "";
            if (!Utilidades.ValidateFormat(text_Direccion.Text.Trim(), "^[a-zA-Z]+([ \\-][a-zA-Z]+)*$"))
            {
                stringCamposError += " Dirección,";
                resultado = false;
            }
            if (!Utilidades.ValidateFormat(text_NumeroTarjeta.Text.Trim(), "^[0-9]+$") )
            {
                stringCamposError += " Numero de Tarjeta";
                resultado = false;
            }
            if (text_NumeroTarjeta.Text.Length < 16 || text_NumeroTarjeta.Text.Length > 28)
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
