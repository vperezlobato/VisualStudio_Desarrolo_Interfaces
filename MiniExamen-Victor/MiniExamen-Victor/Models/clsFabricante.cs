using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniExamen_Victor.Models
{
    public class clsFabricante
    {
        public String marca { get; set; }
        public int idFabricante { get; set; }

        public clsFabricante(String marca, int idFabricante) {
            this.marca = marca;
            this.idFabricante = idFabricante;
        }
    }
}
