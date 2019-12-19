using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PongSignalR
{
    public class Broadcaster
    {

        private readonly static Lazy<Broadcaster> _instance = new Lazy<Broadcaster>(() => new Broadcaster());

        private readonly IHubContext _hubContext;

        public Broadcaster()
        {
            // Save our hub context so we can easily use it 
            // to send to its connected clients
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<PongHub>();
        }

        public void Broadcast(IEnumerable<ObjetoJuego> objetosJuegoMovidos)
        {
            // Tell the clients the new position of moved objects
            foreach (var objetoJuego in objetosJuegoMovidos)
            {
                // This is how we can access the Clients property 
                // in a static hub method or outside of the hub entirely. Use AllExcept for a performance tweak
                _hubContext.Clients.AllExcept(objetoJuego.ultimoActualizado).updateGameObjectPosition(objetoJuego);

                objetoJuego.seHaMovido = false;
            }
        }

        public void Broadcast(IEnumerable<ObjetoJuego> objetosJuego, string connectionId)
        {
            // Signal only the client with connectionId

            foreach (var objetoJuego in objetosJuego)
                _hubContext.Clients.Client(connectionId).actualizarPosicionObjeto(objetoJuego);
        }
    }
}
