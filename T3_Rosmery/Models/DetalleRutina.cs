﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T3_Rosmery.Models
{
    public class DetalleRutina
    {
        public int Id { get; set; }
        public int IdRutinaUsuario { get; set; }
        public int IdEjercicios { get; set; }
        public int Tiempo { get; set; }
        public Ejercicios Ejercicios { get; set; }
    }
}
