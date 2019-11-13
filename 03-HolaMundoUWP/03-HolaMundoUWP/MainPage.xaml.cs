using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _03_HolaMundoUWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SpeechSynthesizer speechSynthesizer;
        public MainPage()
        {
            this.InitializeComponent();
            speechSynthesizer = new SpeechSynthesizer();
        }
        /// <summary>
        /// funcion boton para saludar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Boolean validado = true;
            String mensajeError = "";
            String mensajeFinal = "";

            clsPersona oPersona = new clsPersona();
            //recogemos el nombre del textBox
            oPersona.nombre = txtNombre.Text;
            oPersona.apellido1 = txtApellido1.Text;
            oPersona.apellido2 = txtApellido2.Text;
            oPersona.fechaNacimiento = dateFecha.Date.DateTime;
       
            //validacion del nombre
            if (String.IsNullOrEmpty(oPersona.nombre))
            {
                validado = false;
                mensajeError = "Has dejado el nombre en blanco, ";

            }
            //validacion del primer apellido
            if (String.IsNullOrEmpty(oPersona.apellido1))
            {
                validado = false;
                mensajeError += "has dejado el primer apellido en blanco, ";
            }

            //validacion del segundo apellido
            if (String.IsNullOrEmpty(oPersona.apellido2))
            {
                validado = false;
                mensajeError += "has dejado el segundo apellido en blanco, ";
            }
            //TODO validar fecha
            if (String.IsNullOrEmpty(oPersona.fechaNacimiento.ToString())) {
                validado = false;
                mensajeError += "has dejado la fecha en blanco";
            }

            //El mensaje final si no esta validado sera el mensaje de error
            if (!validado)
            {
                mensajeFinal = mensajeError;
            }
            //El mensaje final si esta validado sera el nombre,apellidos y fecha de nacimiento
            else
            {
                mensajeFinal = $"Hola {oPersona.nombre} {oPersona.apellido1} {oPersona.apellido2} " +
                        $"con fecha de nacimiento {oPersona.fechaNacimiento.Date}";
            }

            var error = await speechSynthesizer.SynthesizeTextToStreamAsync(mensajeFinal);
            media.SetSource(error, error.ContentType);
            media.Play();
        }
        
    }
}

