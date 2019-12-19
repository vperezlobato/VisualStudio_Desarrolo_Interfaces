﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using PongSignalRUniversal.Entidades;

namespace PongSignalRUniversal.Model
{
    public class MainPageVM : clsVMBase
    {
        private HubConnection conn;
        private IHubProxy proxy;
        private objetoJuego _jugador1; 
        private objetoJuego _jugador2;
        private objetoJuego _pelota;

        public MainPageVM(){
            conn = new HubConnection("https://.azurewebsites.net");
            proxy = conn.CreateHubProxy("PongHub");
            conn.Start();
            _jugador1 = new objetoJuego(100, 100, "jugador1", "jugador1", false);
            _jugador2 = new objetoJuego(880, 100, "jugador1", "jugador1", false);
            _pelota = new objetoJuego(250, 500, "jugador1", "jugador1", false);
            proxy.Invoke("añadirObjetoJuego",_pelota.id);
            proxy.Invoke("añadirObjetoJuego",_jugador1.id);
            proxy.Invoke("añadirObjetoJuego",_jugador2.id);
            getCliente();
        }

        public async void getCliente() {
          enumColision colision = await proxy.Invoke<enumColision>("getCliente");

            if (colision == enumColision.jugador1) {
                proxy.state.nombreJugador = jugador1.id;
                proxy.On(_jugador1.id,nombreJugador());
            }else
                if(colision == enumColision.jugador2)
                    proxy.state.nombreJugador = jugador2.id;

        }
    }
}