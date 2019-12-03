using ExameN_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameN_DAL.Listados
{
    public class ListadoSuperheroesDAL
    {

        /// <summary>
        /// Este metodo ofrece un listado de superheroes
        /// </summary>
        /// <returns>List<Superheroe> listadoSuperheroes</returns>
        public List<Superheroe> listadoSuperheroesDAL()
        {
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            System.Type tipoDBNULL = DBNull.Value.GetType();
            List<Superheroe> listadoSuperheroes = new List<Superheroe>();
            Superheroe objSuperheroe;

            try
            {
                miComando.CommandText = "SELECT * FROM superheroes";
                miComando.Connection = connection;
                miLector = miComando.ExecuteReader();
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        objSuperheroe = new Superheroe();
                        objSuperheroe.idSuperheroe = miLector["idSuperheroe"].GetType() != tipoDBNULL ? (int)miLector["idSuperheroe"] : 0;
                        objSuperheroe.nombreSuperheroe = miLector["nombreSuperheroe"].GetType() != tipoDBNULL ? (string)miLector["nombreSuperheroe"] : null;
                        objSuperheroe.asignarImagen();
                        listadoSuperheroes.Add(objSuperheroe);
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

                miConexion.closeConnection(ref connection);
            }

            return listadoSuperheroes;
        }
    }
        
}
