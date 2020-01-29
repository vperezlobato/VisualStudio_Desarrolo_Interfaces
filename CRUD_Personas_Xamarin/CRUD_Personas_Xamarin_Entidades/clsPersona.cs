using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRUD_Personas_Xamarin_Entidades
{
    public class clsPersona
    {

        public String nombre { set; get; }

        public String apellidos { set; get; }

        public String direccion { set; get; }

        public DateTime fechaNacimiento { set; get; }
        
        public int idPersona { get; set; }

        public String telefono { get; set; }

        public byte[] foto { get; set; }
        public int idDepartamento { get; set; }

        //constructor por defecto
        public clsPersona() {
        }

        //constructor por parametros
        public clsPersona(String nombre, String apellidos,DateTime fechaNac,String telefono,int idDepartamento, int idPersona,byte[] foto) {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNacimiento = fechaNac;
            this.telefono = telefono;
            this.idDepartamento = idDepartamento;
            this.idPersona = idPersona;
            this.foto = foto;
        }


    }
}
