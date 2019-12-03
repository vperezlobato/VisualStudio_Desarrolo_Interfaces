using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEncontrarParejas_Entities
{
    public class Card : INotifyPropertyChanged
    {
        public int id { get; set; }
        private bool isLevantada;
        public bool isEncontrada { get; set; }
        public int pareja { get; set; }
        private string imagen;

        public string Imagen {
            get
            {
                if (isLevantada)
                {
                    return this.imagen;
                }
                else
                {
                    //Hago doble return para ahorrarme otra variable donde almacenar la ruta de la imagen negra
                    return "ms-appx:///Assets/flippedcard.png";
                }
                
            }
            set { this.imagen = value; }
        }


        public bool IsLevantada
        {
            get { 
                
                return this.isLevantada; }

            set { this.isLevantada = value; }
        }



        public Card()
        {
            this.isLevantada = false;
            this.isEncontrada = false;
            this.pareja = 0;
            this.imagen = "";
        }

        public Card(int id,int pareja, string imagen)
        {
            this.id = id;
            this.isLevantada = false;
            this.isEncontrada = false;
            this.pareja = pareja;
            this.imagen = imagen;
        }

        //Constructor de copia
        public Card(Card card)
        {
            this.id = card.id;
            this.isLevantada = card.isLevantada;
            this.isEncontrada = card.isEncontrada;
            this.pareja = card.pareja;
            this.imagen = card.imagen;
        }

        /// <summary>
        /// Gira la carta actual, esté como esté.
        /// Si está levantada, la pone boca abajo, y si estaba boca abajo, la levanta.
        /// </summary>
        public void girarCarta()
        {
        
            this.isLevantada = !this.isLevantada;
      
            OnPropertyChanged("IsLevantada");//si no no notifica
            
            OnPropertyChanged("Imagen");
           

        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }


       

    }
}
