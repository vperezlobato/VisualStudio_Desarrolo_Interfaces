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

        public MainPageVM(){
            //conn = new HubConnection("https://pongsignalr.azurewebsites.net/");
            //proxy = conn.CreateHubProxy("PongHub");
            //conn.Start();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Tick += timerTick;

            _jugador1 = new objetoJuego(0, "jugador1", "jugador1", false, 50, 300, new Uri("ms-appx:///Assets/barra.png"));
            _jugador2 = new objetoJuego(880, "jugador2", "jugador2", false, 50, 300, new Uri("ms-appx:///Assets/barra.png"));
            _pelota = new objetoJuego(250, "pelota", "pelota", false, 100, 500, null);
            //proxy.Invoke("añadirObjetoJuego",_pelota.id);
            //proxy.Invoke("añadirObjetoJuego",_jugador1.id);
            //proxy.Invoke("añadirObjetoJuego",_jugador2.id);
            getCliente();
        }

        public objetoJuego jugador1 {
            get { return _jugador1; }
            set { _jugador1 = value;
                NotifyPropertyChanged("jugador1");
            } }

        private void timerTick(object sender, object e)
        {
            move();
        }

        /// <summary>
        /// Evento que se da al pulsar una tecla, en este caso, A y D para mover la nave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.W)
            {
                left();
                dispatcherTimer.Start();
            }

            if (e.Key == VirtualKey.S)
            {
                right();
                dispatcherTimer.Start();
            }

        }
        /// <summary>
        /// Evento que se da al levantar una tecla, en este caso, A o D para parar la nave
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
        /// Método que se encarga de mover la nave y controlar que no se salga del canvas
        /// </summary>
        public void move()
        {
            Double posicionFutura = _jugador1.posicionY + _jugador1.velocidad;
            if (posicionFutura > 0 && posicionFutura < 1000)
            {
                _jugador1.posicionY += _jugador1.velocidad;
            }
            NotifyPropertyChanged("jugador1");
        }

        /// <summary>
        /// Método que se encarga de mover la nave a la derecha
        /// </summary>
        public void right()
        {
            //_velocidad = 10;
            if (_jugador1.posicionY < 1000)
            {
                _jugador1.velocidad = 10;
            }
            else
            {
                _jugador1.velocidad = 0;
            }
        }
        /// <summary>
        /// Método que se encarga de mover la nave a la izquierda
        /// </summary>
        public void left()
        {
            //_velocidad = -10;
            if (_jugador1.posicionY > 0 && _jugador1.posicionY - 10 > 0)
            {
                _jugador1.velocidad = -10;
            }
            else
            {
                _jugador1.velocidad = 0;
            }
        }

        /// <summary>
        /// KeyDown en botones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnPointerPressed(object sender, PointerRoutedEventArgs e)//
        {
            StackPanel stkpanel = (StackPanel)sender;
            if (stkpanel.Name.Equals("btnArriba"))//Comprobar qué boton es el que llega
            {
                left();
                dispatcherTimer.Start();
            }

            if (stkpanel.Name.Equals("btnAbajo"))
            {
                right();
                dispatcherTimer.Start();
            }
        }
        /// <summary>
        /// KeyUp en botones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnPointerExited(object sender, PointerRoutedEventArgs e)
        {
            StackPanel stkpanel = (StackPanel)sender;
            if (stkpanel.Name.Equals("btnArriba") || stkpanel.Name.Equals("btnAbajo"))//Comprobar qué boton es el que llega
            {
                dispatcherTimer.Stop();
            }
        }

        public async void getCliente() {
          //enumColision colision = await proxy.Invoke<enumColision>("getCliente");

        }
    }
}
