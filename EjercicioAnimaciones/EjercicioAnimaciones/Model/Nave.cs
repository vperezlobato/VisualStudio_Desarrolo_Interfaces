using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioAnimaciones.Model
{
    public class Nave
    {
        public double posY { get; set; }
        public double posX { get; set; }

        public double velocidad { get; set; }

        public Nave(double posY, double posX, double velocidad)
        {
            this.posX = posX;
            this.posY = posY;
            this.velocidad = velocidad;
        }
    }
}
