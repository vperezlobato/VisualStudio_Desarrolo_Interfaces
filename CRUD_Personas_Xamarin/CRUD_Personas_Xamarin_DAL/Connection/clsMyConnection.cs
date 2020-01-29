using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Esta clase contiene los métodos necesarios para trabajar con el acceso a una base de datos SQL Server
//PROPIEDADES
//   _server: cadena 
//   _database: cadena, básica. Consultable/modificable.
//   _user: cadena, básica. Consultable/modificable.
//   _pass: cadena, básica. Consultable/modificable.

// MÉTODOS
//   Function getConnection() As SqlConnection
//       Este método abre una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//   
//   Sub closeConnection(ByRef connection As SqlConnection)
//       Este método cierra una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//


namespace CRUD_Personas_Xamarin_DAL
{
    public class clsMyConnection
    {
        /// <summary>
        /// Este metodo permite obtener la uri de la api base
        /// </summary>
        /// <returns></returns>
        public String getUriBase()
        {

            String uriBase = "";
            uriBase = "https://crudpersonasui-victor.azurewebsites.net/api/";
            return uriBase;
        }


    }

}
