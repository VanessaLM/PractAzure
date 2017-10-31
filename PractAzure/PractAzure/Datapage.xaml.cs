using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.ObjectModel;

namespace PractAzure
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Datapage : ContentPage
    {
        public ObservableCollection<_12090256> Items { get; set; }
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_12090256> Tabla;
        public Datapage()
        {
            InitializeComponent();
            InitializeComponent();
            Cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = Cliente.GetTable<_12090256>();
            LeerTabla();
        }

        private async void LeerTabla()
        {
            IEnumerable<_12090256> elementos = await Tabla.ToEnumerableAsync();
            Items = new ObservableCollection<_12090256>(elementos);
            BindingContext = this;

        }

        private void INSERTAR_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertpage());
        }

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushAsync(new Selectpage(e.SelectedItem as _12090256));
        }

        private void Mostrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Eliminados());

        }
    }
}