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
    public class gestionadoraPersonas_DAL
    {

        /// <summary>
        /// Funcion que recibe por parametros a un objeto clsPersona y lo inserta en la DB
        /// </summary>
        /// <param name="objPersona"></param>
        /// <returns>Devuelve el numero de filas afectadas</returns>
        /*public int insertarPersona_DAL(clsPersona objPersona) {

            clsMyConnection miConexion = new clsMyConnection();
            SqlCommand comando = new SqlCommand();
            int filas = 0;
            SqlConnection conexion = miConexion.getConnection();
            System.Type tipoDBNULL = DBNull.Value.GetType();
            String foto,fechaNacimiento,telefono,direccion,apellidos,nombre,idDepartamento;
            try
            {
                comando.Connection = conexion;

                if (objPersona.nombre != null)
                {
                    comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = objPersona.nombre;
                    nombre = "@nombre";
                }
                else
                    nombre = "NULL";
                if (objPersona.apellidos != null)
                {
                    comando.Parameters.Add("@apellidosPersona", System.Data.SqlDbType.VarChar).Value = objPersona.apellidos;
                    apellidos = "@apellidosPersona";
                }
                else
                    apellidos = "NULL";

                    comando.Parameters.Add("@IDDepartamento", System.Data.SqlDbType.Int).Value = objPersona.idDepartamento;
                    idDepartamento = "@IDDepartamento";                

                if (objPersona.fechaNacimiento != null) { 
                    comando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.DateTime).Value = objPersona.fechaNacimiento;
                    fechaNacimiento = "@fechaNacimiento";
                }else
                    fechaNacimiento = "NULL";

                if (objPersona.telefono != null) {
                    comando.Parameters.Add("@telefonoPersona", System.Data.SqlDbType.VarChar).Value = objPersona.telefono;
                    telefono = "@telefonoPersona";
                } else
                    telefono = "NULL";

                if (objPersona.foto != null)
                {
                    comando.Parameters.Add("@fotoPersona", System.Data.SqlDbType.Binary).Value = objPersona.foto;
                    foto = "@fotoPersona";
                }
                else
                    foto = "NULL";

                if (objPersona.direccion != null) {
                    comando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = objPersona.direccion;
                    direccion = "@direccion";
                } else
                    direccion = "NULL";

                comando.CommandText = "Insert Into PD_Personas (NombrePersona,ApellidosPersona,IDDepartamento,FechaNacimientoPersona,TelefonoPersona,FotoPersona,Direccion) " +
                    "Values("+nombre+","+apellidos+","+idDepartamento+","+fechaNacimiento+","+telefono+","+foto+","+direccion+")";

                filas = comando.ExecuteNonQuery();

            }catch (SqlException e) {
                throw e;
            }
            finally {
                miConexion.closeConnection(ref conexion); 
            }

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

            try{
                comando.Connection = conexion;

                comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                comando.CommandText = "Delete FROM PD_Personas Where IdPersona = @id";                

                filas = comando.ExecuteNonQuery();
            }catch (SqlException e) {
                throw e;
            }
            finally {
                miConexion.closeConnection(ref conexion);
            }
            return filas;
        }

        /// <summary>
        /// Funcion que recibe como parametro un objeto persona y editar sus datos en la DB
        /// </summary>
        /// <param name="objPersona"></param>
        /// <returns>Devuelve el numero de filas afectadas</returns>
        public int editarPersona_DAL(clsPersona objPersona)
        {

            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = miConexion.getConnection();
            SqlCommand comando = new SqlCommand();
            int filas = 0;
            String fechaNacimiento, telefono, direccion, apellidos, nombre, idDepartamento, idPersona, foto;

            try
            {
                comando.Connection = conexion;

                if (objPersona.nombre != null)
                {
                    comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = objPersona.nombre;
                    nombre = "@nombre";
                }
                else
                    nombre = "NULL";
                if (objPersona.apellidos != null)
                {
                    comando.Parameters.Add("@apellidosPersona", System.Data.SqlDbType.VarChar).Value = objPersona.apellidos;
                    apellidos = "@apellidosPersona";
                }
                else
                    apellidos = "NULL";


                comando.Parameters.Add("@IDDepartamento", System.Data.SqlDbType.Int).Value = objPersona.idDepartamento;
                idDepartamento = "@IDDepartamento";

                if (objPersona.fechaNacimiento != null)
                {
                    comando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.DateTime).Value = objPersona.fechaNacimiento;
                    fechaNacimiento = "@fechaNacimiento";
                }
                else
                    fechaNacimiento = "NULL";

                if (objPersona.telefono != null)
                {
                    comando.Parameters.Add("@telefonoPersona", System.Data.SqlDbType.VarChar).Value = objPersona.telefono;
                    telefono = "@telefonoPersona";
                }
                else
                    telefono = "NULL";

                if (objPersona.foto != null)
                {
                    comando.Parameters.Add("@fotoPersona", System.Data.SqlDbType.Binary).Value = objPersona.foto;
                    foto = "@fotoPersona";
                }
                else
                    foto = "NULL";

                if (objPersona.direccion != null)
                {
                    comando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = objPersona.direccion;
                    direccion = "@direccion";
                }
                else
                    direccion = "NULL";

                comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = objPersona.idPersona;
                idPersona = "@id";

                comando.CommandText = "UPDATE PD_Personas SET NombrePersona =" + nombre + ",ApellidosPersona=" + apellidos + ",IDDepartamento=" + idDepartamento + ",FechaNacimientoPersona=" + fechaNacimiento + "," +
                    "TelefonoPersona=" + telefono + ",FotoPersona=" + foto + ",Direccion=" + direccion + " Where IdPersona=" + idPersona;

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

        /// <summary>
        /// Funcion que recibe como parametro un entero id y devuelve la persona correspondiente a ese id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un objeto persona</returns>
        public clsPersona buscarPersona_DAL(int id) {
            clsPersona objPersona = new clsPersona();

            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = miConexion.getConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader miLector = null;
            System.Type tipoDBNULL = DBNull.Value.GetType();
            String idPersona;
            try
            {
                comando.Connection = conexion;
                comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                idPersona = "@id";
                comando.CommandText = "Select * From PD_Personas Where Idpersona =" +idPersona;
                miLector = comando.ExecuteReader();

                if (miLector.HasRows)
                {
                    miLector.Read();

                    objPersona.idPersona = miLector["IdPersona"].GetType() != tipoDBNULL ? (int)miLector["IdPersona"] : 0;
                    objPersona.nombre = miLector["NombrePersona"].GetType() != tipoDBNULL ? (string)miLector["NombrePersona"] : null;
                    objPersona.apellidos = miLector["ApellidosPersona"].GetType() != tipoDBNULL ? (string)miLector["ApellidosPersona"] : null;
                    objPersona.fechaNacimiento = miLector["FechaNacimientoPersona"].GetType() != tipoDBNULL ? (DateTime)miLector["FechaNacimientoPersona"] : new DateTime();
                    objPersona.direccion = miLector["Direccion"].GetType() != tipoDBNULL ? (string)miLector["Direccion"] : null;
                    objPersona.telefono = miLector["TelefonoPersona"].GetType() != tipoDBNULL ? (string)miLector["TelefonoPersona"] : null;
                    objPersona.foto = miLector["FotoPersona"].GetType() != tipoDBNULL ? (byte[])miLector["FotoPersona"] : null;
                    objPersona.idDepartamento = miLector["IDDepartamento"].GetType() != tipoDBNULL ? (int)miLector["IDDepartamento"] : 0;
                }

                miLector.Close();
            }
            catch (SqlException e) {
                throw e;
            }
            finally{
                miConexion.closeConnection(ref conexion);
            }
            return objPersona;
        }*/

       
    }
}
