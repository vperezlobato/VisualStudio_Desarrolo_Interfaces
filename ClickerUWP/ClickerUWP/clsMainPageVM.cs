using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace ClickerUWP
{
    class clsMainPageVM : INotifyPropertyChanged
    {
        private HubConnection conn;
        private IHubProxy proxy;
        public Comando enviar { get; set; }
        private int idJugador;
        private int clicksMios;
        private int otrosClicks;

        

        public int ClicksMios
        {
            get { return clicksMios; }
            set
            {
                clicksMios = value;
            }
        }

        public int OtrosClicks
        {
            get { return otrosClicks; }
            set
            {
                otrosClicks = value;
            }
        }

        public clsMainPageVM()
        {
            SignalR();

            idJugador = 100;

            clicksMios = 0;
            otrosClicks = 0;

            enviar = new Comando(Broadcast);
        }

        private void SignalR()
        {
            //conn = new HubConnection("http://< Jump ;your-mobile-app>.azurewebsites.net");
            //conn = new HubConnection("https://signalr-servidorclicks.azurewebsites.net");
            conn = new HubConnection("https://signalrchativan.azurewebsites.net");
            //conn = new HubConnection("https://signalr-servidorclicks.azurewebsites.net");
            //conn = new HubConnection("https://chatserver-avazquez.azurewebsites.net");
            //conn = new HubConnection("https://chatservermapache.azurewebsites.net");

            proxy = conn.CreateHubProxy("ChatHub");
            conn.Start();

            proxy.On<int>("click", click);
        }

        public void Broadcast()
        {
            proxy.Invoke("click", idJugador);
        }

        private async void click(int playerid)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                //Messages.Add(new DosStringToMensaje(nombre, mensaje));
                //this.mensaje.mensaje = "";
                if (playerid == this.idJugador)
                {
                    clicksMios++;
                    NotifyPropertyChanged("ClicksMios");
                }
                else
                {
                    otrosClicks++;
                    NotifyPropertyChanged("OtrosClicks");
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
