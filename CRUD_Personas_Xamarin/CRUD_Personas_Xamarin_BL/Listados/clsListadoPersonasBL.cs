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
        /// <summary>
        /// Este metodo nos permite obtener un listado de las personas almacenadas en la BBDD.
        /// </summary>
        /// <returns>Devuelve un list de clsPersona</returns>
        public async Task<List<clsPersona>> listadoPersonas_BL()
        {

            clsListadoPersonasDAL listadoPersonasDAL = new clsListadoPersonasDAL();

            List<clsPersona> listado = await listadoPersonasDAL.listadoPersonas();

            return listado;
        }

        /// <summary>
        /// Metodo para comprobar que existe la persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool existe</returns>
        public async Task<Boolean> existePersonaBL(int id)
        {

            clsListadoPersonasDAL listadoPersonasDAL = new clsListadoPersonasDAL();
            bool existe = false;

            existe = await listadoPersonasDAL.existePersona_DAL(id);

            return existe;
        }

    }

}

