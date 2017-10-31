using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace PractAzure
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Selectpage : ContentPage
    {
        public Selectpage(Object SelectedItem)
        {
            var dato = SelectedItem as _12090256;
            BindingContext = dato;
            InitializeComponent();
            string[] semestres = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" };
            Picker_Semestre.ItemsSource = semestres;
            Picker_Semestre.SelectedIndex = 0;
            string[] carreras = { "Sistemas", "Administracion", "Civil", "Mecatronica", "Biologia", "Gastronomia" };
            Picker_Carrera.ItemsSource = carreras;
            Picker_Carrera.SelectedIndex = 0;
        }

        private async void Actualizar_Clicked(object sender, EventArgs e)
        {
            var datos = new _12090256
            {
                Matricula = Entry_Matricula.Text,
                Nombre = Entry_Nombre.Text,
                Apellidos = Entry_Apellidos.Text,
                Direccion = Entry_Direccion.Text,
                Telefono = Entry_Telefono.Text,
                Carrera = Convert.ToString(Picker_Carrera.SelectedItem),
                Semestre = Convert.ToString(Picker_Semestre.SelectedItem),
                Correo = Entry_Correo.Text,
                Github = Entry_Github.Text

            };
            await Datapage.Tabla.UpdateAsync(datos);
            await Navigation.PushAsync(new Datapage());
        }

        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            var datos = new _12090256
            {
                Matricula = Entry_Matricula.Text,
            };
            await Datapage.Tabla.DeleteAsync(datos);
            await Navigation.PushAsync(new Datapage());
        }
    }
}