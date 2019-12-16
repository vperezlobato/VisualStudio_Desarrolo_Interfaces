using _14_CRUD_PersonasUWP_DAL;
using _14_CRUD_PersonasUWP_Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace _14_CRUD_PersonasUWP_DAL
{
    public class clsListadoPersonasDAL
    {
        /// <summary>
        /// Este metodo nos permite obtener un listado de las personas almacenadas en la BBDD.
        /// </summary>
        /// <returns>Devuelve un list de clsPersona</returns>
        public async Task<List<clsPersona>> listadoPersonas() {

            List<clsPersona> listadoPersonas = new List<clsPersona>();

            HttpClient miCliente = new HttpClient();
            clsMyConnection miConexion = new clsMyConnection();

            String uriBase = miConexion.getUriBase();
            Uri requestUri = new Uri(uriBase + "PersonasAPI");

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await miCliente.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                listadoPersonas = JsonConvert.DeserializeObject<List<clsPersona>>(httpResponseBody);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return listadoPersonas;
            
        }

        /// <summary>
        /// Metodo para comprobar que existe la persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /*public Boolean existePersona_DAL(int id)
        {
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            Boolean existe = false;


            miComando.CommandText = "SELECT * FROM PD_Personas Where Idpersona =" + id;
            miComando.Connection = connection;
            miLector = miComando.ExecuteReader();

            if (miLector.HasRows)
            {
                existe = true;
            }

            miLector.Close();
            miConexion.closeConnection(ref connection);

            return existe;
        }*/
    }
    
}
