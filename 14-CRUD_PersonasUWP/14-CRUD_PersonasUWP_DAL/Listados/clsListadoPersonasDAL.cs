using _14_CRUD_PersonasUWP_DAL;
using _14_CRUD_PersonasUWP_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_CRUD_PersonasUWP_DAL
{
    public class clsListadoPersonasDAL
    {
        public List<clsPersona> listadoPersonas() {
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection(); 
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            System.Type tipoDBNULL = DBNull.Value.GetType();
            List<clsPersona> listadoPersonas = new List<clsPersona>();
            clsPersona objPersona;
                       
            try
            {
                miComando.CommandText = "SELECT * FROM PD_Personas";
                miComando.Connection = connection;
                miLector = miComando.ExecuteReader();
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        objPersona = new clsPersona();
                        objPersona.idPersona = miLector["IdPersona"].GetType() != tipoDBNULL ? (int)miLector["IdPersona"] : 0;
                        objPersona.nombre = miLector["NombrePersona"].GetType() != tipoDBNULL ? (string)miLector["NombrePersona"] : null;
                        objPersona.apellidos = miLector["ApellidosPersona"].GetType() != tipoDBNULL ? (string)miLector["ApellidosPersona"] : null;
                        objPersona.fechaNacimiento = miLector["FechaNacimientoPersona"].GetType() != tipoDBNULL ? (DateTime)miLector["FechaNacimientoPersona"] : new DateTime();
                        objPersona.direccion = miLector["Direccion"].GetType() != tipoDBNULL ? (string)miLector["Direccion"] : null;
                        objPersona.telefono = miLector["TelefonoPersona"].GetType() != tipoDBNULL ? (string)miLector["TelefonoPersona"] : null;
                        objPersona.idDepartamento = miLector["IDDepartamento"].GetType() != tipoDBNULL ? (int)miLector["IDDepartamento"] : 0;
                        listadoPersonas.Add(objPersona);
                    }
                }
                miLector.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally {
                
                miConexion.closeConnection(ref connection);
            }

            return listadoPersonas;
        }

        /// <summary>
        /// Metodo para comprobar que existe la persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean existePersona_DAL(int id)
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
        }
    }
    
}
