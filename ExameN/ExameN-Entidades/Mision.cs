using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameN_Entidades
{
    public class Mision
    {
        public int idMision { get; set; }
        public String tituloMision { get; set; }
        public String descripcionMision { get; set; }
        public bool reservada { get; set; }
        public int idSuperheroe { get; set; }
        public String observaciones { get; set; }

        public Mision() { }

        public Mision(int idMision, String tituloMision, String descripcionMision, bool reservada, int idSuperheroe, String observaciones) {
            this.idMision = idMision;
            this.tituloMision = tituloMision;
            this.descripcionMision = descripcionMision;
            this.reservada = reservada;
            this.idSuperheroe = idSuperheroe;
            this.observaciones = observaciones;
        }
    }
}
