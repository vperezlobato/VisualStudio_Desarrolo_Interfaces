using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Commands.Models
{
    class listadoPersonas
    {

        public ObservableCollection<clsPersona> listado() {
            ObservableCollection<clsPersona> lista = new ObservableCollection<clsPersona>();
            lista.Add(new clsPersona("Victor","Manuel","IES Nervion",new DateTime(1997-8-5),"111111111",1));
            lista.Add(new clsPersona("Rafa", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "222222222",2));
            lista.Add(new clsPersona("Pablo", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "333333333",3));
            lista.Add(new clsPersona("Yeray", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "444444444",4));
            lista.Add(new clsPersona("Nzhdeh", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "555555555",5));
            lista.Add(new clsPersona("Dani", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "666666666",6));
            lista.Add(new clsPersona("Miguel", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "777777777",7));
            lista.Add(new clsPersona("Ivan", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "888888888",8));
            lista.Add(new clsPersona("Diana", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "999999999",9));

            return lista; 
        }

        public ObservableCollection<clsPersona> filtrar(ObservableCollection<clsPersona> listado,String texto)
        {
            ObservableCollection<clsPersona> listadoPersonasFiltradas = new ObservableCollection<clsPersona>(listado.ToList().FindAll(persona => String.Concat(persona.nombre," ",persona.apellidos).Contains(texto)));

            return listadoPersonasFiltradas;
        }
    }
}
