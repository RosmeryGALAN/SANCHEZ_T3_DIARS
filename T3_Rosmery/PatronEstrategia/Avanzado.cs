using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T3_Rosmery.Models;

namespace T3_Rosmery.PatronEstrategia
{
    public class Avanzado : IRutina
    {
        public List<DetalleRutina> Rutina(int idRutina, int ejercicios)
        {
            Random random = new Random();
            List<DetalleRutina> detalles = new List<DetalleRutina>();
            for (int i = 0; i < 15; i++)
            {
                var detalle = new DetalleRutina();
                var ejercicio = random.Next(1, ejercicios);

                detalle.IdEjercicios = ejercicio;
                detalle.IdRutinaUsuario = idRutina;
                detalle.Tiempo = 120;

                detalles.Add(detalle);
            }
            return detalles;
        }
    }
}
