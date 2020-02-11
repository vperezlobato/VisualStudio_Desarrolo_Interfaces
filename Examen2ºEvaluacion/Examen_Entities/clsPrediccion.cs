using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Entities
{
    public class clsPrediccion
    {

        private int _idCiudad;
        private DateTime _fecha;
        private String _pronostico;
        private double _humedad;
        private double _temperaturaMinima;
        private double _temperaturaMaxima;

        public clsPrediccion() { }

        public clsPrediccion(int idCiudad, DateTime fecha, String pronostico, double humedad, double temperaturaMinima,double temperaturaMaxima) {
            this._idCiudad = idCiudad;
            this._fecha = fecha;
            this._pronostico = pronostico;
            this._humedad = humedad;
            this._temperaturaMaxima = temperaturaMaxima;
            this._temperaturaMinima = temperaturaMinima;
        }

        public int idCiudad {
            get {
                return _idCiudad;
            }

            set {
                _idCiudad = value;
            }
        }

        public DateTime fecha {
            get {
                return _fecha;
            }
            set {
                _fecha = value;
            }
        }

        public String pronostico {
            get {
                return _pronostico;
            }
            set {
                _pronostico = value;
            }
        }

        public double humedad {
            get {
                return _humedad;
            }

            set {
                _humedad = value;
            }
        }

        public double temperaturaMaxima {
            get {
                return _temperaturaMaxima;
            }

            set {
                _temperaturaMaxima = value;
            }
        }

        public double temperaturaMinima {
            get {
                return _temperaturaMinima;
            }

            set {
                _temperaturaMinima = value;
            }
        }
     }
}
