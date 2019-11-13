using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _08_Binding_Parte3.Models
{
    class modeloVista : INotifyPropertyChanged
    {

        public List<clsPersona> _lista;
        public clsPersona _persona;

        public event PropertyChangedEventHandler PropertyChanged;

        public modeloVista() {
            listadoPersonas listPersonas = new listadoPersonas();
            _lista = listPersonas.listado();
        }

        public clsPersona persona {
            get { return _persona; }
            set {
                _persona = value;
                NotifyPropertyChanged();
            }
        }

        public List<clsPersona> lista {
            get { return _lista; }
            set { _lista = value; }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
