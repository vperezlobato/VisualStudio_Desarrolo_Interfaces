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
    public class clsListadoDepartamentosDAL
    {

        /// <summary>
        /// Este metodo nos permite obtener un listado de los departamentos almacenados en la BBDD.
        /// </summary>
        /// <returns>Devuelve un list de clsDepartamento</returns>
        public async Task<List<clsDepartamento>> listadoDepartamentos()
        {

            List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();

            HttpClient miCliente = new HttpClient();
            clsMyConnection miConexion = new clsMyConnection();

            String uriBase = miConexion.getUriBase();
            Uri requestUri = new Uri(uriBase + "departamentos/");

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await miCliente.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                listadoDepartamentos = JsonConvert.DeserializeObject<List<clsDepartamento>>(httpResponseBody);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return listadoDepartamentos;

        }

        public async Task<clsDepartamento> departamentoPorID(int id)
        {
            clsDepartamento departamento = new clsDepartamento();

            HttpClient miCliente = new HttpClient();
            clsMyConnection miConexion = new clsMyConnection();

            String uriBase = miConexion.getUriBase();
            Uri requestUri = new Uri(uriBase + "departamentos/"+id);

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await miCliente.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                departamento = JsonConvert.DeserializeObject<clsDepartamento>(httpResponseBody);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return departamento;
        }
    }
}
