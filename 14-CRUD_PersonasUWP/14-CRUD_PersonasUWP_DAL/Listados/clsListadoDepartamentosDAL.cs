using _14_CRUD_PersonasUWP_DAL;
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
            System.Type tipoDBNULL = DBNull.Value.GetType();
            clsDepartamento objDepartamento = new clsDepartamento();
            List<clsDepartamento> listado = new List<clsDepartamento>();


            try
            {
                comando.Connection = conexion;

                comando.CommandText = "Select * from PD_Departamentos";
                miLector = comando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        objDepartamento = new clsDepartamento();
                        objDepartamento.id = miLector["IdDepartamento"].GetType() != tipoDBNULL ? (int)miLector["IdDepartamento"] : 0;
                        objDepartamento.nombre = miLector["NombreDepartamento"].GetType() != tipoDBNULL ? (string)miLector["NombreDepartamento"] : null;
                        listado.Add(objDepartamento);
                    }
                }
                miLector.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                miConexion.closeConnection(ref conexion);
            }
            return listado;
        }

        public clsDepartamento departamentoPorID(int id)
        {
            clsDepartamento objDepartamento = new clsDepartamento();
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                miComando.CommandText = "SELECT * FROM PD_Departamentos WHERE IDDepartamento  = " + id;
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        objDepartamento = new clsDepartamento();
                        objDepartamento.id = (int)miLector["IDDepartamento"];
                        objDepartamento.nombre = (string)miLector["NombreDepartamento"];
                    }
                }
                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return objDepartamento;
        }
    }
}
