using ExameN_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameN_DAL.Manejadoras
{
    public class gestionadoraMisiones
    {

        /// <summary>
        /// Funcion que recibe como parametro un objeto mision y editar sus datos en la DB
        /// </summary>
        /// <param name="objMision"></param>
        /// <returns>Devuelve el numero de filas afectadas</returns>
        public int editarMisionDAL(Mision objMision)
        {

            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = miConexion.getConnection();
            SqlCommand comando = new SqlCommand();
            int filas = 0;

            try
            {
                comando.Connection = conexion;

                comando.Parameters.Add("@reservada", System.Data.SqlDbType.Bit).Value = objMision.reservada;
                
                if (objMision.observaciones != null)
                {
                    comando.Parameters.Add("@observaciones", System.Data.SqlDbType.VarChar).Value = objMision.observaciones;
                }

                comando.Parameters.Add("@idSuperheroe", System.Data.SqlDbType.Int).Value = objMision.idSuperheroe;

                comando.Parameters.Add("@idMision", System.Data.SqlDbType.Int).Value = objMision.idMision;

                comando.CommandText = "UPDATE misiones SET reservada = @reservada, idSuperheroe = @idSuperheroe, observaciones = @observaciones Where idMision = @idMision ";

                filas = comando.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                miConexion.closeConnection(ref conexion);
            }
            return filas;

        }
    }
}
