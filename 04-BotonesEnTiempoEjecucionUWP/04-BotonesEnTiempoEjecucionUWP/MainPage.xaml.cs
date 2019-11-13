using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Media.SpeechSynthesis;
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

namespace _04_BotonesEnTiempoEjecucionUWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();

            Button newButton = new Button();

            newButton.Width = 200;
            newButton.Height = 70;
            newButton.Content = "Boton 3";
            newButton.HorizontalAlignment = HorizontalAlignment.Center;
            newButton.VerticalAlignment = VerticalAlignment.Center;
            newButton.VerticalContentAlignment = VerticalAlignment.Center;
            newButton.HorizontalContentAlignment = HorizontalAlignment.Center;
            newButton.Background = new SolidColorBrush(Windows.UI.Colors.Blue);
            newButton.FontFamily = new FontFamily("Verdana");
            newButton.FontSize = 16;
            newButton.FontWeight = Windows.UI.Text.FontWeights.Bold;
            newButton.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Yellow);
            newButton.Click += new RoutedEventHandler(Boton3_Click);
            StackPanel1.Children.Add(newButton);            
        }

        private async void Boton1_Click(object sender, RoutedEventArgs e)
        {
            MediaElement mediaElement = new MediaElement();

            // The object for controlling the speech synthesis engine (voice).
            var synth = new SpeechSynthesizer();

            // Generate the audio stream from plain text.
            SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("Hola mundo");

            // Send the stream to the media object.
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }

        private void Boton2_Click(object sender, RoutedEventArgs e)
        {
            Image imagen = new Image();
            BitmapImage url = new BitmapImage(new Uri("ms-appx:///Assets/download.png", UriKind.Absolute));

            imagen.Source = url;
            imagen.Width = 200;
            imagen.Height = 70;
            StackPanel1.Children.Add(imagen);
        }

        private void Boton3_Click(object sender, RoutedEventArgs e) {

            TextBlock textBlock = new TextBlock();
            {
                textBlock.Text = "Hola Mundo";
                textBlock.Width = 200;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            }           
            StackPanel1.Children.Add(textBlock);
        }
    }
}
