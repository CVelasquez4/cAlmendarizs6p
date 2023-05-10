using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cAlmendarizs6p
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try

            {
                WebClient client = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection ();
                parametros.Add("codigo", txtCodigo.Text); //5
                parametros.Add("nombre", txtNombre.Text); //Universidad
                parametros.Add("apellido", txtApellido.Text); //Israel
                parametros.Add("edad", txtEdad.Text); //23

                client.UploadValues("http://192.168.100.159:81/moviles/post.php", "POST", parametros);
                DisplayAlert ("Alerta", "Dato ingresado", "SALIR");
            }
            catch (Exception ex)
            {
                DisplayAlert("ALERT", ex.Message, "cerrar");
            }
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}