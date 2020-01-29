using CRUD_Personas_Xamarin_DAL;
using CRUD_Personas_Xamarin_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_Xamarin_BL
{
    public class clsListadoPersonasBL
    {
        public async Task<List<clsPersona>> listadoPersonas_BL()
        {

            clsListadoPersonasDAL listadoPersonasDAL = new clsListadoPersonasDAL();

            List<clsPersona> listado = await listadoPersonasDAL.listadoPersonas();

            return listado;
        }

        /* public Boolean existePersona_BL(int id)
         {

             Boolean existe = false;

             clsListadoPersonasDAL listadoPersonasDAL = new clsListadoPersonasDAL();

             existe = listadoPersonasDAL.existePersona_DAL(id);

             return existe;
         }*/
    }

}

