using CRUD_Personas_Xamarin_BL;
using CRUD_Personas_Xamarin_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CRUD_Personas_Xamarin_UI.ViewModels
{
    public class MainPageVM : clsVMBase
    {

        #region atributos privados
        private ObservableCollection<clsPersona> _listadoPersona;
        private ObservableCollection<clsDepartamento> _listadoDepartamentos;
        private clsPersona _personaSeleccionada;
        private DelegateCommand _actualizarCommand;
        private DelegateCommand _eliminarCommand;
        private DelegateCommand _insertarCommand;
        private DelegateCommand _detallesCommand;
        #endregion

        #region constructores
        //constructor por defecto
        public MainPageVM()
        {
            
            //rellenamos el constructor con el listado de personas
            clsListadoDepartamentosBL listDepartamentos = new clsListadoDepartamentosBL();
            cargarDatos();
        }

        public async void cargarDatos()
        {
            clsListadoPersonasBL listPersonas = new clsListadoPersonasBL();
            try
            {
                List<clsPersona> list = await listPersonas.listadoPersonas_BL();

                this._listadoPersona = new ObservableCollection<clsPersona>(list);
                NotifyPropertyChanged("listadoPersona");
            }
            catch (Exception e) {
                falloDeConexion();
            }
        }
        #endregion
        #region propiedades publicas
        public clsPersona personaSeleccionada
        {
            get { return _personaSeleccionada; }
            set
            {
                    _personaSeleccionada = value;
                    NotifyPropertyChanged("personaSeleccionada");
                    _eliminarCommand.RaiseCanExecuteChanged();
                    _actualizarCommand.RaiseCanExecuteChanged();
                    _detallesCommand.RaiseCanExecuteChanged();
                
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

        public DelegateCommand EliminarCommand
        {
            get
            {

                _eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecuted);
                return _eliminarCommand;
            }
        }

        public DelegateCommand ActualizarCommand
        {
            get
            {
                _actualizarCommand = new DelegateCommand(ActualizarCommand_Executed, ActualizarCommand_CanExecuted);
                return _actualizarCommand;
            }

        }


        public DelegateCommand InsertarCommand
        {
            get
            {
                _insertarCommand = new DelegateCommand(InsertarCommand_Executed);
                return _insertarCommand;

            }
        }

        public DelegateCommand DetallesCommand
        {
            get
            {
                _detallesCommand = new DelegateCommand(DetallesCommand_Executed, DetallesCommand_CanExecuted);
                return _detallesCommand;

            }
        }



        private bool EliminarCommand_CanExecuted()
        {
            bool eliminable = false;

            if (personaSeleccionada != null)
            {
                eliminable = true;
            }

            return eliminable;
        }

        private async void EliminarCommand_Executed()
        {
            int filasAfectadas = 0;
            gestionadoraPersonas_BL gestionadora = new gestionadoraPersonas_BL();
            bool answer = await Application.Current.MainPage.DisplayAlert("Confirmar", "¿Estas seguro de que deseas borrar esta persona?", "Si", "No");
            if (answer) {
                try
                {
                    filasAfectadas = await gestionadora.borrarPersona_BL(_personaSeleccionada.idPersona);
                    if (filasAfectadas == 1) {
                        await Application.Current.MainPage.DisplayAlert("Eliminado", "Se ha eliminado correctamente", "OK");
                        cargarDatos();
                        NotifyPropertyChanged("listadoPersona");
                        _personaSeleccionada = null;
                        NotifyPropertyChanged("personaSeleccionada");
                    }
                }
                catch (Exception e) {
                    falloDeConexion();
                }
            }
        }

        private bool ActualizarCommand_CanExecuted()
        {
            bool actualizable = false;

            if (personaSeleccionada != null)
            {
                actualizable = true;
            }

            return actualizable;
        }

        private void ActualizarCommand_Executed()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new EditarPage(personaSeleccionada));
        }

        private bool DetallesCommand_CanExecuted()
        {
            bool valido = false;

            if (personaSeleccionada != null)
            {
                valido = true;
            }

            return valido;
        }

        private void DetallesCommand_Executed()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new DetallesPage(personaSeleccionada));
        }

        private void InsertarCommand_Executed()
        {
            _personaSeleccionada = new clsPersona();
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new EditarPage(personaSeleccionada));
        }

        /// <summary>
        /// Metodo que muestra un dialogo en caso de error en la conexion a la api
        /// </summary>
        private async void falloDeConexion()
        {
            await Application.Current.MainPage.DisplayAlert("Alert", "Error en la conexión", "OK");

            return;
        }
    }
}
