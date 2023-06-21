using Dominio;
using Logica;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para ConsultarBilleteras.xaml
    /// </summary>
    public partial class ConsultarBilleteras : Page
    {

        string newUsername;
        List<Billetera> billeteras = new List<Billetera>();

        public ConsultarBilleteras(string username)
        {
            InitializeComponent();
            newUsername = username;
            IniciarTabla();
        }

        private void IniciarTabla()
        {
            string respuestaUsuario = ConexionAPI.GetNoToken("http://localhost:8080/api/getUser/"+newUsername);
            Persona persona = JsonConvert.DeserializeObject<Persona>(respuestaUsuario);



            string respuesta = ConexionAPI.GetNoToken("http://localhost:8080/api/getWalletByUser/"+persona.idPerson);

            if (respuesta.Equals("[]"))
            {
                MessageBox.Show("No existen registros de Billeteras. Favor de registrar una billetera.");
            }
            else
            {
                billeteras = JsonConvert.DeserializeObject<List<Billetera>>(respuesta);
                
                tableProductos.ItemsSource = billeteras;
            }
        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Content = null;
        }


        private void Button_EditarBilletera_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                var row = DataGridRow.GetRowContainingElement(btn);
                var item = row.Item;
                if (item != null && tableProductos.Items.Contains(item))
                {
                    var wallet = tableProductos.SelectedItem as Billetera;
                    EditarBilletera editarBilletera = new EditarBilletera(wallet);
                    editarBilletera.ShowDialog();
                    IniciarTabla();
                }
            }
        }


        private void Button_EliminarBilletera_Click (object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                var row = DataGridRow.GetRowContainingElement(btn);
                var item = row.Item;
                if (item != null && tableProductos.Items.Contains(item))
                {
                    var wallet = tableProductos.SelectedItem as Billetera;
                    dynamic respuesta = ConexionAPI.DeleteToken("http://localhost:8080/api/deleteWallet/" + wallet.idWallet);
                    RespuestaAPI auth = JsonConvert.DeserializeObject<RespuestaAPI>(respuesta.Content);
                    if (auth.message.Equals("Se ha eliminado " + wallet.idWallet))
                    {
                        MessageBox.Show("Se ha eliminado con exito la billetera");
                        IniciarTabla();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la billetera, favor de intentarlo más tarde");
                    }
                }
            }
        }
    }
}
