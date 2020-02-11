using Examen_BL.Listados;
using Examen_Entities;
using ExamenUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenUI.ViewModel
{
    public class MainPageVM : clsVMBase
    {
        private ObservableCollection<clsCiudad> _listadoCiudades;
        private ObservableCollection<clsCiudad> _listadoCiudadesFiltradas;
        private clsCiudad _ciudadSeleccionada;
        private ObservableCollection<clsPrediccion> _listadoPredicciones;
        private String _textoABuscar;
        private ObservableCollection<clsPrediccionConNombreCiudadYImagen> _listadoPrediccionesConNombreCiudadYImagen;

        public MainPageVM(){
            
            cargarDatos();
            
        }

        /// <summary>
        /// Metodo para cargar el listado de ciudades
        /// </summary>
        public async void cargarDatos() {
            ListadoCiudadesBL listadoCiudadesBL = new ListadoCiudadesBL();
            List<clsCiudad> list = await listadoCiudadesBL.listadoCiudades();

            _listadoCiudades = new ObservableCollection<clsCiudad>(list);
            _listadoCiudadesFiltradas = new ObservableCollection<clsCiudad>(list);
            NotifyPropertyChanged("listadoCiudades");
            NotifyPropertyChanged("listadoCiudadesFiltradas");
        }

        public ObservableCollection<clsCiudad> listadoCiudades {
            get {
                return _listadoCiudades;
            }

            set {
                _listadoCiudades = value;
            }
        }

        public ObservableCollection<clsCiudad> listadoCiudadesFiltradas
        {
            get
            {
                return _listadoCiudadesFiltradas;
            }

            set
            {
                _listadoCiudadesFiltradas = value;
            }
        }

        public clsCiudad ciudadSeleccionada {
            get {
                return _ciudadSeleccionada;
            }

            set {
                if (_ciudadSeleccionada != value)
                {
                    _ciudadSeleccionada = value;
                    if (_ciudadSeleccionada != null) //Necesario porque si no peta al tener seleccionado a una ciudad y hacer la busqueda
                    {
                        cargarListadoPredicciones(_ciudadSeleccionada.idCiudad);
                        NotifyPropertyChanged("ciudadSeleccionada");
                    }
                }
            }
        }

        /// <summary>
        /// Carga el listado de las predicciones
        /// </summary>
        /// <param name="idCiudad"></param>
        public async void cargarListadoPredicciones(int idCiudad) {
            ListadoPrediccionesBL listadoPrediccionesBL = new ListadoPrediccionesBL();
            List<clsPrediccion> list = await listadoPrediccionesBL.listadoPredicciones(idCiudad);

            _listadoPredicciones = new ObservableCollection<clsPrediccion>(list);
            pasarAListadoDePrediccionesConNombreDeCiudadEImagen(_listadoPredicciones);
        }
        
        /// <summary>
        /// Con este metodo los que hago es pasar los datos de la entidad de persistencia clsPrediccion al modelo con la imagen
        /// </summary>
        /// <param name="listadoPredicciones"></param>
        private void pasarAListadoDePrediccionesConNombreDeCiudadEImagen(ObservableCollection<clsPrediccion> listadoPredicciones)
        {
            _listadoPrediccionesConNombreCiudadYImagen = new ObservableCollection<clsPrediccionConNombreCiudadYImagen>();
            foreach (var item in listadoPredicciones) {
                clsPrediccionConNombreCiudadYImagen objPrediccion = new clsPrediccionConNombreCiudadYImagen();
                objPrediccion.pronostico = item.pronostico;
                objPrediccion.humedad = item.humedad;
                objPrediccion.temperaturaMaxima = item.temperaturaMaxima;
                objPrediccion.temperaturaMinima = item.temperaturaMinima;
                objPrediccion.fecha = item.fecha;
                objPrediccion.idCiudad = item.idCiudad;
                _listadoPrediccionesConNombreCiudadYImagen.Add(objPrediccion);
            }
            NotifyPropertyChanged("listadoPrediccionesConNombreCiudadYImagen");
        }

        public ObservableCollection<clsPrediccionConNombreCiudadYImagen> listadoPrediccionesConNombreCiudadYImagen {
            get { return _listadoPrediccionesConNombreCiudadYImagen; }
            set {
                _listadoPrediccionesConNombreCiudadYImagen = value;
            }
        }

        public ObservableCollection<clsPrediccion> listadoPredicciones {
            get {
                return _listadoPredicciones;
            }

            set {
                _listadoPredicciones = value;
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
                    filtrar();
                }
                else
                {
                    _listadoCiudadesFiltradas = _listadoCiudades;
                }
                NotifyPropertyChanged("listadoCiudadesFiltradas");
            }
        }

        /// <summary>
        /// Metodo que sirve para filtrar el listado de las ciudades
        /// </summary>
        public void filtrar()
        {
            ObservableCollection<clsCiudad> listadoCiudadesFiltrada = new ObservableCollection<clsCiudad>(_listadoCiudades.ToList().FindAll(ciudad => String.Concat(ciudad.nombreCiudad).Contains(_textoABuscar)));

            _listadoCiudadesFiltradas = listadoCiudadesFiltrada;
        }
    
    }
}
