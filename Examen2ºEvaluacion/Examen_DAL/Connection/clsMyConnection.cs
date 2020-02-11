using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Examen_DAL
{
    public class clsMyConnection
    {
        /// <summary>
        /// Este metodo permite obtener la uri de la api base
        /// </summary>
        /// <returns></returns>
        public String getUriBase() {

            String uriBase = "";
<<<<<<< HEAD
            uriBase = "http://webapiaemet.azurewebsites.net/api/";
=======
            uriBase = "https://crudpersonasui-victor.azurewebsites.net/api/";
>>>>>>> d1b429a2876663d5d862b57da28a68ea2e83f600
                return uriBase;
        }

    }

}
