using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _02_HolaMundoWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clsPersona objPersona = new clsPersona();

            objPersona.nombre = txTexto.Text;

            if (String.IsNullOrEmpty(objPersona.nombre))
            {
                MessageBox.Show("Has dejado el nombre vacío");
            }
            else
                MessageBox.Show($"Hola {objPersona.nombre}");

        }

    }
}
