using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PongSignalR
{
    public class PongHub : Hub
    {
        private controlJuego _controlJuego;

        public PongHub() : this(controlJuego.Instance)
        {
        }

        public PongHub(controlJuego gameController)
        {
            _controlJuego = gameController;
        }

        public void añadirObjetoJuego(string id)
        {
            _controlJuego.añadirObjetoJuego(id);
        }

        public void actualizarPosicionObjeto(objetoJuego objetoJuegoCliente)
        {
            objetoJuegoCliente.ultimoActualizado = Context.ConnectionId;

            _controlJuego.actualizarPosicionObjeto(objetoJuegoCliente);
        }

        public enumColision getCliente()
        {
            enumColision tipoCliente = enumColision.defaultt;

            if (_controlJuego.jugador1ConnectionId == Context.ConnectionId)
            {
                tipoCliente = enumColision.jugador1;
            }

            if (_controlJuego.jugador2ConnectionId == Context.ConnectionId)
            {
                tipoCliente = enumColision.jugador2;
            }
            return tipoCliente;
        }

        public void golpeoJugador1()
        {
            _controlJuego.golpeoJugador1();
        }

        public void golpeoJugador2()
        {
            _controlJuego.golpeoJugador2();
        }

        public override Task OnConnected()
        {
            if (_controlJuego.jugador1ConnectionId == null)
            {
                _controlJuego.jugador1ConnectionId = Context.ConnectionId;
            }
            else if (_controlJuego.jugador2ConnectionId == null)
            {
                _controlJuego.jugador2ConnectionId = Context.ConnectionId;
            }

            _controlJuego.actualizarPosicionObjetoParaCliente(Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool pararLlamado)
        {

            if (_controlJuego.jugador1ConnectionId == Context.ConnectionId)
            {
                _controlJuego.jugador1ConnectionId = null;
            }
            else if (_controlJuego.jugador2ConnectionId == Context.ConnectionId)
            {
                _controlJuego.jugador2ConnectionId = null;
            }

            return base.OnDisconnected(pararLlamado);
        }
    }
}