using CRUD_Personas_Xamarin_DAL;
using CRUD_Personas_Xamarin_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_Xamarin_BL
{
    public class clsListadoDepartamentosBL
    {

        public async Task<List<clsDepartamento>> listadoDepartamentosBL()
        {

            clsListadoDepartamentosDAL listadoDepartamentosDAL = new clsListadoDepartamentosDAL();

            List<clsDepartamento> listado = await listadoDepartamentosDAL.listadoDepartamentos();

            return listado;
        }

        public async Task<clsDepartamento> departamentoPorIDBL(int id)
        {

            clsListadoDepartamentosDAL listadoDepartamentosDAL = new clsListadoDepartamentosDAL();

            clsDepartamento departamento = await listadoDepartamentosDAL.departamentoPorID(id);

            return departamento;
        }

    }
}
