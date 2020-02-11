using Examen_DAL.Listados;
using Examen_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_BL.Listados
{
    public class ListadoCiudadesBL
    {
        /// <summary>
        /// Devuelve un listado de ciudades
        /// </summary>
        /// <returns>listado de ciudades</returns>
        public async Task<List<clsCiudad>> listadoCiudades() {

            ListadoCiudadesDAL listadoCiudadesDAL = new ListadoCiudadesDAL();

            List<clsCiudad> listado = await listadoCiudadesDAL.listadoCiudades();

            return listado;

        }
    }
}
