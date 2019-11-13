using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace BuscaMinas.Models
{
    public class modeloVista : INotifyPropertyChanged
    {
        private int contadorAciertos;
        private List<clsCasilla> tablero;
        private clsCasilla casillaSeleccionada;

        public List<clsCasilla> Tablero { get { return tablero; }set { tablero = value; } }

        public clsCasilla CasillaSeleccionada {
            get { return casillaSeleccionada; }
            set { 
                casillaSeleccionada = value;
                if (casillaSeleccionada != null)
                {
                    comprobarCasilla();
                }

            }
        }

        public modeloVista() {
            tablero = listadoCasillas.generarTablero();
        }

        public async void comprobarCasilla() {
            if (CasillaSeleccionada.estado == true) {
                CasillaSeleccionada.yaPulsada = true;

                var dialog = new MessageDialog("Has Perdido");
                await dialog.ShowAsync();
                resetear();
            }
            else
            {
                CasillaSeleccionada.yaPulsada = true;
                contadorAciertos++;
                if (contadorAciertos == 5) {
                    var dialog = new MessageDialog("Has Ganado");
                    await dialog.ShowAsync();
                    resetear();
                }

            }       
        }

        public void resetear() {
            tablero = listadoCasillas.generarTablero();
            contadorAciertos = 0;
            NotifyPropertyChanged("Tablero");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
