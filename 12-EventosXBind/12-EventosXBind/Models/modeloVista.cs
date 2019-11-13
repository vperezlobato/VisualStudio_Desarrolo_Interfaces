using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace _12_EventosXBind.Models
{
    public class modeloVista : INotifyPropertyChanged
    {

        private ObservableCollection<clsPersona> _lista;
        private clsPersona _personaSeleccionada;

        public event PropertyChangedEventHandler PropertyChanged;

        //constructor por defecto
        public modeloVista() {
            //rellenamos el constructor con el listado de personas
            listadoPersonas listPersonas = new listadoPersonas();
            _lista = listPersonas.listado();
        }

        public clsPersona personaSeleccionada {
            get { return _personaSeleccionada; }
            set {
                if (_personaSeleccionada != value)
                {
                    _personaSeleccionada = value;
                    NotifyPropertyChanged("personaSeleccionada");
                }
            }
        }

        public ObservableCollection<clsPersona> lista {
            get { return _lista; }
        }

        public void Borrar_Click(object sender, RoutedEventArgs e) {
            this._lista.Remove(this._personaSeleccionada);
            this._personaSeleccionada = new clsPersona();
            NotifyPropertyChanged("personaSeleccionada");
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
