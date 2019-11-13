using _13_Commands.Models;
using _13_Commands.ViewModels.Utiles;
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

namespace _13_Commands.ViewModels
{
    public class modeloVista : clsVMBase
    {

        private ObservableCollection<clsPersona> _lista;
        private clsPersona _personaSeleccionada;
        private DelegateCommand _EliminarCommand;
        private DelegateCommand _BuscarCommand;
        private String _textoABuscar;
        

        //constructor por defecto
        public modeloVista() {
            //rellenamos el constructor con el listado de personas
            listadoPersonas listPersonas = new listadoPersonas();
            _lista = listPersonas.listado();
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

        public ObservableCollection<clsPersona> lista {
            get { return _lista; }
            set { _lista = value; }
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
                NotifyPropertyChanged("textoABuscar");
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
                lista.Remove(_personaSeleccionada);
                NotifyPropertyChanged("lista");
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
                _BuscarCommand  = new DelegateCommand(BuscarCommand_Executed);
                return _BuscarCommand;
            }
        }
        private void BuscarCommand_Executed()
        {
            listadoPersonas listado = new listadoPersonas();
            _lista = listado.filtrar(_lista,_textoABuscar); 
            NotifyPropertyChanged("lista");

        }

    }
}
