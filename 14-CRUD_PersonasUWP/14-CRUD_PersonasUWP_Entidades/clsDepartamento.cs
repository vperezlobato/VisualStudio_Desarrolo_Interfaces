﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _14_CRUD_PersonasUWP_Entidades
{
    public class clsDepartamento
    {
        public String nombre { get; set; }
        public int id { get; set; }

        public clsDepartamento(String nombre, int id) {
            this.nombre = nombre;
            this.id = id;
        }

        public clsDepartamento() { }
    }
}