using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace _14_CRUD_PersonasUWP_DAL
{
    public class clsMyConnection
    {
        /// <summary>
        /// Este metodo permite obtener la uri de la api base
        /// </summary>
        /// <returns></returns>
        public String getUriBase() {

            String uriBase = "";
            uriBase = "https://crudpersonasui-victor.azurewebsites.net/api/";
                return uriBase;
        }

    }

}
