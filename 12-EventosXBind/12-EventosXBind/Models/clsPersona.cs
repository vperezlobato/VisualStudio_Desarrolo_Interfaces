using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _12_EventosXBind.Models
{
    public class clsPersona
    {
        public int id { get; set; }

        public String nombre { set; get; }

        public String apellidos { set; get; }

        public String direccion { set; get; }

        public DateTime fechaNacimiento { set; get; }

        public String telefono { set; get; }

        public clsPersona(String nombre, String apellidos, String direccion, DateTime fechaNacimiento, String telefono,int id)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.direccion = direccion;
            this.fechaNacimiento = fechaNacimiento;
            this.telefono = telefono;
        }
        public clsPersona() { }
    }
}