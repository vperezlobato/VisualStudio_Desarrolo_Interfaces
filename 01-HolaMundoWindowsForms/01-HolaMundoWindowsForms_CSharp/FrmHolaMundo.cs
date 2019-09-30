using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;

namespace _01_HolaMundoWindowsForms_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Evento asociado al click del botón saludar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaludo_Click(object sender, EventArgs e)
        {
            clsPersona oPersona = new clsPersona();
            //recogemos el nombre del textBox
            oPersona.nombre = txtNombre.Text;
            oPersona.apellido1 = txtApellido1.Text;
            oPersona.apellido2 = txtApellido2.Text;
            if (String.IsNullOrEmpty(oPersona.nombre)
                && !String.IsNullOrEmpty(oPersona.apellido1)
                && !String.IsNullOrEmpty(oPersona.apellido2))
            {
                MessageBox.Show("Has dejado el nombre vacio");
            }
            else
                if (String.IsNullOrEmpty(oPersona.apellido1)
                && !String.IsNullOrEmpty(oPersona.nombre)
                && !String.IsNullOrEmpty(oPersona.apellido2))
            {
                MessageBox.Show("Has dejado el primer apellido vacío");
            }
            else
                if (String.IsNullOrEmpty(oPersona.apellido2)
                && !String.IsNullOrEmpty(oPersona.nombre)
                && !String.IsNullOrEmpty(oPersona.apellido1))
            {
                MessageBox.Show("Has dejado el segundo apellido vacío");
            }
            else
                if (String.IsNullOrEmpty(oPersona.apellido2)
                && String.IsNullOrEmpty(oPersona.nombre)
                && !String.IsNullOrEmpty(oPersona.apellido1) ||
                String.IsNullOrEmpty(oPersona.nombre)
                && String.IsNullOrEmpty(oPersona.apellido1)
                && !String.IsNullOrEmpty(oPersona.apellido2) ||
                !String.IsNullOrEmpty(oPersona.nombre)
                && String.IsNullOrEmpty(oPersona.apellido1)
                && String.IsNullOrEmpty(oPersona.apellido2) ||
                String.IsNullOrEmpty(oPersona.nombre)
                && String.IsNullOrEmpty(oPersona.apellido1)
                && String.IsNullOrEmpty(oPersona.apellido2)
                )
                {
                    MessageBox.Show("Has dejado varios campos vacíos");
                } else
                    MessageBox.Show($"Hola {oPersona.nombre} {oPersona.apellido1} {oPersona.apellido2}");
        }


    }
}
