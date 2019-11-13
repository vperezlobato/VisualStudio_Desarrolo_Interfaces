using _08_Binding_Parte4_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Binding_Parte4_UI.Models
{
    class listadoPersonas
    {

        public List<clsPersona> listado() {
            List<clsPersona> lista = new List<clsPersona>();
            lista.Add(new clsPersona("Victor","Manuel","IES Nervion",new DateTime(1997-8-5),"111111111"));
            lista.Add(new clsPersona("Rafa", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "222222222"));
            lista.Add(new clsPersona("Pablo", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "333333333"));
            lista.Add(new clsPersona("Yeray", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "444444444"));
            lista.Add(new clsPersona("Nzhdeh", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "555555555"));
            lista.Add(new clsPersona("Dani", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "666666666"));
            lista.Add(new clsPersona("Miguel", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "777777777"));
            lista.Add(new clsPersona("Ivan", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "888888888"));
            lista.Add(new clsPersona("Diana", "Manuel", "IES Nervion", new DateTime(1997 - 8 - 5), "999999999"));

            return lista; 
        }
    }
}
