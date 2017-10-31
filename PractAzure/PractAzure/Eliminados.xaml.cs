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
    public partial class Eliminados : ContentPage
    {
        public ObservableCollection<_12090256> Items { get; set; }
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_12090256> Tabla;
        public Eliminados()
        {
            InitializeComponent();
            InitializeComponent();
            Cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = Cliente.GetTable<_12090256>();
            LeerTabla();
        }

        private async void LeerTabla()
        {
            IEnumerable<_12090256> elementos = await Tabla.IncludeDeleted().ToEnumerableAsync();
            Items = new ObservableCollection<_12090256>(elementos);
            BindingContext = this;

        }
    }
}