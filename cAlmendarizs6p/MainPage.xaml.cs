using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace cAlmendarizs6p
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.100.159:81/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<cAlmendarizs6p.NewFolder2.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<cAlmendarizs6p.NewFolder2.Datos> posts = JsonConvert.DeserializeObject<List<cAlmendarizs6p.NewFolder2.Datos>>(content);
            _post = new ObservableCollection<cAlmendarizs6p.NewFolder2.Datos>(posts);

            MyListView.ItemsSource = _post;
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (NewFolder2.Datos)e.SelectedItem;
            var cod = obj.codigo.ToString();            
            var nom = obj.nombre.ToString();
            var ape = obj.apellido.ToString();
            var eda = obj.edad.ToString();
            int codigo = Convert.ToInt32(cod);
            string nombre = Convert.ToString(nom);
            string apellido = Convert.ToString(ape);
            int edad = Convert.ToInt32(eda);
            try
            {
                Navigation.PushAsync(new Editar(codigo, nombre, apellido, edad));
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
