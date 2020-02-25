using CRUD_Personas_Xamarin_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CRUD_Personas_Xamarin_UI
{
    public partial class MainPage : ContentPage
    {
        public MainPageVM viewModel { get; }
        public MainPage()
        {
            InitializeComponent();
            viewModel = (MainPageVM)BindingContext;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.cargarDatos();
            viewModel.personaSeleccionada = null;
        }
    }
}
