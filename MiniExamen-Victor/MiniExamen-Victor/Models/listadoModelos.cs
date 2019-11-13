using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniExamen_Victor.Models
{
    public class listadoModelos
    {
        public static List<clsModelo> listModelos() {
            List<clsModelo> listado = new List<clsModelo>();
            listado.Add(new clsModelo("Fiesta", 1));
            listado.Add(new clsModelo("Focus", 1));
            listado.Add(new clsModelo("Kuga", 1));
            listado.Add(new clsModelo("Clio", 2));
            listado.Add(new clsModelo("Megane", 2));
            listado.Add(new clsModelo("Scenic", 2));
            listado.Add(new clsModelo("Ibiza", 3));
            listado.Add(new clsModelo("Leon", 3));
            listado.Add(new clsModelo("Tarraco", 3));
            return listado;
        }

        public static List<clsModelo> encontrar(int IDFabricante, List<clsModelo> listadoModelos)
        {

            List<clsModelo> listModelos = listadoModelos.FindAll(a => IDFabricante == a.idFabricante);

            return listModelos;
         }

    }
}
