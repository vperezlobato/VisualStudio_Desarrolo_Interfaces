using Examen_DAL.Listados;
using Examen_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_BL.Listados
{
    public class ListadoPrediccionesBL
    {
        /// <summary>
        /// Devuelve un listado de predicciones segun el id de la ciudad
        /// </summary>
        /// <param name="idCiudad"></param>
        /// <returns>listado de predicciones</returns>
        public async Task<List<clsPrediccion>> listadoPredicciones(int idCiudad)
        {

            ListadoPrediccionesDAL listadoPrediccionesDAL = new ListadoPrediccionesDAL();

            List<clsPrediccion> listado = await listadoPrediccionesDAL.listadoPredicciones(idCiudad);

            return listado;

        }
    }
}
