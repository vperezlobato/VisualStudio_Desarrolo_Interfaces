using CRUD_Personas_Xamarin_Entidades;
using CRUD_Personas_Xamarin_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_Personas_Xamarin_UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarPage : ContentPage
    {
        public EditarPage (clsPersona persona)
        {
            InitializeComponent();
            BindingContext = new EditarVM(persona);
        }
    }
}