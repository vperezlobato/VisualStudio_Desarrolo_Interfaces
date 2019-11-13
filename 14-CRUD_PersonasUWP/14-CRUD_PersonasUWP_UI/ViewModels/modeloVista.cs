using _14_CRUD_PersonasUWP_BL;
using _14_CRUD_PersonasUWP_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _14_CRUD_PersonasUWP_UI
{
    public class modeloVista : clsVMBase
    {

        private ObservableCollection<clsPersona> _listadoPersona;
        private ObservableCollection<clsPersona> _listadoPersonaFiltrada;
        private clsPersona _personaSeleccionada;
        private DelegateCommand _EliminarCommand;
        private DelegateCommand _BuscarCommand;
        private String _textoABuscar;
        

        //constructor por defecto
        public modeloVista() {
            //rellenamos el constructor con el listado de personas
            clsListadoPersonasBL listPersonas = new clsListadoPersonasBL();
            _listadoPersona = new ObservableCollection<clsPersona>(listPersonas.listadoPersonas());
            _listadoPersonaFiltrada = new ObservableCollection<clsPersona>(listPersonas.listadoPersonas());

        }

        public clsPersona personaSeleccionada {
            get { return _personaSeleccionada; }
            set {
                if (_personaSeleccionada != value)
                {
                    _personaSeleccionada = value;
                    _EliminarCommand.RaiseCanExecuteChanged();
                    NotifyPropertyChanged("personaSeleccionada");
                }
            }
        }

        public ObservableCollection<clsPersona> listadoPersona {
            get { return _listadoPersona; }
            set { _listadoPersona = value; }
        }

        public ObservableCollection<clsPersona> listadoPersonaFiltrada
        {
            get {return _listadoPersonaFiltrada;}
            set{ _listadoPersonaFiltrada = value;}
        }

        public DelegateCommand EliminarCommand { 
            get {
                
                   _EliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecuted);
                    return _EliminarCommand;
                } 
        }

        public String textoABuscar
        {

            get { return _textoABuscar; }

            set
            {
                _textoABuscar = value;
                if (!String.IsNullOrEmpty(_textoABuscar))
                {                   
                    _BuscarCommand.Execute(null);
                    _BuscarCommand.RaiseCanExecuteChanged();
                }
                else {
                    _listadoPersonaFiltrada = _listadoPersona;
                }
                NotifyPropertyChanged("listadoPersonaFiltrada");
            }
        }

        private async void EliminarCommand_Executed()
        {
            ContentDialog confirmacion = new ContentDialog();
            confirmacion.Title = "Eliminar";
            confirmacion.Content = "¿Seguro que quieres borrar?";
            confirmacion.PrimaryButtonText = "Cancelar";
            confirmacion.SecondaryButtonText = "Aceptar";
            ContentDialogResult resultado = await confirmacion.ShowAsync();

            if (resultado == ContentDialogResult.Secondary)
            {
                _listadoPersonaFiltrada.Remove(_personaSeleccionada);
                NotifyPropertyChanged("personaSeleccionada");
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

        public DelegateCommand BuscarCommand
        {

            get
            {
                _BuscarCommand  = new DelegateCommand(BuscarCommand_Executed,BuscarCommand_CanExecuted);
                return _BuscarCommand;
            }
        }
        private void BuscarCommand_Executed()
        {
            filtrar(); 
        }

        private bool BuscarCommand_CanExecuted() {
            bool modificable = false;

            if (!String.IsNullOrEmpty(_textoABuscar)) {
                modificable = true; 
            }

            return modificable;
        }

        public void filtrar()
        {
            ObservableCollection<clsPersona> listadoPersonasFiltradas = new ObservableCollection<clsPersona>(_listadoPersona.ToList().FindAll(persona => String.Concat(persona.nombre, " ", persona.apellidos).Contains(_textoABuscar)));

           _listadoPersonaFiltrada = listadoPersonasFiltradas;
        }

    }
}
