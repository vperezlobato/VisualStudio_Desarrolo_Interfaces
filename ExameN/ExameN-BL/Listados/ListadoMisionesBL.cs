using ExameN_DAL.Listados;
using ExameN_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameN_BL.Listados
{
    public class ListadoMisionesBL
    {

        public List<Mision> listadoMisionesNoReservadasBL() {
            List<Mision> listadoMisiones = new List<Mision>();

            ListadoMisionesDAL list = new ListadoMisionesDAL();

            listadoMisiones = list.listadoMisionesNoReservadas();

            return listadoMisiones;
        }
    }
}
