using _14_CRUD_PersonasUWP_DAL;
using _14_CRUD_PersonasUWP_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_CRUD_PersonasUWP_BL
{
    public class clsListadoPersonasBL
    {
        public List<clsPersona> listadoPersonas() {

            List<clsPersona> listado = new List<clsPersona>();

            clsListadoPersonasDAL listadoPersonasDAL = new clsListadoPersonasDAL();

            listado = listadoPersonasDAL.listadoPersonas();

            return listado;
        }

    }
}
