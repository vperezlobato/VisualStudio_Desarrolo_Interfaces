using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Entities
{
    public class clsCiudad
    {

        public int idCiudad { get; set; }
        public String nombreCiudad { get; set; }

        //constructor por defecto
        public clsCiudad() {}

        //constructor por parametros
        public clsCiudad(int idCiudad , String nombreCiudad) {
            this.idCiudad = idCiudad;
            this.nombreCiudad = nombreCiudad;
        }

    }
}
