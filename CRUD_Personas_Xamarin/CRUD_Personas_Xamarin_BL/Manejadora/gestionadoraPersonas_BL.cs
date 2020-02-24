using CRUD_Personas_Xamarin_DAL;
using CRUD_Personas_Xamarin_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_Xamarin_BL
{
    public class gestionadoraPersonas_BL
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
        public async Task<int> insertarPersona_BL(clsPersona objPersona)
       {

           int filas = 0;

           gestionadoraPersonas_DAL gestionadora = new gestionadoraPersonas_DAL();

           filas = await gestionadora.insertarPersona_DAL(objPersona);

           return filas;

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
        public async Task<int> borrarPersona_BL(int id) 
       {
           int filas = 0;

           gestionadoraPersonas_DAL gestionadora = new gestionadoraPersonas_DAL();

           filas = await gestionadora.borrarPersona_DAL(id);

           return filas;

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
        public async Task<int> editarPersona_BL(clsPersona objPersona) {

           int filas = 0;

           gestionadoraPersonas_DAL gestionadora = new gestionadoraPersonas_DAL();

           filas = await gestionadora.actualizarPersona_DAL(objPersona);

           return filas;
       }

    }
}
