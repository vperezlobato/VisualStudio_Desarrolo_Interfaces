using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongSignalRUniversal.Entidades
{
    public class objetoJuego
    {
        public double izquierda { get; set; }
        public string id { get; set; }

        public string ultimoActualizado { get; set; }
        public bool seHaMovido { get; set; }

        public int velocidad { get; set; }
        public double posicionY { get; set; }

        public Uri imagen { get; set; }

        public objetoJuego(double izquierda, string id, string ultimoActualizado, bool seHaMovido, int velocidad, double posicionY,Uri imagen) {
            this.izquierda = izquierda;
            this.id = id;
            this.ultimoActualizado = ultimoActualizado;
            this.seHaMovido = seHaMovido;
            this.imagen = imagen;
            this.velocidad = velocidad;
            this.posicionY = posicionY;
        }
    }
}
