using ExameN_BL.Listados;
using ExameN_BL.Manejadoras;
using ExameN_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Examen_UI
{
    public class clsMainPageVM : clsVMBase
    {
        private Superheroe _superheroeSeleccionado;
        private ObservableCollection<Superheroe> _listadoSuperheroes;
        private Mision _misionSeleccionada;
        private ObservableCollection<Mision> _listadoMisionesNoReservadas;
        private DelegateCommand _reservarMision;
        private String _visible;

        public clsMainPageVM() {
            ListadoSuperheroesBL list = new ListadoSuperheroesBL();
            _listadoSuperheroes = new ObservableCollection<Superheroe>(list.listadoSuperheroesBL());
            _listadoMisionesNoReservadas = new ObservableCollection<Mision>();
            _visible = "Collapsed";
        }

        public DelegateCommand reservarMision {
            get {
                _reservarMision = new DelegateCommand(reservarMision_Executed, reservarMision_CanExecuted);
                return _reservarMision;
            }
        }

        public String visible {
            get {
                return _visible;
            }
            set {
                _visible = value;
            }
        }

        public Superheroe superheroeSeleccionado {
            get {
                return _superheroeSeleccionado;
            }
            set {
                if (_superheroeSeleccionado != value) {
                    _superheroeSeleccionado = value;
                    _reservarMision.RaiseCanExecuteChanged();
                    ListadoMisionesBL listMisiones = new ListadoMisionesBL();
                    _listadoMisionesNoReservadas = new ObservableCollection<Mision>(listMisiones.listadoMisionesNoReservadasBL());
                    _visible = "Collapsed";
                    NotifyPropertyChanged("visible");
                    NotifyPropertyChanged("superheroeSeleccionado");
                    NotifyPropertyChanged("listadoMisionesNoReservadas");
                }
               
            }
        }

        public Mision misionSeleccionada
        {
            get
            {
                return _misionSeleccionada;
            }
            set
            {
                if (_misionSeleccionada != value)
                {
                    _misionSeleccionada = value;
                    _visible = "Visible";
                    NotifyPropertyChanged("visible");
                    _reservarMision.RaiseCanExecuteChanged();
                    NotifyPropertyChanged("misionSeleccionada");
                }


            }
        }

        public ObservableCollection<Superheroe> listadoSuperheroes {
            get {
                return _listadoSuperheroes;
            }
        }

        public ObservableCollection<Mision> listadoMisionesNoReservadas {
            get {
                return _listadoMisionesNoReservadas;
            }
        }

        private bool reservarMision_CanExecuted()
        {
            bool guardable = false;

            if (superheroeSeleccionado != null && misionSeleccionada != null)
            {
                guardable = true;
            }

            return guardable;
        }

        /// <summary>
        /// Metodo execute para realizar el update de la mision
        /// </summary>
        private async void reservarMision_Executed() {
            gestionadoraMisionesBL gestionadora = new gestionadoraMisionesBL();
            int filasAfectadas = 0;
            ContentDialog confirmadoCorrectamente = new ContentDialog();

            //cambiar los campos
            misionSeleccionada.idSuperheroe = superheroeSeleccionado.idSuperheroe;
            misionSeleccionada.reservada = true;

            filasAfectadas = gestionadora.editarMisionBL(misionSeleccionada);

            if (filasAfectadas == 1)
            {
                confirmadoCorrectamente.Title = "Guardado";
                confirmadoCorrectamente.Content = "Se ha guardado correctamente";
                confirmadoCorrectamente.PrimaryButtonText = "Aceptar";
                ContentDialogResult resultado = await confirmadoCorrectamente.ShowAsync();
                _visible = "Collapsed";
                NotifyPropertyChanged("visible");
            }

        }
    }
}
