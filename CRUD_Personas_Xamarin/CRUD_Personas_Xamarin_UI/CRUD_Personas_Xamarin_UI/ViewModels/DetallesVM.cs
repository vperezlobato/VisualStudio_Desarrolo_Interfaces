using CRUD_Personas_Xamarin_BL;
using CRUD_Personas_Xamarin_Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CRUD_Personas_Xamarin_UI.ViewModels
{
    public class DetallesVM:clsVMBase
    {
        private clsPersona _personaSeleccionada;
        private clsDepartamento _departamento;

        public DetallesVM()
        {            
        }

        public DetallesVM(clsPersona persona) {
            _personaSeleccionada = persona;
            obtenerDepartamento();
        }

        public clsPersona personaSeleccionada {
            get {
                return _personaSeleccionada;
            }
            set {
                _personaSeleccionada = value;
            }
        }

        public clsDepartamento departamento {
            get {
                return _departamento;
            }
            set {
                _departamento = value;
            }
        }

        public async void obtenerDepartamento() {

            clsListadoDepartamentosBL departamento = new clsListadoDepartamentosBL();
            try
            {
                _departamento = await departamento.departamentoPorIDBL(_personaSeleccionada.idDepartamento);
                NotifyPropertyChanged("PersonsDepartament");
            }
            catch (Exception)
            {
                falloDeConexion();
            }
        }

        private async void falloDeConexion()
        {
            await Application.Current.MainPage.DisplayAlert("Alert","Error en la conexión","OK");

            return;
        }
    }
}
