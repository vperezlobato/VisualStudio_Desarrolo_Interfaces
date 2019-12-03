using ExameN_DAL.Listados;
using ExameN_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameN_BL.Listados
{
    public class ListadoSuperheroesBL
    {

        /// <summary>
        /// Este metodo ofrece un listado de superheroes
        /// </summary>
        /// <returns>List<Superheroe> listadoSuperheroes</returns>
        public List<Superheroe> listadoSuperheroesBL() {
            List<Superheroe> listadoSuperheroes = new List<Superheroe>();

            ListadoSuperheroesDAL list = new ListadoSuperheroesDAL();

            listadoSuperheroes = list.listadoSuperheroesDAL();

            return listadoSuperheroes;
        }

    }
}
