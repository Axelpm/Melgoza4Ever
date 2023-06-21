using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Logica;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dominio;
using Newtonsoft.Json;

namespace Melgoza4Ever.Vistas
{
    /// <summary>
    /// Lógica de interacción para InicioSesion.xaml
    /// </summary>
    public partial class InicioSesion : Page
    {


        public InicioSesion()
        {
            InitializeComponent();
        }

        private async void IniciarSesion_Click(object sender, RoutedEventArgs e)
        {

            PersonaLogin personaLogin = new PersonaLogin();
            personaLogin.username = text_NombreUsuario.Text;
            personaLogin.password = password_Contraseña.Password;
            try
            {
                string json = "{\"username\": \"" + text_NombreUsuario.Text.Trim() + "\",\"password\": \"" + password_Contraseña.Password.Trim() + "\"}";
                dynamic respuesta = ConexionAPI.PostNoToken("http://localhost:8080/api/login", json);
                Token auth = JsonConvert.DeserializeObject<Token>(respuesta.Content);
                if (auth.username == null)
                {
                    MessageBox.Show("No existe el cliente");
                }
                else
                {
                    RedireccionarVentana(auth);
                }



            }
            catch (Exception)
            {

            }


        }

        private void RedireccionarVentana(Token auth)
        {
            if (auth.role == 1)
            {
                var window = (MainWindow)App.Current.MainWindow;
                window.PrimaryContainer.Navigate(new MenuPrincipalCliente(text_NombreUsuario.Text.Trim()));
            }
            else
            {
                var window = (MainWindow)App.Current.MainWindow;
                window.PrimaryContainer.Navigate(new MenuPrincipalAdministrador());
            }
        }
    }
}
