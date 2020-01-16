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
            // Guardar el contexto de nuestro hub para poder usarlo facilmente para enviar la informacion a los clientes conectados
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<PongHub>();
        }

        public void Broadcast(IEnumerable<objetoJuego> objetosJuegoMovidos)
        {
            // Avisa al cliente de la nueva posicion de los objetos
            foreach (var objetoJuego in objetosJuegoMovidos)
            {

                _hubContext.Clients.AllExcept(objetoJuego.ultimoActualizado).updateGameObjectPosition(objetoJuego);

                objetoJuego.seHaMovido = false;
            }
        }

        public void Broadcast(IEnumerable<objetoJuego> objetosJuego, string connectionId)
        {
            //Avisa solo el cliente de connectionId

            foreach (var objetoJuego in objetosJuego)
                _hubContext.Clients.Client(connectionId).actualizarPosicionObjeto(objetoJuego);
        }
    }
}
