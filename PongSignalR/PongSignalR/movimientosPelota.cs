using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PongSignalR
{
    public class movimientosPelota
    {
        private const double enRadianes = Math.PI / 180;

        private const int limiteIzquierda = 0;
        private const int limiteDerecha = 1000;
        private const int limiteAbajo = 0;
        private const int limiteArriba = 500;

        private ObjetoJuego _objetoJuego;
        private int _angulo;
        private float _velocidad;
        private enumColision _ultimaColision;

        public movimientosPelota(ObjetoJuego objetoJuego)
        {
            //Colocar la pelota en el centro
            objetoJuego.izquierda = 500;
            objetoJuego.top = 250;

            _objetoJuego = objetoJuego;
            _velocidad = 8f;
            _angulo = 45;
        }

        private void manejarColisionMuro()
        {
            if (_objetoJuego.izquierda <= limiteIzquierda || _objetoJuego.izquierda >= limiteDerecha)
            {
                _ultimaColision = enumColision.muro;
                manejarColisionMuroVertical();
            }

            if (_objetoJuego.top <= limiteAbajo ||  _objetoJuego.top >= limiteArriba)
            {
                _ultimaColision = enumColision.muro;
                manejarColisionMuroHorizontal();
            }
        }

        private void manejarColisionMuroVertical()
        {
            switch (_angulo)
            {
                case 45: _angulo = 135; break;
                case 135: _angulo = 45; break;
                case 225: _angulo = 315; break;
                case 315: _angulo = 225; break;
            }
        }

        private void manejarColisionMuroHorizontal()
        {
            switch (_angulo)
            {
                case 45: _angulo = 315; break;
                case 135: _angulo = 225; break;
                case 225: _angulo = 135; break;
                case 315: _angulo = 45; break;
            }
        }

        public void actualizar()
        {
            _objetoJuego.izquierda += Math.Cos(_angulo * enRadianes) * _velocidad;
            _objetoJuego.top += Math.Sin(_angulo * enRadianes) * _velocidad;

            _objetoJuego.seHaMovido = true;

            manejarColisionMuro();
        }

        public void golpeoJugador1()
        {
            if (_ultimaColision == enumColision.jugador1)
            {
                manejarColisionMuroVertical();
                _ultimaColision = enumColision.jugador1;
            }
        }

        public void golpeoJugador2()
        {
            if (_ultimaColision == enumColision.jugador2)
            {
                manejarColisionMuroVertical();
                _ultimaColision = enumColision.jugador2;
            }
        }
    }
}