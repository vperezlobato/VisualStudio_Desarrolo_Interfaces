using CRUD_Personas_Xamarin_BL;
using CRUD_Personas_Xamarin_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace CRUD_Personas_Xamarin_UI.ViewModels
{
    public class MainPageVM : clsVMBase
    {

        #region atributos privados
        private ObservableCollection<clsPersona> _listadoPersona;
        private ObservableCollection<clsDepartamento> _listadoDepartamentos;
        private clsPersona _personaSeleccionada;
        #endregion

        #region constructores
        //constructor por defecto
        public MainPageVM()
        {
            //rellenamos el constructor con el listado de personas

            clsListadoDepartamentosBL listDepartamentos = new clsListadoDepartamentosBL();
            cargarDatos();

            /*_listadoDepartamentos = new ObservableCollection<clsDepartamento>(listDepartamentos.listadoDepartamentos());*/
        }

        public async void cargarDatos()
        {
            clsListadoPersonasBL listPersonas = new clsListadoPersonasBL();

            List<clsPersona> list = await listPersonas.listadoPersonas_BL();

            this._listadoPersona = new ObservableCollection<clsPersona>(list);
            NotifyPropertyChanged("listadoPersona");
        }
        #endregion
        #region propiedades publicas
        public clsPersona personaSeleccionada
        {
            get { return _personaSeleccionada; }
            set
            {

                if (_personaSeleccionada != value)
                {
                    _personaSeleccionada = value;
                    NotifyPropertyChanged("personaSeleccionada");

                }
            }
        }

        public ObservableCollection<clsPersona> listadoPersona
        {
            get { return _listadoPersona; }
            set {
                _listadoPersona = value;
            }
        }

        public ObservableCollection<clsDepartamento> listadoDepartamentos
        {
            get { return _listadoDepartamentos; }
            set { _listadoDepartamentos = value; }
        }

        #endregion

    }
}
