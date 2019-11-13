using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaMinas.Models
{
    class listadoCasillas
    {

        public static List<clsCasilla> generarTablero()
        {

            List<clsCasilla> lista = new List<clsCasilla>();

            //añadimos 12 casillas sin bomba
            for (int i = 1; i <= 12; i++)
            {
                lista.Add(new clsCasilla());

            }

            //añadimos 4 casillas con bomba
            for (int i = 1; i <= 4; i++)
           {
                lista.Add(new clsCasilla());
                lista[i].estado = true;
            }

            //Desordenamos usando el algoritmo de Fisher-Yates, y devolvemos la lista barajada
            Random random = new Random();
            clsCasilla auxiliar;

            for (int k = lista.Count - 1; k >= 1; k--)
            {
                int r = random.Next(0, k);

                auxiliar = lista[r];
                lista[r] = lista[k];
                lista[k] = auxiliar;
            }

            return lista;
        }
    }
}
