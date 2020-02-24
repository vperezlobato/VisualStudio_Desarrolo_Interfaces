using CRUD_Personas_Xamarin_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_Xamarin_UI.ViewModels
{
    public class DetallesVM
    {
        private clsPersona _personaSeleccionada;

        public DetallesVM()
        {
        }

        public DetallesVM(clsPersona persona) {
            _personaSeleccionada = persona;
        }

        public clsPersona personaSeleccionada {
            get {
                return _personaSeleccionada;
            }
        }
    }
}
