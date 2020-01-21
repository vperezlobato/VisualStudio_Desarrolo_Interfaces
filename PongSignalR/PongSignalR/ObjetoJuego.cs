using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PongSignalR
{
    public class objetoJuego
    {
        public double izquierda { get; set; }

        public double posicionY { get; set; }

        public string id { get; set; }

        public bool seHaMovido { get; set; }

        public string ultimoActualizado { get; set; }

    }
}