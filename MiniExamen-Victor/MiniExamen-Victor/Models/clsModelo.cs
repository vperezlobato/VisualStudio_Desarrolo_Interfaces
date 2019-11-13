using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniExamen_Victor.Models
{
    public class clsModelo
    {
        public String nombre { get; set; }
        public int idFabricante { get; set; }

        public clsModelo( String nombre, int idFabricante)
        {
            this.nombre = nombre;
            this.idFabricante = idFabricante;
        }
    }
}
