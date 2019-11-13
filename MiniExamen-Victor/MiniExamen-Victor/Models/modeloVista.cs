using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniExamen_Victor.Models
{
    public class modeloVista : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<clsFabricante> _listadoFabricantes;
        private List<clsModelo> _listadModelos;
        private clsFabricante _fabricanteSeleccionado;       
        private clsModelo _modeloSeleccionado;

        private String _seleccionCompleta;

        public List<clsModelo> listadModelos {
            get{
                return _listadModelos;
            }
        }

        public List<clsFabricante> listadoFabricantes {
            get { return _listadoFabricantes;
            }
        }

        public String seleccionCompleta {
            get {
                if (fabricanteSeleccionado != null && modeloSeleccionado != null) {
                    _seleccionCompleta = fabricanteSeleccionado.marca + " " + modeloSeleccionado.nombre;
                }
                return _seleccionCompleta;
            }
        }

        public clsFabricante fabricanteSeleccionado
        {
            get { return _fabricanteSeleccionado; }
            set
            {
                _fabricanteSeleccionado = value;
                this._listadModelos = listadoModelos.encontrar(fabricanteSeleccionado.idFabricante, listadoModelos.listModelos());
                NotifyPropertyChanged("listadModelos");
            }
        }
        public clsModelo modeloSeleccionado{
            get { return _modeloSeleccionado; }
            set
            {
                _modeloSeleccionado = value;
                NotifyPropertyChanged("seleccionCompleta");
            }
        }

        public modeloVista() {
            listadoFabricantes listFabricantes = new listadoFabricantes();
            _listadoFabricantes = listFabricantes.listFabricantes();
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
