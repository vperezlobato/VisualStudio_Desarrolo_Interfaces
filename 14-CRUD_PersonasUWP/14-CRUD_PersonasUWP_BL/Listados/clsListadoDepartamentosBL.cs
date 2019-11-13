using _14_CRUD_PersonasUWP_DAL;
using _14_CRUD_PersonasUWP_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_CRUD_PersonasUWP_BL
{
    public class clsListadoDepartamentosBL
    {
        public List<clsDepartamento> listadoDepartamentos() {
            List<clsDepartamento> listado = new List<clsDepartamento>();

            clsListadoDepartamentosDAL listadoDepartamentosDal = new clsListadoDepartamentosDAL();

            listado = listadoDepartamentosDal.listadoDepartamentos();

            return listado;
        }
    }
}
