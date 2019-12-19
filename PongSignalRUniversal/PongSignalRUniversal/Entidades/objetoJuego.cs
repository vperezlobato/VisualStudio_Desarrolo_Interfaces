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
        public double top { get; set; }
        public string id { get; set; }

        public string ultimoActualizado { get; set; }
        public bool seHaMovido { get; set; }

        public objetoJuego(double izquierda, double top, string id, string ultimoActualizado, bool seHaMovido) {
            this.izquierda = izquierda;
            this.top = top;
            this.id = id;
            this.ultimoActualizado = ultimoActualizado;
            this.seHaMovido = seHaMovido;

        }
    }
}
