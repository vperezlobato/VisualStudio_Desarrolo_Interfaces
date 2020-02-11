using Examen_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenUI
{
    public class clsPrediccionConNombreCiudadYImagen : clsPrediccion
    {
        private Uri _imagen;

        public clsPrediccionConNombreCiudadYImagen() { }

        public clsPrediccionConNombreCiudadYImagen(int idCiudad, DateTime fecha, String pronostico, double humedad, double temperaturaMinima, double temperaturaMaxima,Uri imagen) {
            this.idCiudad = idCiudad;
            this.fecha = fecha;
            this.pronostico = pronostico;
            this.humedad = humedad;
            this.temperaturaMaxima = temperaturaMaxima;
            this.temperaturaMinima = temperaturaMinima;
            this._imagen = imagen;
        }

        public Uri imagen {
            get {
                return new Uri("ms-appx://Examen-UI/Assets/"+pronostico+".png", UriKind.RelativeOrAbsolute);
            }
        }

    }
}
