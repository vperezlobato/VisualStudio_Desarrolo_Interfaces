using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BuscaMinas.Models
{
    public class clsCasilla : INotifyPropertyChanged
    {

        private Boolean _estado;
        private Uri _imagen;
        private Boolean _yaPulsada;

        public Boolean estado {
            get { return _estado; }
            set {
                _estado = value;
            }
        }

        public Boolean yaPulsada {
            get { return _yaPulsada; }
            set { 
                _yaPulsada = value;
                NotifyPropertyChanged("imagen");
            }
        }

        public Uri imagen{
            get
            {
                cambiarImagenReverso();
                return _imagen;
            }
        }

        /// <summary>
        /// constructor por defecto
        /// </summary>
        public clsCasilla() {
            estado = false;
            yaPulsada = false;
            _imagen = new Uri("ms-appx://BuscaMinas/Assets/presionar.png",UriKind.RelativeOrAbsolute);
        }

        private void cambiarImagenReverso() {
            if (_estado == true && _yaPulsada) {
                _imagen = new Uri("ms-appx://BuscaMinas/Assets/bomba.png", UriKind.RelativeOrAbsolute);
            }else
                if(_estado == false && _yaPulsada) 
                _imagen = new Uri("ms-appx://BuscaMinas/Assets/salvado.png", UriKind.RelativeOrAbsolute);
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
