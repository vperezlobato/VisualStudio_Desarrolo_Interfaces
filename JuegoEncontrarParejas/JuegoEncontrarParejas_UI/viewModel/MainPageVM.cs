using JuegoEncontrarParejas_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEncontrarParejas_UI.viewModel
{
    class MainPageVM : clsVMBase
    {
        #region"Propiedades privadas"
        private Card cartaSeleccionada;
        private Card cartaPrevia;
        private ObservableCollection<Card> tablero;
        private bool isPrimeraCarta;

        #endregion

        #region"Propiedades publicas"
        /// <summary>
        /// 
        /// </summary>
        public Card CartaSeleccionada
        {
            get { 
                return this.cartaSeleccionada; 
            }
            set { 
                this.cartaSeleccionada = value; 

                if(!this.cartaSeleccionada.isEncontrada && this.cartaSeleccionada != null)  //solo entra si no es null y NO esta encontrada
                {
                    //girarSeleccionada();

                    this.cartaSeleccionada.girarCarta();
                    NotifyPropertyChanged("CartaSeleccionada");

                    isPrimeraCarta = !isPrimeraCarta;
                    


                    if (isPrimeraCarta)
                    {
                        cartaPrevia = cartaSeleccionada;
                        NotifyPropertyChanged("CartaSeleccionada");
                        cartaSeleccionada = null;
                    }else if(isAMatch(cartaSeleccionada, cartaPrevia))
                    {
                        cartaSeleccionada.isEncontrada = true;
                        
                        cartaPrevia.isEncontrada = true;
                        
                        NotifyPropertyChanged("CartaSeleccionada");

                    }
                    else if(!isPrimeraCarta && !isAMatch(cartaSeleccionada, cartaPrevia))
                    {
                        if(cartaSeleccionada != null && cartaPrevia != null)
                        {
                            girarPrevia();
                            girarSeleccionada();
                        }
                        
                        

                    }
                    else
                    {
                        if(cartaSeleccionada != null)
                        girarSeleccionada();
                       
                    }

                    
                    

                }
            }
        }

        public ObservableCollection<Card> Tablero
        {
            get { return this.tablero; }
            set { this.tablero = value; }
        }
        #endregion

        #region"Constructor"
        public MainPageVM()
        {
            isPrimeraCarta = false;
            this.cartaSeleccionada = null;
            this.cartaPrevia = null;
            List<Card> baraja = new List<Card>();
            //Añado las cartas a la baraja
            baraja.Add(new Card(1,1, "ms-appx:///Assets/androidstudio.png"));
            baraja.Add(new Card(2,1, "ms-appx:///Assets/androidstudio.png"));

            baraja.Add(new Card(3,2, "ms-appx:///Assets/angelagit.png"));
            baraja.Add(new Card(4,2, "ms-appx:///Assets/angelagit.png"));

            baraja.Add(new Card(5,3, "ms-appx:///Assets/geany.png"));
            baraja.Add(new Card(6,3, "ms-appx:///Assets/geany.png"));

            baraja.Add(new Card(7,4, "ms-appx:///Assets/github.png"));
            baraja.Add(new Card(8,4, "ms-appx:///Assets/github.png"));

            baraja.Add(new Card(9,5, "ms-appx:///Assets/intellij.png"));
            baraja.Add(new Card(10,5, "ms-appx:///Assets/intellij.png"));

            baraja.Add(new Card(11,6, "ms-appx:///Assets/sqlserver.png"));
            baraja.Add(new Card(12,6, "ms-appx:///Assets/sqlserver.png"));

            baraja.Add(new Card(13,7, "ms-appx:///Assets/vagrant.png"));
            baraja.Add(new Card(14,7, "ms-appx:///Assets/vagrant.png"));

            baraja.Add(new Card(15,8, "ms-appx:///Assets/visualstudio.png"));
            baraja.Add(new Card(16,8, "ms-appx:///Assets/visualstudio.png"));

            //barajar cartas
            this.tablero = new ObservableCollection<Card>(this.ShuffleList(baraja));    

        }
        #endregion

        #region"Metodos añadidos"

        private List<Card> ShuffleList(List<Card> inputList)
        {
            List<Card> randomList = new List<Card>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }

        private bool isAMatch(Card carta, Card cartaPrevia)
        {
            bool pareja = false;
            if(carta.pareja == cartaPrevia.pareja && carta.id != cartaPrevia.id)
            {
                pareja = true;
            }
                return pareja;
        }


        private async void girarSeleccionada()
        {
            Task task = Task.Delay(200);
            await task.AsAsyncAction();
           
           cartaSeleccionada.girarCarta();
            
            
            
            //NotifyPropertyChanged("CartaSeleccionada");
            cartaSeleccionada = null;
            NotifyPropertyChanged("CartaSeleccionada");


        }

        private async void girarPrevia()
        {
            Task task = Task.Delay(200);
            await task.AsAsyncAction();
            cartaPrevia.girarCarta();
           

        }


        #endregion
    }
}
