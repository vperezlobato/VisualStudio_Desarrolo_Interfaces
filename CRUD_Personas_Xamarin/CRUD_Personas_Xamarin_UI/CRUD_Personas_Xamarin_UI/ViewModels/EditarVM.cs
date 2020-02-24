using CRUD_Personas_Xamarin_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_Xamarin_UI.ViewModels
{
    public class EditarVM:clsVMBase
    {
        private clsPersona _persona;


        public EditarVM() { }

        public EditarVM(clsPersona persona) {
            this.persona = persona;
        }

        public clsPersona persona {
            get {
                return _persona;
            }

            set {
                _persona = value;
                NotifyPropertyChanged("persona");
            }
        }
    }
}
