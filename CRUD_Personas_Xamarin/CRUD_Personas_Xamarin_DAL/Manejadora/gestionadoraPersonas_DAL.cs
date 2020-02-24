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
    public class gestionadoraPersonas_DAL
    {

        /// <summary>
        /// Este método sirve para insertar una persona en la base de datos.
        /// </summary>
        /// <param name="objPersona">
        /// La persona ha insertar
        /// </param>
        /// <returns>
        /// El método devuelve el número de filas afectadas.
        /// </returns>
        public async Task<int> insertarPersona_DAL(clsPersona objPersona)
        {
            HttpClient miCliente = new HttpClient();
            clsMyConnection miConexion = new clsMyConnection();

            String uriBase = miConexion.getUriBase();
            Uri requestUri = new Uri(uriBase + "PersonasAPI/");
            int filasAfectadas = 0;
            String data;
            HttpContent content;

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                data = JsonConvert.SerializeObject(objPersona);
                content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                response = await miCliente.PostAsync(requestUri, content);
            }
            catch (Exception e)
            {
                throw e;
            }

            if (response.IsSuccessStatusCode)
            {
                filasAfectadas = 1;
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Método que elimina una persona de la BBDD
        /// </summary>
        /// <param name="idPersona">
        /// ID de la persona a eliminar
        /// </param>
        /// <returns>
        /// El numero de filas afectadas
        /// </returns>
        public async Task<int> borrarPersona_DAL(int idPersona)
        {

            HttpClient miCliente = new HttpClient();
            clsMyConnection miConexion = new clsMyConnection();

            String uriBase = miConexion.getUriBase();
            Uri requestUri = new Uri(uriBase + "PersonasAPI/"+idPersona);
            int filasAfectadas = 0;

            try
            {
                HttpResponseMessage response = await miCliente.DeleteAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    filasAfectadas = 1;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
           
            return filasAfectadas;
        }

        /// <summary>
        /// Comentario: Este método nos permite actualizar una persona en la base de datos.
        /// </summary>
        /// <param name="oPersona">
        /// Actualización de la persona.
        /// </param>
        /// <returns>
        /// El método devuelve un entero asociado al nombre que es el número de filas afectadas.
        /// </returns>
        public async Task<int> actualizarPersona_DAL(clsPersona objPersona)
        {

            HttpClient miCliente = new HttpClient();
            clsMyConnection miConexion = new clsMyConnection();

            String uriBase = miConexion.getUriBase();
            Uri requestUri = new Uri(uriBase + "PersonasAPI/" + objPersona.idPersona);
            int filasAfectadas = 0;
            String data;
            HttpContent content;

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                data = JsonConvert.SerializeObject(objPersona);
                content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                response = await miCliente.PutAsync(requestUri, content);
            }
            catch (Exception e)
            {
                throw e;
            }

            if (response.IsSuccessStatusCode)
            {
                filasAfectadas = 1;
            }

            return filasAfectadas;
        }
    }
}
