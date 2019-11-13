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

            List<clsPersona> listadoPersonas = new List<clsPersona>();
            clsPersona oPersona;

           
            miComando.CommandText = "SELECT * FROM PD_Personas";
            miComando.Connection = connection;
            miLector = miComando.ExecuteReader();
            if (miLector.HasRows)
            {
                while (miLector.Read())
                {
                    oPersona = new clsPersona();
                    oPersona.idPersona = (int)miLector["IDPersona"];
                    oPersona.nombre = (string)miLector["NombrePersona"];
                    oPersona.apellidos = (string)miLector["ApellidosPersona"];
                    oPersona.fechaNacimiento = (DateTime)miLector["FechaNacimientoPersona"];
                    oPersona.direccion = (string)miLector["Direccion"];
                    oPersona.telefono = (string)miLector["TelefonoPersona"];
                    oPersona.idDepartamento = (int)miLector["IDDepartamento"];
                    listadoPersonas.Add(oPersona);
                }
            }
            miLector.Close();
            miConexion.closeConnection(ref connection);

            return listadoPersonas;
        }
    }
    
}
