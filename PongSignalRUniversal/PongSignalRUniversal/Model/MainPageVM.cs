using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using PongSignalRUniversal.Entidades;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace PongSignalRUniversal.Model
{
    public class MainPageVM : clsVMBase
    {
        private HubConnection conn;
        private IHubProxy proxy;
        private objetoJuego _jugador1; 
        private objetoJuego _jugador2;
        private objetoJuego _pelota;
        private DispatcherTimer dispatcherTimer { get; set; }
        private enumColision _colision;

        public MainPageVM(){
            conn = new HubConnection("http://localhost:54209/");
            proxy = conn.CreateHubProxy("PongHub");
            conn.Start();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Tick += timerTick;

            do {
                _jugador1 = new objetoJuego(0.0, "jugador1", "jugador1", false, 50, 300, new Uri("ms-appx:///Assets/barra.png"));
                _jugador2 = new objetoJuego(880, "jugador2", "jugador2", false, 50, 300, new Uri("ms-appx:///Assets/barra.png"));
                _pelota = new objetoJuego(250, "pelota", "pelota", false, 100, 500, null);
                if (conn.State == ConnectionState.Connected)
                {
                    getCliente();
                    proxy.Invoke("añadirObjetoJuego", _pelota.id);
                    proxy.Invoke("añadirObjetoJuego", _jugador1.id);
                    proxy.Invoke("añadirObjetoJuego", _jugador2.id);
                }

            }while(conn.State != ConnectionState.Connected);

            
         }

        public objetoJuego jugador1 {
            get { return _jugador1; }
            set {
                _jugador1 = value;
            }
        }

        public objetoJuego jugador2
        {
            get { return _jugador2; }
            set
            {
                _jugador2 = value;
            }
        }

        public enumColision colision {
            get {
                return _colision;
            }
            set {
                _colision = value;
            }
        }

        private void timerTick(object sender, object e)
        {
            move();
        }

        /// <summary>
        /// Evento que se da al pulsar una tecla, en este caso, W y S para mover la barra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.W)
            {
                arriba();
                dispatcherTimer.Start();
            }

            if (e.Key == VirtualKey.S)
            {
                abajo();
                dispatcherTimer.Start();
            }

        }
        /// <summary>
        /// Evento que se da al levantar una tecla, en este caso, W o S para parar el movimiento de la barra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Grid_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.W || e.Key == VirtualKey.S)
            {
                dispatcherTimer.Stop();
            }
        }
        /// <summary>
        /// Método que se encarga de mover la barra y controlar que no se salga del canvas
        /// </summary>
        public void move()
        {
            Double posicionFutura;
            if (_colision == enumColision.jugador1)
            {
                posicionFutura = _jugador1.posicionY + _jugador1.velocidad;
                if (posicionFutura > 0 && posicionFutura < 1000)
                {
                    _jugador1.posicionY += _jugador1.velocidad;
                    proxy.Invoke("actualizarPosicionObjeto", jugador1);
                }
                NotifyPropertyChanged("jugador1");
            }
            else {
                if (_colision == enumColision.jugador2)
                {
                    posicionFutura = _jugador2.posicionY + _jugador2.velocidad;
                    if (posicionFutura > 0 && posicionFutura < 1000)
                    {
                        _jugador2.posicionY += _jugador2.velocidad;
                        proxy.Invoke("actualizarPosicionObjeto", jugador2);
                    }
                    NotifyPropertyChanged("jugador2");
                }
            }
        }

        /// <summary>
        /// Método que se encarga de mover la barra hacia abajo
        /// </summary>
        public void abajo()
        {
            //_velocidad = 10;
            if (_colision == enumColision.jugador1)
            {
                if (_jugador1.posicionY < 1000)
                {
                    _jugador1.velocidad = 10;
                }else{
                    _jugador1.velocidad = 0;
                }
            }else {
                if (_colision == enumColision.jugador2)
                {
                    if (_jugador2.posicionY < 1000)
                    {
                        _jugador2.velocidad = 10;
                    }else{
                        _jugador2.velocidad = 0;
                    }
                }
            }
        }
        /// <summary>
        /// Método que se encarga de mover la barra hacia arriba
        /// </summary>
        public void arriba()
        {
            //_velocidad = -10;
            if (_colision == enumColision.jugador1)
            {
                if (_jugador1.posicionY > 0 && _jugador1.posicionY - 10 > 0)
                {
                    _jugador1.velocidad = -10;
                }else{
                    _jugador1.velocidad = 0;
                }
            }else
            {
                if (_colision == enumColision.jugador2)
                {
                    if (_jugador2.posicionY > 0 && _jugador2.posicionY - 10 > 0)
                    {
                        _jugador2.velocidad = -10;
                    }else{
                        _jugador2.velocidad = 0;
                    }
                }
            }
        }

        public async void getCliente() {
            _colision = await proxy.Invoke<enumColision>("getCliente");
        }
    }
}
