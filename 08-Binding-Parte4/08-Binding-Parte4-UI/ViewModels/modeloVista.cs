using _08_Binding_Parte4_Entidades;
using _08_Binding_Parte4_UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _08_Binding_Parte4_UI.ViewModels
{
    public class modeloVista : INotifyPropertyChanged
    {

        private List<clsPersona> _lista;
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
                _personaSeleccionada = value;
                NotifyPropertyChanged();
            }
        }

        public List<clsPersona> lista {
            get { return _lista; }
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
