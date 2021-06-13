using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T3_Rosmery.Models;

namespace T3_Rosmery.PatronEstrategia
{
    interface IRutina
    {
        public List<DetalleRutina> Rutina(int idRutina, int ejercicios);
    }
}
