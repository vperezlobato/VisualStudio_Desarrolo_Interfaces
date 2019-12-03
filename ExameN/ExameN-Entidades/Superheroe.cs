using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameN_Entidades
{
    public class Superheroe
    {
        private int _idSuperheroe;
        private String _nombreSuperheroe;
        private Uri _imagen;
        public Superheroe() { }

        public Superheroe(int idSuperheroe,String nombreSuperheroe) {
            this._idSuperheroe = idSuperheroe;
            this._nombreSuperheroe = nombreSuperheroe;
        }

        public int idSuperheroe {
            get {
                return _idSuperheroe;
            }
            set {
                _idSuperheroe = value;
            }
        }

        public String nombreSuperheroe
        {
            get
            {
                return _nombreSuperheroe;
            }
            set
            {
                _nombreSuperheroe = value;
            }
        }

        public Uri imagen {
            get {
                return _imagen;
            }
        }

        public void asignarImagen() {

            _imagen = new Uri("ms-appx://Examen-UI/Assets/"+ _idSuperheroe +".jpg", UriKind.RelativeOrAbsolute);                    
            
        }
    }
}
