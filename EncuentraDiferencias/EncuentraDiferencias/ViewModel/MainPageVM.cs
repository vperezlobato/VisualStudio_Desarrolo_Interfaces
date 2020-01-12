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
        private Uri _imagen1;
        private Uri _imagen2;
        private int _numAciertos;
        private List<Diferencia> _diferencias;
        public MainPageVM()
        {            
            rellenarPag();
            
        }

        public Uri imagen1
        {
            get { return _imagen1; }
            set
            {
                _imagen1 = value;
            }
        }
        public Uri imagen2
        {
            get { return _imagen2; }
            set
            {
                _imagen2 = value;
            }
        }

        public int numAciertos
        {
            get { return _numAciertos; }
            set
            {
                if (_numAciertos != value)
                {
                    _numAciertos = value;
                    NotifyPropertyChanged("numAciertos");
                }
            }
        }

        public List<Diferencia> diferencias
        {
            get { return _diferencias; }
            set
            {
                _diferencias = value;
                NotifyPropertyChanged("diferencias");
            }
        }

        public void rellenarPag()
        {
            _numAciertos = 0;
            _diferencias = new List<Diferencia>();
            Diferencia diferencia1 = new Diferencia();
            Diferencia diferencia2 = new Diferencia();
            Diferencia diferencia3 = new Diferencia();
            Diferencia diferencia4 = new Diferencia();

            diferencia1.ellipse.Name = "elipse1";
            diferencia2.ellipse.Name = "elipse2";
            diferencia3.ellipse.Name = "elipse3";
            diferencia4.ellipse.Name = "elipse4";
            diferencia1.posX = 210;
            diferencia2.posX = 470;
            diferencia1.posY = 420;
            diferencia2.posY = 465;
            diferencia3.posX = 900;
            diferencia4.posX = 1160;
            diferencia3.posY = 420;
            diferencia4.posY = 465;
            diferencia1.tomarPosicion();
            diferencia2.tomarPosicion();
            diferencia3.tomarPosicion();
            diferencia4.tomarPosicion();
            _diferencias.Add(diferencia1);
            _diferencias.Add(diferencia2);
            _diferencias.Add(diferencia3);
            _diferencias.Add(diferencia4);

            _imagen1 = new Uri("ms-appx://EncuentraDiferencias/Assets/imagen1.PNG", UriKind.RelativeOrAbsolute);
            _imagen2 = new Uri("ms-appx://EncuentraDiferencias/Assets/imagen2.PNG", UriKind.RelativeOrAbsolute);

        }

        public void evento_Click(object sender, TappedRoutedEventArgs e)
        {
            Ellipse ellipse = (Ellipse)sender;
            string nombre = ellipse.Name;
            for (int i = 0; i < diferencias.Count; i++)
            {
                switch (nombre)
                {
                    case "elipse1": case "elipse3":
                        if (diferencias.ElementAt(0).encontrada == false && diferencias.ElementAt(2).encontrada == false)
                        {
                            diferencias.ElementAt(0).encontrada = true;
                            diferencias.ElementAt(2).encontrada = true;
                            diferencias.ElementAt(2).ellipse.Stroke = new SolidColorBrush(Colors.Red);
                            _numAciertos++;
                            NotifyPropertyChanged("numAciertos");
                        }
                    break;
                    case "elipse2":
                    case "elipse4":
                        if (diferencias.ElementAt(1).encontrada == false && diferencias.ElementAt(3).encontrada == false)
                        {
                            diferencias.ElementAt(1).encontrada = true;
                            diferencias.ElementAt(3).encontrada = true;
                            diferencias.ElementAt(3).ellipse.Stroke = new SolidColorBrush(Colors.Red);
                            _numAciertos++;
                            NotifyPropertyChanged("numAciertos");
                        }
                        break;
                }
            }
            
        }
    }
}
