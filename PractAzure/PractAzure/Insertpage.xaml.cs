using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;

namespace PractAzure
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insertpage : ContentPage
    {
        public Insertpage()
        {
            InitializeComponent();
            string[] semestres = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" };
            Picker_Semestre.ItemsSource = semestres;
            Picker_Semestre.SelectedIndex = 0;
            string[] carreras = { "Sistemas", "Administracion", "Civil", "Mecatronica", "Biologia", "Gastronomia" };
            Picker_Carrera.ItemsSource = carreras;
            Picker_Carrera.SelectedIndex = 0;
        }

        private async void Insertar_Clicked(object sender, EventArgs e)
        {
            var datos = new _12090256
            {
                Nombre = Entry_Nombre.Text,
                Apellidos = Entry_Apellidos.Text,
                Direccion = Entry_Direccion.Text,
                Telefono = Entry_Telefono.Text,
                Carrera = Convert.ToString(Picker_Carrera.SelectedItem),
                Semestre = Convert.ToString(Picker_Semestre.SelectedItem),
                Correo = Entry_Correo.Text,
                Github = Entry_Github.Text

            };
            await Datapage.Tabla.InsertAsync(datos);
            await Navigation.PushAsync(new Datapage());
        }
    }
}