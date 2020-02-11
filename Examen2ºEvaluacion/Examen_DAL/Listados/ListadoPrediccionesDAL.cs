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
    public class ListadoPrediccionesDAL
    {
        /// <summary>
        /// Este metodo nos proporciona un listado de predicciones segun el id de la ciudad
        /// </summary>
        /// <param name="idCiudad"></param>
        /// <returns>listado de predicciones</returns>
        public async Task<List<clsPrediccion>> listadoPredicciones(int idCiudad)
        {

            List<clsPrediccion> listadoPredicciones = new List<clsPrediccion>();

            HttpClient miCliente = new HttpClient();
            clsMyConnection miConexion = new clsMyConnection();

            String uriBase = miConexion.getUriBase();
            Uri requestUri = new Uri(uriBase + "prediccion/"+idCiudad);

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await miCliente.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                listadoPredicciones = JsonConvert.DeserializeObject<List<clsPrediccion>>(httpResponseBody);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return listadoPredicciones;

        }
    }
}
