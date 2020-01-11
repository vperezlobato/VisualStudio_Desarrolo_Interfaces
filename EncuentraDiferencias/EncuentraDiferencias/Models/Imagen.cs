using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuentraDiferencias.Models
{
    public class Imagen
    {
        private Uri _imagen;
        private List<Diferencia> _diferencias;

        public Imagen() { }

        public Imagen(List<Diferencia> diferencias,Uri imagen) {
            this._diferencias = diferencias;
            this._imagen = imagen;
        }

        public List<Diferencia> diferencias { 
            get { return this._diferencias; }
            set { _diferencias = value; }
        }

        public Uri imagen { 
            get { return this._imagen; }
            set { _imagen = value; }
        }
    }
}
