using ExameN_DAL.Manejadoras;
using ExameN_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameN_BL.Manejadoras
{
    public class gestionadoraMisionesBL
    {
        /// <summary>
        /// Este metodo edita la mision
        /// </summary>
        /// <returns>int filasAfectadas</returns>
        public int editarMisionBL(Mision objMision)
        {
            int filasAfectadas = 0;

            gestionadoraMisiones gestionadora = new gestionadoraMisiones();

            filasAfectadas = gestionadora.editarMisionDAL(objMision);

            return filasAfectadas;
        }


    }
}
