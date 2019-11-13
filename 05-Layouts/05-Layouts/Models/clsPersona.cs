using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Layouts.Models
{
   public class clsPersona
{
        //atributos privados
        private String _nombre;
        private String _apellido1;
        private String _apellido2;

        //constructor por defecto
        public clsPersona() {
        }

        //constructor por parametros
        public clsPersona(String nombre, String apellido1, String apellido2) {
            this._nombre = nombre;
            this._apellido1 = apellido1;
            this._apellido2 = apellido2;
        }

        //propiedades públicas
        public String nombre {
            get {
                return _nombre;

            }
            set {
                _nombre = value;
            }
        }

        public String apellido1 {
            get {
                return _apellido1;
            }
            set {
                _apellido1 = value;
            }
        }

        public String apellido2
        {
            get
            {
                return _apellido2;
            }
            set
            {
                _apellido2 = value;
            }
        }

        public DateTime fechaNacimiento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
   }
}
