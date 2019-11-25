using _14_CRUD_PersonasUWP_BL;
using _14_CRUD_PersonasUWP_Entidades;
using _14_CRUD_PersonasUWP_UI.ViewModels.Utiles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace _14_CRUD_PersonasUWP_UI
{
    public class modeloVista : clsVMBase
    {
        #region atributos privados
        private ObservableCollection<clsPersona> _listadoPersona;
        private ObservableCollection<clsPersona> _listadoPersonaFiltrada;
        private ObservableCollection<clsDepartamento> _listadoDepartamentos;
        private clsPersona _personaSeleccionada;
        private DelegateCommand _EliminarCommand;
        private DelegateCommand _BuscarCommand;
        private DelegateCommand _InsertarCommand;
        private DelegateCommand _GuardarCommand;
        private String _textoABuscar;
        private String _errorNombre, _errorApellidos, _errorDireccion, _errorTelefono, _errorDepartamento;
        private BitmapImage _imagen;
        #endregion

        #region constructores
        //constructor por defecto
        public modeloVista() {
            //rellenamos el constructor con el listado de personas
            clsListadoPersonasBL listPersonas = new clsListadoPersonasBL();
            clsListadoDepartamentosBL listDepartamentos = new clsListadoDepartamentosBL();
            _listadoPersona = new ObservableCollection<clsPersona>(listPersonas.listadoPersonas_BL());
            _listadoPersonaFiltrada = new ObservableCollection<clsPersona>(listPersonas.listadoPersonas_BL());
            _listadoDepartamentos = new ObservableCollection<clsDepartamento>(listDepartamentos.listadoDepartamentos());
        }
        #endregion
        #region propiedades publicas
        public clsPersona personaSeleccionada {
            get { return _personaSeleccionada; }
            set {
               
                if (_personaSeleccionada != value)
                {
                    _personaSeleccionada = value;
                    _EliminarCommand.RaiseCanExecuteChanged();
                    _GuardarCommand.RaiseCanExecuteChanged();
                    _BuscarCommand.RaiseCanExecuteChanged();
                    if (personaSeleccionada != null)
                    {
                        convertirBitmap();
                    }
                    if (personaSeleccionada != null)
                    {
                        if (personaSeleccionada.foto == null)
                        {
                            _imagen = null;
                        }
                    }
                    NotifyPropertyChanged("personaSeleccionada");
                    NotifyPropertyChanged("GuardarCommand");
                    NotifyPropertyChanged("imagen");
                    limpiarFormulario();
                }
            }
        }
        
        public BitmapImage imagen {
            get { return _imagen; }
            set { 
                _imagen = value;         
                NotifyPropertyChanged("imagen");
            }
        }
        public ObservableCollection<clsPersona> listadoPersona
        {
            get { return _listadoPersona; }
            set { _listadoPersona = value; }
        }

        public ObservableCollection<clsDepartamento> listadoDepartamentos
        {
            get { return _listadoDepartamentos; }
            set { _listadoDepartamentos = value; }
        }
        public ObservableCollection<clsPersona> listadoPersonaFiltrada
        {
            get { return _listadoPersonaFiltrada; }
            set { _listadoPersonaFiltrada = value; }
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
                else
                {
                    _listadoPersonaFiltrada = _listadoPersona;
                }
                NotifyPropertyChanged("listadoPersonaFiltrada");
            }
        }

        public String ErrorNombre { 
            get { 
                return _errorNombre; 
            }
            set { 
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
        #endregion sin los commands

        #region commands y sus propiedades publicas       
        public DelegateCommand EliminarCommand { 
            get {
                
                   _EliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecuted);
                    return _EliminarCommand;
                } 
        }

        public DelegateCommand GuardarCommand
        {
            get {
                _GuardarCommand = new DelegateCommand(GuardarCommand_Executed,GuardarCommand_CanExecuted);
                return _GuardarCommand;
            }

        }
        public DelegateCommand InsertarCommand {
            get {
                _InsertarCommand = new DelegateCommand(InsertarCommand_Executed);
                return _InsertarCommand;

            }
        }
        public DelegateCommand BuscarCommand
        {

            get
            {
                _BuscarCommand = new DelegateCommand(BuscarCommand_Executed, BuscarCommand_CanExecuted);
                return _BuscarCommand;
            }
        }

        /// <summary>
        /// Executed de Guardar para actualizar o insertar a una persona.
        /// </summary>
        private async void GuardarCommand_Executed() {
            int filasAfectadas;
            gestionadoraPersonas_BL gestionadora = new gestionadoraPersonas_BL();
            clsListadoPersonasBL listadoPersonasBL = new clsListadoPersonasBL();
            ContentDialog confirmadoCorrectamente = new ContentDialog();

            if (validarFormulario())
            {
                if (listadoPersonasBL.existePersona_BL(_personaSeleccionada.idPersona))
                {
                    
                    filasAfectadas = gestionadora.editarPersona_BL(_personaSeleccionada);
                    if (filasAfectadas == 1)
                    {
                        actualizar();
                        confirmadoCorrectamente.Title = "Guardado";
                        confirmadoCorrectamente.Content = "Se ha guardado correctamente";
                        confirmadoCorrectamente.PrimaryButtonText = "Aceptar";
                        ContentDialogResult resultado = await confirmadoCorrectamente.ShowAsync();
                    }
                }
                else
                {
                    
                    filasAfectadas = gestionadora.insertarPersona_BL(_personaSeleccionada);
                    if (filasAfectadas == 1)
                    {
                        actualizar();
                        confirmadoCorrectamente.Title = "Guardado";
                        confirmadoCorrectamente.Content = "Se ha insertado correctamente";
                        confirmadoCorrectamente.PrimaryButtonText = "Aceptar";
                        ContentDialogResult resultado = await confirmadoCorrectamente.ShowAsync();
                    }
                }
            }
        }
        

        private bool GuardarCommand_CanExecuted() {
            bool guardable = false;

            if (personaSeleccionada != null)
            {
                guardable = true;
            }

            return guardable;
        }

        /// <summary>
        /// Executed de InsertarCommand para crear una nueva persona.
        /// </summary>
        private void InsertarCommand_Executed()
        {
            _personaSeleccionada = null;//lo uso para desactivar el comando eliminar cuando se hace una actualizacion y despues instancio una nueva persona para activar el guardar.
            NotifyPropertyChanged("personaSeleccionada");
            NotifyPropertyChanged("EliminarCommand");
            _personaSeleccionada = new clsPersona();
            _imagen = null; //es necesario para que no se quede la imagen de la personaSeleccionada
            _GuardarCommand.CanExecute(_personaSeleccionada); //es necesario cuando abres la aplicacion la primera vez y quieres añadir una persona.
            NotifyPropertyChanged("GuardarCommand");
            NotifyPropertyChanged("imagen");
            NotifyPropertyChanged("personaSeleccionada");
            limpiarFormulario();
        }

        /// <summary>
        /// Executed de EliminarCommand para borrar a la persona.
        /// </summary>
        private async void EliminarCommand_Executed()
        {
            int filasAfectadas = 0;
            gestionadoraPersonas_BL gestionadora = new gestionadoraPersonas_BL();
            clsListadoPersonasBL listPersonas = new clsListadoPersonasBL();

            ContentDialog eliminadoCorrectamente = new ContentDialog();
            ContentDialog confirmacion = new ContentDialog();

            confirmacion.Title = "Eliminar";
            confirmacion.Content = "¿Seguro que quieres borrar?";
            confirmacion.PrimaryButtonText = "Cancelar";
            confirmacion.SecondaryButtonText = "Aceptar";
            ContentDialogResult resultado = await confirmacion.ShowAsync();

            if (resultado == ContentDialogResult.Secondary)
            {
                filasAfectadas = gestionadora.borrarPersona_BL(_personaSeleccionada.idPersona);
                if (filasAfectadas == 1)
                {
                    actualizar();
                    eliminadoCorrectamente.Title = "Guardado";
                    eliminadoCorrectamente.Content = "Se ha eliminado correctamente";
                    eliminadoCorrectamente.PrimaryButtonText = "Aceptar";
                    ContentDialogResult resultadoEliminado = await eliminadoCorrectamente.ShowAsync();
                }
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
        #endregion

        #region metodo añadidos
        /// <summary>
        /// Metodo para filtrar el listado de personas segun lo escrito en el texto de busqueda.
        /// </summary>
        public void filtrar()
        {
            ObservableCollection<clsPersona> listadoPersonasFiltradas = new ObservableCollection<clsPersona>(_listadoPersona.ToList().FindAll(persona => String.Concat(persona.nombre, " ", persona.apellidos).Contains(_textoABuscar)));

           _listadoPersonaFiltrada = listadoPersonasFiltradas;
        }

        /// <summary>
        /// Metodo para actualizar el listado y limpiar el formulario. 
        /// </summary>
        public void actualizar() {
            clsListadoPersonasBL listPersonas = new clsListadoPersonasBL();
            _listadoPersonaFiltrada = new ObservableCollection<clsPersona>(listPersonas.listadoPersonas_BL());           
            NotifyPropertyChanged("listadoPersonaFiltrada");

            _personaSeleccionada = null; 
            NotifyPropertyChanged("personaSeleccionada");
            NotifyPropertyChanged("EliminarCommand");
            _imagen = null;
            NotifyPropertyChanged("imagen");
            limpiarFormulario();
        }

        /// <summary>
        /// Metodo para validar todos los campos del formulario
        /// </summary>
        /// <returns>Devuelve un boolean si se ha validado el formulario, false en caso contrario</returns>
        public bool validarFormulario() {

            bool valido = true;

            if (String.IsNullOrEmpty(personaSeleccionada.nombre))
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

            if (String.IsNullOrEmpty(personaSeleccionada.apellidos))
            {
                valido = false;
                _errorApellidos = "Introduce algun apellido";
                NotifyPropertyChanged("ErrorApellidos");
            }else
            {
                _errorApellidos = "";
                NotifyPropertyChanged("ErrorApellidos");
            }

            if (personaSeleccionada.idDepartamento == 0)
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

            if (String.IsNullOrEmpty(personaSeleccionada.telefono))
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

            if (String.IsNullOrEmpty(personaSeleccionada.direccion))
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
        public void limpiarFormulario() {
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
        /// <summary>
        /// Este metodo llama al metodo que convierte un array de bytes a bitmap.(Es necesario por el await)
        /// </summary>
        public async void convertirBitmap()
        {
            clsConversorImagen conversor = new clsConversorImagen();
            if (personaSeleccionada.foto != null)
            {
                Task<BitmapImage> taskImage = conversor.convertirABitmap(personaSeleccionada.foto);
                _imagen = await taskImage;
                NotifyPropertyChanged("imagen");
            }
        }

        /// <summary>
        /// Metodo para añadir una foto al formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Adjuntar_Click_1(object sender, RoutedEventArgs e)
        {

            PersonPicture personPicture = (PersonPicture)sender;
            var fileOpenPicker = new FileOpenPicker();
            fileOpenPicker.ViewMode = PickerViewMode.Thumbnail;
            fileOpenPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            fileOpenPicker.FileTypeFilter.Add(".png");
            fileOpenPicker.FileTypeFilter.Add(".jpg");
            fileOpenPicker.FileTypeFilter.Add(".jpeg");
            fileOpenPicker.FileTypeFilter.Add(".bmp");
            fileOpenPicker.FileTypeFilter.Add(".jfif");
            var storageFile = await fileOpenPicker.PickSingleFileAsync();

            if (storageFile != null)
            {
                // Ensure the stream is disposed once the image is loaded
                using (IRandomAccessStream fileStream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    // Set the image source to the selected bitmap
                    BitmapImage bitmapImage = new BitmapImage();

                    await bitmapImage.SetSourceAsync(fileStream);
                    personPicture.ProfilePicture = bitmapImage;

                    clsConversorImagen conversor = new clsConversorImagen();
                    Task<byte[]> taskImage = conversor.convertirAByte(storageFile);
                    byte[] foto = await taskImage;
                    personaSeleccionada.foto = foto;
                }
            }
        }
        
        #endregion
    }
}
