using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace EncuentraDiferencias.Models
{
    public class Diferencia
    {
        public int size { get; }
        public Ellipse ellipse { get; set; }
        public int posY { get; set; }
        public int posX{ get; set; }
        public bool encontrada { get; set; }

        public Diferencia()
        {
            ellipse = new Ellipse();
            posX = 0;
            posY = 0;
            size = 40;
            ellipse.Width = size;
            ellipse.Height = size;
            ellipse.Fill = new SolidColorBrush(Colors.Transparent);
            ellipse.StrokeThickness = 5;
            ellipse.Stroke = new SolidColorBrush(Colors.Red);
            encontrada = false;
        }

        public void tomarPosicion() {
            Canvas.SetTop(ellipse, posY);
            Canvas.SetLeft(ellipse, posX);
        }

    }
}
