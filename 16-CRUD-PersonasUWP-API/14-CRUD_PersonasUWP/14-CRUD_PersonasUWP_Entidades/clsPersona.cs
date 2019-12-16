using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _14_CRUD_PersonasUWP_Entidades
{
    public class clsPersona
    {


        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombre")]
        public String nombre { set; get; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(40, ErrorMessage = "La longitud maxima es 40")]
        public String apellidos { set; get; }

        [MaxLength(200, ErrorMessage = "La longitud maxima es 200")]
        public String direccion { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime fechaNacimiento { set; get; }
        
        public int idPersona { get; set; }

        [RegularExpression(@"[679]{1}[0-9]{8}$", ErrorMessage = "Numero de telefono invalido")]
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
