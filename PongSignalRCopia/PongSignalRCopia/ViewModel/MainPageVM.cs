using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using PongSignalRCopia.Entidades;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace PongSignalRCopia.Model
{
    public class MainPageVM : clsVMBase
    {
        private HubConnection conn;
        private IHubProxy proxy;

        private DispatcherTimer dispatcherTimer { get; set; }
        private enumJugador _colision;
        private List<objetoJuego> _objetosJuego;
        private CoreDispatcher _dispatcher;

        public MainPageVM()
        {
            conn = new HubConnection("http://localhost:54209/");
            proxy = conn.CreateHubProxy("PongHub");
            conn.Start();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Tick += timerTick;

            _dispatcher = Window.Current.Dispatcher;

            _objetosJuego = new List<objetoJuego>();

            do
            {
                if (conn.State == ConnectionState.Connected)
                {
                    objetoJuego _jugador1 = new objetoJuego(0.0, "jugador1", "jugador1", false, 50, 300, new Uri("ms-appx:///Assets/barra.png"));
                    objetoJuego _jugador2 = new objetoJuego(880, "jugador2", "jugador2", false, 50, 300, new Uri("ms-appx:///Assets/barra.png"));
                    objetoJuego _pelota = new objetoJuego(250, "pelota", "pelota", false, 100, 500, null);
                    _objetosJuego.Add(_jugador1);
                    _objetosJuego.Add(_jugador2);
                    _objetosJuego.Add(_pelota);
                    getCliente();
                    proxy.Invoke("añadirObjetoJuego", _objetosJuego[0].id);
                    proxy.Invoke("añadirObjetoJuego", _objetosJuego[1].id);
                    proxy.Invoke("añadirObjetoJuego", _objetosJuego[2].id);
                    proxy.On<objetoJuego>("actualizarPosicionObjeto", actualizarPosicionObjeto);
                }

            } while (conn.State != ConnectionState.Connected);

        }

        public List<objetoJuego> objetosJuegos
        {
            get
            {
                return _objetosJuego;
            }
            set
            {
                _objetosJuego = value;

            }
        }


        public enumJugador colision
        {
            get
            {
                return _colision;
            }
            set
            {
                _colision = value;
            }
        }

        private void timerTick(object sender, object e)
        {
            move();
            actualizarPosicionesObjeto();
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
            if (_colision == enumJugador.jugador1)
            {
                posicionFutura = _objetosJuego[0].posicionY + _objetosJuego[0].velocidad;
                if (posicionFutura > 0 && posicionFutura < 1000)
                {
                    _objetosJuego[0].posicionY += _objetosJuego[0].velocidad;
                    _objetosJuego[0].seHaMovido = true;
                }
                NotifyPropertyChanged("objetosJuegos");
            }
            else
            {
                if (_colision == enumJugador.jugador2)
                {
                    posicionFutura = _objetosJuego[1].posicionY + _objetosJuego[1].velocidad;
                    if (posicionFutura > 0 && posicionFutura < 1000)
                    {
                        _objetosJuego[1].posicionY += _objetosJuego[1].velocidad;
                        _objetosJuego[1].seHaMovido = true;

                    }
                    NotifyPropertyChanged("objetosJuegos");
                }
            }
        }

        /// <summary>
        /// Método que se encarga de mover la barra hacia abajo
        /// </summary>
        public void abajo()
        {
            //_velocidad = 10;
            if (_colision == enumJugador.jugador1)
            {
                if (_objetosJuego[0].posicionY < 1000)
                {
                    _objetosJuego[0].velocidad = 10;
                }
                else
                {
                    _objetosJuego[0].velocidad = 0;
                }
            }
            else
            {
                if (_colision == enumJugador.jugador2)
                {
                    if (_objetosJuego[1].posicionY < 1000)
                    {
                        _objetosJuego[1].velocidad = 10;
                    }
                    else
                    {
                        _objetosJuego[1].velocidad = 0;
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
            if (_colision == enumJugador.jugador1)
            {
                if (_objetosJuego[0].posicionY > 0 && _objetosJuego[0].posicionY - 10 > 0)
                {
                    _objetosJuego[0].velocidad = -10;
                }
                else
                {
                    _objetosJuego[0].velocidad = 0;
                }
            }
            else
            {
                if (_colision == enumJugador.jugador2)
                {
                    if (_objetosJuego[1].posicionY > 0 && _objetosJuego[1].posicionY - 10 > 0)
                    {
                        _objetosJuego[1].velocidad = -10;
                    }
                    else
                    {
                        _objetosJuego[1].velocidad = 0;
                    }
                }
            }
        }

        public async void getCliente()
        {
            _colision = await proxy.Invoke<enumJugador>("getCliente");
        }

        public void actualizarPosicionesObjeto()
        {
            foreach (var index in _objetosJuego)
            {
                if (index.seHaMovido)
                {
                    proxy.Invoke("actualizarPosicionObjeto", index);
                    index.seHaMovido = false;
                }
            }
        }

        public async void actualizarPosicionObjeto(objetoJuego objetoJuego)
        {
            await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () => {
                foreach (var index in _objetosJuego)
                {
                    if (index.id == objetoJuego.id)
                    {
                        index.izquierda = objetoJuego.izquierda;
                        index.posicionY = objetoJuego.posicionY;
                    }
                }
                NotifyPropertyChanged("objetosJuegos");
            });

        }
    }
}
