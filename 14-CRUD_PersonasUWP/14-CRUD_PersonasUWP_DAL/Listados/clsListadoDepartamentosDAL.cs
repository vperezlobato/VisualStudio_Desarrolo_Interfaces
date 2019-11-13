using _14_CRUD_PersonasUWP_Entidades;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_CRUD_PersonasUWP_DAL
{
    public class clsListadoDepartamentosDAL
    {

        public List<clsDepartamento> listadoDepartamentos(){

            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = miConexion.getConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader miLector= null;

            clsDepartamento objDepartamento = new clsDepartamento();
            List<clsDepartamento> listado = new List<clsDepartamento>();

            comando.Connection = conexion;

            comando.CommandText = "Select * from PD_Departamentos";
            miLector = comando.ExecuteReader();

            if (miLector.HasRows) {
                while (miLector.Read()) {
                    objDepartamento.id = (int)miLector["IdDepartamento"];
                    objDepartamento.nombre = (string)miLector["NombreDepartamento"];
                    listado.Add(objDepartamento);               
                }            
            }

            miLector.Close();
            miConexion.closeConnection(ref conexion);

            return listado;
        }
    }
}
