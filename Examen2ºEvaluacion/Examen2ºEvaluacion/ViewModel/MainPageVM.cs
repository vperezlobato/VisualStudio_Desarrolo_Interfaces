using Examen_BL.Listados;
using Examen_Entities;
using Examen_UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_UI.ViewModel
{
    public class MainPageVM : clsVMBase
    {
        private ObservableCollection<clsCiudad> _listadoCiudades;
        private ObservableCollection<clsCiudad> _listadoCiudadesFiltradas;
        private clsCiudad _ciudadSeleccionada;
        private ObservableCollection<clsPrediccion> _listadoPredicciones;
        private String _textoBusqueda;

        public MainPageVM(){
            
            cargarDatos();
            
        }

        public async void cargarDatos() {
            ListadoCiudadesBL listadoCiudadesBL = new ListadoCiudadesBL();
            List<clsCiudad> list = await listadoCiudadesBL.listadoCiudades();

            ObservableCollection<clsCiudad> _listadoCiudades = new ObservableCollection<clsCiudad>(list);
            ObservableCollection<clsCiudad> _listadoCiudadesFiltradas = new ObservableCollection<clsCiudad>(list);
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
                    NotifyPropertyChanged("ciudadSeleccionada");
                }
            }
        }
    }
}
