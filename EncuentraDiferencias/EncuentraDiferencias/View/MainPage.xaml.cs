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
    public sealed partial class MainPage : Page
    {
        public MainPageVM MainPageVm { get; }
        public MainPage()
        {
            
            this.InitializeComponent();
            this.MainPageVm = (MainPageVM)this.DataContext;

            for (int i = 0; i < MainPageVm.diferencias.Count; i++) {
                canvas.Children.Add(MainPageVm.diferencias.ElementAt(i).ellipse);
            }
        }
    }
}
