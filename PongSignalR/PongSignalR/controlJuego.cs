using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace PongSignalR
{
    public class controlJuego
    {
        private readonly static Lazy<controlJuego> _instance = new Lazy<controlJuego>(() => new controlJuego());
        private readonly TimeSpan BroadcastInterval;

        private movimientosPelota _movimientoPelota;
        private Broadcaster _broadcaster;
        private List<ObjetoJuego> _objetosJuego;
        private Timer _broadcastLoop;

        public string jugador1ConnectionId { get; set; }
        public string jugador2ConnectionId { get; set; }

        public static controlJuego Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private controlJuego()
        {
            BroadcastInterval = TimeSpan.FromMilliseconds(40);

            _objetosJuego = new List<ObjetoJuego>();
            _broadcaster = new Broadcaster();
        }

        public void añadirObjetoJuego(string id)
        {
            if (!_objetosJuego.Any(g => g.id == id))
            {
                var objetoJuego = new ObjetoJuego { id = id };
                _objetosJuego.Add(objetoJuego);

                if (id == "pelota")
                    _movimientoPelota = new movimientosPelota(objetoJuego);


                if (_objetosJuego.Count == 3)
                {
                    //Ya tenemos los dos jugadores y la pelota, ahora iniciamos el ciclo de transmisión y actuliza todos los objetos que se movieron
                    _broadcastLoop = new Timer( actualizar,null,BroadcastInterval,BroadcastInterval);
                }
            }
        }

        public void golpeoJugador1()
        {
            _movimientoPelota.golpeoJugador1();
        }

        public void golpeoJugador2()
        {
            _movimientoPelota.golpeoJugador2();
        }

        public void actualizarPosicionObjeto(ObjetoJuego modeloCliente)
        {
            var objetoJuego = _objetosJuego.FirstOrDefault(g => g.id == modeloCliente.id);

            if (objetoJuego != null)
            {
                objetoJuego.izquierda = modeloCliente.izquierda;
                objetoJuego.top = modeloCliente.top;
                objetoJuego.ultimoActualizado = modeloCliente.ultimoActualizado;
                objetoJuego.seHaMovido = true;
            }
        }

        public void actualizarPosicionObjetoParaCliente(string connectionId)
        {
            _broadcaster.Broadcast(_objetosJuego.Where(g => g.ultimoActualizado != null), connectionId);
        }

        private void actualizar(object State)
        {
            _movimientoPelota.actualizar();

            _broadcaster.Broadcast(_objetosJuego.Where(g => g.seHaMovido));
        }
    }
}