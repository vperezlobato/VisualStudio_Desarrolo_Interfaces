using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniExamen_Victor.Models
{
    public class listadoFabricantes
    {

        public List<clsFabricante> listFabricantes() {
            List<clsFabricante> lista = new List<clsFabricante>();
            lista.Add(new clsFabricante("Ford", 1));
            lista.Add(new clsFabricante("Renault", 2));
            lista.Add(new clsFabricante("Seat", 3));

            return lista;
        }
    }
}
