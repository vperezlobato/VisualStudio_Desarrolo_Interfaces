
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

            DateTime fechaIntroducida = DateTime.Parse(txtFecha.Text);
            DateTime fechaDiaAnterior = Convert.ToDateTime(DateTime.Now.Day - 1);
            DateTime fechaDiaPosterior = Convert.ToDateTime(DateTime.Now.Day + 1);

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
            if (String.IsNullOrEmpty(txtFecha.Text))
            {
                txtAlertaFecha.Text = "Has dejado la fecha en blanco";
                validado = false;
                if(fechaIntroducida < fechaDiaAnterior && fechaIntroducida < fechaDiaPosterior)
                {
                    txtAlertaFecha.Text = "Introduce bien la fecha de nacimiento";
                }
            }else{
                txtAlertaFecha.Text = "";
                validado = true;
            }

            if (validado) {
                objPersona.nombre = txtNombre.Text;
                objPersona.apellido1 = txtApellido.Text;
                objPersona.fechaNacimiento = DateTime.Parse(txtFecha.Text);
            }
        }
    }
}
