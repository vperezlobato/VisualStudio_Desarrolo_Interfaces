using _14_CRUD_PersonasUWP_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_CRUD_PersonasUWP_DAL
{
    public class gestionadoraPersonas_DAL
    {

        /// <summary>
        /// Funcion que recibe por parametros a un objeto clsPersona y lo inserta en la DB
        /// </summary>
        /// <param name="objPersona"></param>
        /// <returns>Devuelve el numero de filas afectadas</returns>
        public int insertarPersona_DAL(clsPersona objPersona) {

            clsMyConnection miConexion = new clsMyConnection();
            SqlCommand comando = new SqlCommand();
            int filas = 0;
            SqlConnection conexion = miConexion.getConnection();

            comando.Connection = conexion;

            comando.CommandText = "Insert Into Personas (NombrePersona,ApellidosPersona,IDDepartamento,FechaNacimientoPersona,TelefonoPersona,FotoPersona,Direccion) " +
                "Values(@nombrePersona,@apellidosPersona,@IDDepartamento,@fechaNacimiento,@telefonoPersona,NULL,@direccion)";

            comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = objPersona.nombre;
            comando.Parameters.Add("@apellidosPersona", System.Data.SqlDbType.VarChar).Value = objPersona.apellidos;
            comando.Parameters.Add("@IDDepartamento", System.Data.SqlDbType.Int).Value = objPersona.idDepartamento;
            comando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = objPersona.fechaNacimiento;
            comando.Parameters.Add("@telefonoPersona", System.Data.SqlDbType.VarChar).Value = objPersona.telefono;
            comando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = objPersona.direccion;

            filas = comando.ExecuteNonQuery();

            miConexion.closeConnection(ref conexion);

            return filas;
        }

        /// <summary>
        /// Funcion que recibe como parametro un entero id y borra a la persona correspondiente de ese id en la DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve el numero de filas afectadas</returns>
        public int borrarPersona_DAL(int id) {
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = miConexion.getConnection();
            int filas = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;

            comando.CommandText = "Delete FROM PD_Personas Where IdPersona = @id";
            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            filas = comando.ExecuteNonQuery();

            miConexion.closeConnection(ref conexion);

            return filas;
        }

        /// <summary>
        /// Funcion que recibe como parametro un objeto persona y editar sus datos en la DB
        /// </summary>
        /// <param name="objPersona"></param>
        /// <returns>Devuelve el numero de filas afectadas</returns>
        public int editarPersona_DAL(clsPersona objPersona) {

            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = miConexion.getConnection();
            SqlCommand comando = new SqlCommand();
            int filas = 0;

            comando.Connection = conexion;

            comando.CommandText = "UPDATE PD_Personas SET NombrePersona = @nombre,ApellidosPersona = @apellidos,IDDepartamento = @idDepartamento,FechaNacimientoPersona = @fechaNacimiento" +
                "TelefonoPersona = @telefono,Direccion = @direccion Where IdPersona = @id ";

            comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = objPersona.nombre;
            comando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = objPersona.apellidos;
            comando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = objPersona.idDepartamento;
            comando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = objPersona.fechaNacimiento;
            comando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = objPersona.telefono;
            comando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = objPersona.direccion;
            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = objPersona.idPersona;

            filas = comando.ExecuteNonQuery();

            miConexion.closeConnection(ref conexion);

            return filas;

        }

        /// <summary>
        /// Funcion que recibe como parametro un entero id y devuelve la persona correspondiente a ese id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un objeto persona</returns>
        public clsPersona detallesPersona_DAL(int id) {
            clsPersona objPersona = new clsPersona();

            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = miConexion.getConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader miLector = null;

            comando.Connection = conexion;
            comando.CommandText = "Select * From PD_Personas Where Idpersona = @id";
            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            miLector = comando.ExecuteReader();

            if (miLector.HasRows) {
                miLector.Read();

                objPersona.idPersona = (int)miLector["IdPersona"];
                objPersona.nombre = (string)miLector["NombrePersona"];
                objPersona.apellidos = (string)miLector["ApellidosPersona"];
                objPersona.idDepartamento = (int)miLector["IDDepartamento"];
                objPersona.fechaNacimiento = (DateTime)miLector["FechaNacimientoPersona"];
                objPersona.telefono = (string)miLector["TelefonoPersona"];
                objPersona.direccion = (string)miLector["Direccion"];
            }

            miLector.Close();
            miConexion.closeConnection(ref conexion);

            return objPersona;
        }
    }
}
