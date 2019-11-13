using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _08_Binding_Parte2.Models
{
   public class clsPersona : INotifyPropertyChanged
    {
        //atributos privados
        private String _nombre;
        private String _apellidos;

        //constructor por defecto
        public clsPersona() {
            _nombre = "pepito";
            apellidos = "macuto maleta";

        }

        //constructor por parametros
        public clsPersona(String nombre, String apellidos) {
            this._nombre = nombre;
            this._apellidos = apellidos;
        }

        //propiedades públicas
        public String nombre {
            get {
                return _nombre;

            }
            set {
                _nombre = value;
                NotifyPropertyChanged();
            }
        }

        public String apellidos {
            get {
                return _apellidos;
            }
            set {
                _apellidos = value;
            }
        }


        public DateTime fechaNacimiento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
