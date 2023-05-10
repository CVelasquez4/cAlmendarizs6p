using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.WebRequestMethods;

namespace cAlmendarizs6p
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Editar : ContentPage
    {
        public Editar(int codigo, string nombre, string apellido, int edad)
        {
            InitializeComponent();
            lblCodigo.Text = codigo.ToString();
            lblNombre.Text  = nombre.ToString();
            lblApellido.Text = apellido.ToString();
            lblEdad.Text = edad.ToString();
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            // Obtener los datos actualizados de los campos de entrada
            var codigo = int.Parse(lblCodigo.Text);
            var nombre = lblNombre.Text;
            var apellido = lblApellido.Text;
            var edad = int.Parse(lblEdad.Text);

            WebClient client = new WebClient();
            //SearchBar envia como parametro necesario , se inicializa y se envia vacio
            var parametros = new System.Collections.Specialized.NameValueCollection();

            //Para ejecutar el consumo , se contruira la url y se enviara asi
            //
            string url = "http://192.168.100.159:81/moviles/post.php" 
                + "?codigo=" + lblCodigo.Text 
                + "&nombre=" + lblNombre.Text
                + "&apellido=" + lblApellido.Text
                + "&edad=" + lblEdad.Text;

            byte[] response = client.UploadValues(url, "PUT", parametros);

            // Decodificar la respuesta a una cadena de texto
            string result = Encoding.UTF8.GetString(response);

            //Label respuesta es ok 
            if (result == "  \r\n\r\n") 
            {
                string status = client.ResponseHeaders["Status"];
             
                // La solicitud PUT fue exitosa
                await DisplayAlert("Actualización exitosa", "Los datos se actualizaron correctamente.", "OK");
                
            }
            else
            {
                // Ocurrió un error en la solicitud
                await DisplayAlert("Error", "Ocurrió un error en la solicitud.", "OK");
            }


        }
           

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            // Obtener los datos actualizados de los campos de entrada
            var codigo = int.Parse(lblCodigo.Text);
            

            WebClient client = new WebClient();
            //SearchBar envia como parametro necesario , se inicializa y se envia vacio
            var parametros = new System.Collections.Specialized.NameValueCollection();

            //Para ejecutar el consumo , se contruira la url y se enviara asi
            //
            string url = "http://192.168.100.159:81/moviles/post.php"
                + "?codigo=" + lblCodigo.Text;

            byte[] response = client.UploadValues(url, "DELETE", parametros);

            // Decodificar la respuesta a una cadena de texto
            string result = Encoding.UTF8.GetString(response);

            //Label respuesta es ok 
            if (result == "  \r\n\r\n")
            {
                string status = client.ResponseHeaders["Status"];

                // La solicitud PUT fue exitosa
                await DisplayAlert("Actualización exitosa", "Los datos se eliminaron correctamente.", "OK");

            }
            else
            {
                // Ocurrió un error en la solicitud
                await DisplayAlert("Error", "Ocurrió un error en la solicitud.", "OK");
            }

        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}