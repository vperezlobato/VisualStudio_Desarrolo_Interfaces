using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _08_Binding_Parte4_Entidades
{
    public class clsPersona
    {
        public String nombre { set; get; }

        public String apellidos { set; get; }

        public String direccion { set; get; }

        public DateTime fechaNacimiento { set; get; }

        public String telefono { set; get; }

        public clsPersona(String nombre, String apellidos, String direccion, DateTime fechaNacimiento, String telefono)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.direccion = direccion;
            this.fechaNacimiento = fechaNacimiento;
            this.telefono = telefono;
        }
        public clsPersona() { }
    }
}