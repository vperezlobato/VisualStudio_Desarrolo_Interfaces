using EncuentraDiferencias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace EncuentraDiferencias.ViewModel
{
    public class MainPageVM : clsVMBase
    {
        private Imagen _imagen1;
        private Imagen _imagen2;
        private int _numAciertos;

        public MainPageVM()
        {
            rellenarPag();
            _numAciertos = 0;
        }

        public Imagen imagen1
        {
            get { return _imagen1; }
            set
            {
                _imagen1 = value;
                NotifyPropertyChanged("imagenSeleccionada1");
            }
        }
        public Imagen imagen2
        {
            get { return _imagen2; }
            set
            {
                _imagen2 = value;
                NotifyPropertyChanged("imagenSeleccionada2");
            }
        }

        public int numAciertos {
            get { return _numAciertos; }
            set { 
                _numAciertos = value;
                NotifyPropertyChanged("numAciertos");
            }
        }

        public void rellenarPag()
        {
            List<Diferencia> diferencias = new List<Diferencia>();
            Diferencia diferencia1 = new Diferencia();
            Diferencia diferencia2 = new Diferencia();
            _imagen1 = new Imagen();
            _imagen2 = new Imagen();

            diferencia1.posX = 210;
            diferencia2.posX = 470;
            diferencia1.posY = 420;
            diferencia2.posY = 465;
            diferencia1.tomarPosicion();
            diferencia2.tomarPosicion();
            diferencias.Add(diferencia1);
            diferencias.Add(diferencia2);

            _imagen1.imagen = new Uri("ms-appx://EncuentraDiferencias/Assets/imagen1.PNG", UriKind.RelativeOrAbsolute);
            _imagen2.imagen = new Uri("ms-appx://EncuentraDiferencias/Assets/imagen2.PNG", UriKind.RelativeOrAbsolute);
            _imagen1.diferencias = diferencias;
            _imagen2.diferencias = diferencias;

        }

        public void evento_Click(object sender, TappedRoutedEventArgs e)
        {
            Ellipse ellipse = (Ellipse)sender;
            for (int i = 0; i < imagen1.diferencias.Count; i++)
            {                
                if ((imagen1.diferencias.ElementAt(i).posX == Canvas.GetLeft(ellipse) && imagen1.diferencias.ElementAt(i).posY == Canvas.GetTop(ellipse))
                    && (imagen1.diferencias.ElementAt(i).encontrada == false && imagen2.diferencias.ElementAt(i).encontrada == false)) {
                    imagen1.diferencias.ElementAt(i).encontrada = true;
                    imagen2.diferencias.ElementAt(i).encontrada = true;
                    ellipse.Stroke = new SolidColorBrush(Colors.Transparent);
                    _numAciertos++;
                }
            }
            NotifyPropertyChanged("imagenSeleccionada1");
            NotifyPropertyChanged("imagenSeleccionada2");           
            NotifyPropertyChanged("numAciertos");
        }
    }
}
