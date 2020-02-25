using CRUD_Personas_Xamarin_Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_Xamarin_DAL
{
    public class clsListadoPersonasDAL
    {
        /// <summary>
        /// Este metodo nos permite obtener un listado de las personas almacenadas en la BBDD.
        /// </summary>
        /// <returns>Devuelve un list de clsPersona</returns>
        public async Task<List<clsPersona>> listadoPersonas()
        {

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
        public async Task<Boolean> existePersona_DAL(int id)
        {
            clsPersona persona = new clsPersona();
            bool existe = false;
            HttpClient miCliente = new HttpClient();
            clsMyConnection miConexion = new clsMyConnection();

            String uriBase = miConexion.getUriBase();
            Uri requestUri = new Uri(uriBase + "PersonasAPI/"+id);

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await miCliente.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                persona = JsonConvert.DeserializeObject<clsPersona>(httpResponseBody);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            if (persona.idPersona != 0) { //no le puse a la api que manejara codigos de error asi que esto es un apaño para salir del bache
                existe = true;
            }

            return existe;
        }
    }

}
