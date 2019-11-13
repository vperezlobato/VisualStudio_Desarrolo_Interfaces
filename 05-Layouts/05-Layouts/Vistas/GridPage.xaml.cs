using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using _05_Layouts.Models;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _05_Layouts
{
/// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class GridPage : Page
 {
        public GridPage()
        {
            this.InitializeComponent();
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 20, Height = 20 });
        }

        private void BtnEnviar_Click(object sender, RoutedEventArgs e)
        {
            clsPersona objPersona = new clsPersona();
            Boolean validado = true;

            if (String.IsNullOrEmpty(txtNombre.Text)) {
                txtAlertaNombre.Text = "Has dejado el nombre en blanco";
                validado = false;
            }
            else {
                txtAlertaNombre.Text = "";
                validado = true;
            }

            if (String.IsNullOrEmpty(txtApellido.Text)) {
                txtAlertaApellido.Text = "Has dejado el apellido en blanco";
                validado = false;

            }else{
                txtAlertaApellido.Text = "";
                validado = true;
            }

            DateTime temp;
            DateTime fechaHoy = DateTime.Now;
            if (DateTime.TryParse(txtFecha.Text, out temp))
            {
                txtAlertaFecha.Text = "La fecha es erronea";
                validado = false;

            }
            else
            {
                if (fechaHoy.CompareTo(temp) < 0)
                {
                    txtAlertaFecha.Text = "fecha posterior a la actual";
                    validado = false;
                }else
                    txtAlertaFecha.Text = "";
            }

            if (validado) {
                objPersona.nombre = txtNombre.Text;
                objPersona.apellido1 = txtApellido.Text;
                objPersona.fechaNacimiento = DateTime.Parse(txtFecha.Text);
            }
        }
    }
}
