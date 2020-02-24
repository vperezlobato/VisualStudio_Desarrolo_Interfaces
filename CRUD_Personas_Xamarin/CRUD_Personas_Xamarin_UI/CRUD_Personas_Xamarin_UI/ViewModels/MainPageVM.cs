﻿using CRUD_Personas_Xamarin_BL;
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

        private void EliminarCommand_Executed()
        {
            
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
            //Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new DetallesPage());
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

        }

        private void InsertarCommand_Executed()
        {
            _personaSeleccionada = new clsPersona();
            //Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new DetallesPage());
        }
    }
}