using EjercicioAnimaciones.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace EjercicioAnimaciones.ViewModel
{
    public class MainPageVM : clsVMBase
    {
        private Nave _nave;
        private DispatcherTimer dispatcherTimer { get; set; }
        private bool moviendoY { get; set; }
        private bool moviendoX { get; set; }


        public MainPageVM()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Tick += timerTick;
            moviendoX = false;
            moviendoY = false;
            _nave = new Nave(500,500,0);

        }

        public Nave nave
        {
            get { return _nave; }
            set
            {
                _nave = value;
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
            if (e.Key == VirtualKey.Up)
            {
                arriba();
                dispatcherTimer.Start();
                moviendoY = true;
                moviendoX = false;
            }

            if (e.Key == VirtualKey.Down)
            {
                abajo();
                dispatcherTimer.Start();
                moviendoY = true;
                moviendoX = false;
            }

            if (e.Key == VirtualKey.Right)
            {
                derecha();
                dispatcherTimer.Start();
                moviendoX = true;
                moviendoY = false;
            }

            if (e.Key == VirtualKey.Left)
            {
                izquierda();
                dispatcherTimer.Start();
                moviendoX = true;
                moviendoY = false;
            }

        }
        /// <summary>
        /// Evento que se da al levantar una tecla, en este caso, W o S para parar el movimiento de la barra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Grid_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Up || e.Key == VirtualKey.Down || e.Key == VirtualKey.Left || e.Key == VirtualKey.Right)
            {
                dispatcherTimer.Stop();
                moviendoY = false;
                moviendoX = false;
            }
        }
        /// <summary>
        /// Método que se encarga de mover la barra y controlar que no se salga del canvas
        /// </summary>
        public void move()
        {
            Double posicionFutura;
            if (moviendoY) { 
                posicionFutura = _nave.posY + _nave.velocidad;
                if (posicionFutura > 0 && posicionFutura < 500)
                {
                    _nave.posY += _nave.velocidad;
                } 
            }

            if (moviendoX)
            {
                posicionFutura = _nave.posX + _nave.velocidad;
                if (posicionFutura > 0 && posicionFutura < 1180)
                {
                    _nave.posX += _nave.velocidad;
                }
            }

            NotifyPropertyChanged("nave");

        }

        /// <summary>
        /// Método que se encarga de mover la barra hacia abajo
        /// </summary>
        public void abajo()
        {
            //_velocidad = 10;
 
            if (_nave.posY < 500)
            {
                _nave.velocidad = 10;
            }
            else
            {
                _nave.velocidad = 0;
            }
            
        }
        /// <summary>
        /// Método que se encarga de mover la barra hacia arriba
        /// </summary>
        public void arriba()
        {
            //_velocidad = -10;

            if (_nave.posY > 0 && _nave.posY - 10 > 0)
            {
                _nave.velocidad = -10;
            }
            else
            {
                _nave.velocidad = 0;
            }
            
        }

        public void derecha()
        {
            //_velocidad = 10;

            if (_nave.posX < 1180)
            {
                _nave.velocidad = 10;
            }
            else
            {
                _nave.velocidad = 0;
            }

        }
        /// <summary>
        /// Método que se encarga de mover la barra hacia arriba
        /// </summary>
        public void izquierda()
        {
            //_velocidad = -10;

            if (_nave.posX > 0 && _nave.posX - 10 > 0)
            {
                _nave.velocidad = -10;
            }
            else
            {
                _nave.velocidad = 0;
            }

        }

    }
}
