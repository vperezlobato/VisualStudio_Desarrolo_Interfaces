using Examen_Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Examen_DAL.Listados
{
    public class ListadoCiudadesDAL
    {

        /// <summary>
        /// Este metodo devuelve un listado de ciudades
        /// </summary>
        /// <returns>listado de ciudades</returns>
        public async Task<List<clsCiudad>> listadoCiudades()
        {

            List<clsCiudad> listadoCiudades = new List<clsCiudad>();

            HttpClient miCliente = new HttpClient();
            clsMyConnection miConexion = new clsMyConnection();

            String uriBase = miConexion.getUriBase();
            Uri requestUri = new Uri(uriBase + "ciudades");

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await miCliente.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                listadoCiudades = JsonConvert.DeserializeObject<List<clsCiudad>>(httpResponseBody);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return listadoCiudades;

        }
    }
}
