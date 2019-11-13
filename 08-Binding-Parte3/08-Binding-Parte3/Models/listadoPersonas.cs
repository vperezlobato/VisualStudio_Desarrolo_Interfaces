using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Binding_Parte3.Models
{
    class listadoPersonas
    {

        public List<clsPersona> listado() {
            List<clsPersona> lista = new List<clsPersona>();
            lista.Add(new clsPersona("Victor","Manuel","IES Nervion",new DateTime(1997-8-5),"111111111"));
            lista.Add(new clsPersona("Rafa", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "222222222"));
            lista.Add(new clsPersona("Pablo", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "333333333"));
            lista.Add(new clsPersona("Yeray", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "444444444"));

            return lista; 
        }
    }
}
