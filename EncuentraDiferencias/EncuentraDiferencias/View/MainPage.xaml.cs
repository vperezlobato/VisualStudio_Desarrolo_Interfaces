using EncuentraDiferencias.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace EncuentraDiferencias
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageVM MainPageVm { get; }
        public MainPage()
        {
            this.MainPageVm = new MainPageVM();
            this.InitializeComponent();
            for (int i = 0; i < MainPageVm.diferencias.Count; i++) {
                MainPageVm.diferencias.ElementAt(i).ellipse.Tapped += new TappedEventHandler(MainPageVm.evento_Click);
                canvas.Children.Add(MainPageVm.diferencias.ElementAt(i).ellipse);
            }
        }
    }
}
