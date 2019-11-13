using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_HolaMundoWebForms.WebForms
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaludo_Click(object sender, EventArgs e)
        {
            Models.clsPersona objPersona = new Models.clsPersona();
            objPersona.nombre = txtTexto.Text;
            objPersona.apellido1 = txtApellido1.Text;
            objPersona.apellido2 = txtApellido2.Text;
            objPersona.fechaNacimiento = calendario;

            if (String.IsNullOrEmpty(objPersona.nombre)
                && !String.IsNullOrEmpty(objPersona.apellido1)
                && !String.IsNullOrEmpty(objPersona.apellido2))
            {
                lblAlerta.Text = "El nombre no puede estar vacío";
                lblAlerta.Visible = true;
                lblSaludo.Visible = false;
                lblSaludo.Text = "";
            }
            else
                if (String.IsNullOrEmpty(objPersona.apellido1)
                && !String.IsNullOrEmpty(objPersona.nombre)
                && !String.IsNullOrEmpty(objPersona.apellido2))
            {
                lblAlerta.Text = "El primer apellido no puede estar vacío";
                lblAlerta.Visible = true;
                lblSaludo.Visible = false;
                lblSaludo.Text = "";
            }
            else
                if (String.IsNullOrEmpty(objPersona.apellido2)
                && !String.IsNullOrEmpty(objPersona.nombre)
                && !String.IsNullOrEmpty(objPersona.apellido1))
            {
                lblAlerta.Text = "El segundo apellido no puede estar vacío";
                lblAlerta.Visible = true;
                lblSaludo.Visible = false;
                lblSaludo.Text = "";
            }
            else
                if (String.IsNullOrEmpty(objPersona.apellido2)
                && String.IsNullOrEmpty(objPersona.nombre)
                && !String.IsNullOrEmpty(objPersona.apellido1) ||
                String.IsNullOrEmpty(objPersona.nombre)
                && String.IsNullOrEmpty(objPersona.apellido1)
                && !String.IsNullOrEmpty(objPersona.apellido2) ||
                !String.IsNullOrEmpty(objPersona.nombre)
                && String.IsNullOrEmpty(objPersona.apellido1)
                && String.IsNullOrEmpty(objPersona.apellido2) ||
                String.IsNullOrEmpty(objPersona.nombre)
                && String.IsNullOrEmpty(objPersona.apellido1)
                && String.IsNullOrEmpty(objPersona.apellido2)
                )
            {
                lblAlerta.Text = "Has dejado varios campos vacio";
                lblAlerta.Visible = true;
                lblSaludo.Visible = false;
                lblSaludo.Text = "";
            }
            else
            {
                lblSaludo.Text = $"Hola { objPersona.nombre} {objPersona.apellido1} {objPersona.apellido2} " +
                    $"con fecha de nacimiento: {objPersona.fechaNacimiento}";
                lblSaludo.Visible = true;
                lblAlerta.Visible = false;
                lblAlerta.Text = "";
            }
        }
    }
}