using CRUD_Personas_Xamarin_BL;
using CRUD_Personas_Xamarin_Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CRUD_Personas_Xamarin_UI.ViewModels
{
    public class EditarVM:clsVMBase
    {
        private clsPersona _persona;
        private List<clsDepartamento> _departamentos;
        private DelegateCommand _editarCommand;
        private String _errorNombre, _errorApellidos, _errorDireccion, _errorTelefono, _errorDepartamento;
        private clsDepartamento _departamentoSeleccionado;

        public EditarVM() { }

        public EditarVM(clsPersona persona) {
            this.persona = persona;
            obtenerDepartamentos();
        }

        #region propiedades publicas
        public clsPersona persona {
            get {
                return _persona;
            }

            set {
                _persona = value;
                NotifyPropertyChanged("persona");
            }
        }

        public clsDepartamento departamentoSeleccionado
        {
            get
            {
                return _departamentoSeleccionado;
            }

            set
            {
                _departamentoSeleccionado = value;
                NotifyPropertyChanged("departamentoSeleccionado");
            }
        }

        public List<clsDepartamento> departamentos {
            get {
                return _departamentos;
            }

        }

        public String ErrorNombre
        {
            get
            {
                return _errorNombre;
            }
            set
            {
                _errorNombre = value;
            }
        }

        public String ErrorApellidos
        {
            get
            {
                return _errorApellidos;
            }
            set
            {
                _errorApellidos = value;
            }
        }

        public String ErrorDireccion
        {
            get
            {
                return _errorDireccion;
            }
            set
            {
                _errorDireccion = value;
            }
        }


        public String ErrorTelefono
        {
            get
            {
                return _errorTelefono;
            }
            set
            {
                _errorTelefono = value;
            }
        }

        public String ErrorDepartamento
        {
            get
            {
                return _errorDepartamento;
            }
            set
            {
                _errorDepartamento = value;
            }
        }
        #endregion

        public DelegateCommand EditarCommand {
            get {
                _editarCommand = new DelegateCommand(EditarCommand_Executed, EditarCommand_CanExecuted);
                return _editarCommand;
            }
        }

        public async void EditarCommand_Executed() {
            clsListadoPersonasBL listPersonasBL = new clsListadoPersonasBL();
            gestionadoraPersonas_BL gestionadora = new gestionadoraPersonas_BL();
            int filasAfectadas = 0;
            if (validarFormulario())
            {
                try
                {
                    _persona.idDepartamento = departamentoSeleccionado.id;
                    if (await listPersonasBL.existePersonaBL(_persona.idPersona))
                    {
                        filasAfectadas = await gestionadora.editarPersona_BL(_persona);
                        if (filasAfectadas == 1)
                        {
                            await Application.Current.MainPage.DisplayAlert("Editar", "Se ha editado correctamente", "OK");
                            limpiarFormulario();
                        }
                    }
                    else
                    {

                        filasAfectadas = await gestionadora.insertarPersona_BL(_persona);
                        if (filasAfectadas == 1)
                        {
                            await Application.Current.MainPage.DisplayAlert("Insertado", "Se ha insertado correctamente", "OK");
                            limpiarFormulario();
                            _persona = new clsPersona();
                            NotifyPropertyChanged("persona");
                            _departamentoSeleccionado = new clsDepartamento();
                            NotifyPropertyChanged("departamentoSeleccionado");
                        }
                    }
                }
                catch (Exception e) {
                    falloDeConexion();
                }
            }
        }

        public bool EditarCommand_CanExecuted() {
            bool guardable = false;

            if (_persona != null)
            {
                guardable = true;
            }

            return guardable;
        }

        /// <summary>
        /// Metodo para validar todos los campos del formulario
        /// </summary>
        /// <returns>Devuelve un boolean si se ha validado el formulario, false en caso contrario</returns>
        public bool validarFormulario()
        {

            bool valido = true;

            if (String.IsNullOrEmpty(_persona.nombre))
            {
                valido = false;
                _errorNombre = "Introduce un nombre";
                NotifyPropertyChanged("ErrorNombre");
            }
            else
            {
                _errorNombre = "";
                NotifyPropertyChanged("ErrorNombre");
            }

            if (String.IsNullOrEmpty(_persona.apellidos))
            {
                valido = false;
                _errorApellidos = "Introduce algun apellido";
                NotifyPropertyChanged("ErrorApellidos");
            }
            else
            {
                _errorApellidos = "";
                NotifyPropertyChanged("ErrorApellidos");
            }

            if (departamentoSeleccionado == null)
            {
                valido = false;
                _errorDepartamento = "Selecciona un departamento";
                NotifyPropertyChanged("ErrorDepartamento");
            }
            else
            {
                _errorDepartamento = "";
                NotifyPropertyChanged("ErrorDepartamento");
            }

            if (String.IsNullOrEmpty(_persona.telefono))
            {
                valido = false;
                _errorTelefono = "Introduce un telefono";
                NotifyPropertyChanged("ErrorTelefono");
            }
            else
            {
                _errorTelefono = "";
                NotifyPropertyChanged("ErrorTelefono");
            }

            if (String.IsNullOrEmpty(_persona.direccion))
            {
                valido = false;
                _errorDireccion = "Introduce una direccion";
                NotifyPropertyChanged("ErrorDireccion");
            }
            else
            {
                _errorDireccion = "";
                NotifyPropertyChanged("ErrorDireccion");
            }

            return valido;

        }

        /// <summary>
        /// Metodo para limpiar el formulario.
        /// </summary>
        public void limpiarFormulario()
        {
            _errorNombre = "";
            _errorApellidos = "";
            _errorDireccion = "";
            _errorTelefono = "";
            _errorDepartamento = "";
            NotifyPropertyChanged("ErrorNombre");
            NotifyPropertyChanged("ErrorApellidos");
            NotifyPropertyChanged("ErrorDireccion");
            NotifyPropertyChanged("ErrorDepartamento");
            NotifyPropertyChanged("ErrorTelefono");

        }


        public async void obtenerDepartamentos() {

            clsListadoDepartamentosBL departamento = new clsListadoDepartamentosBL();
            try
            {
                _departamentos = await departamento.listadoDepartamentosBL();
                NotifyPropertyChanged("departamentos");
            }
            catch (Exception)
            {
                falloDeConexion();
            }
        }


        private async void falloDeConexion()
        {
            await Application.Current.MainPage.DisplayAlert("Alert", "Error en la conexión", "OK");

            return;
        }


    }
}
