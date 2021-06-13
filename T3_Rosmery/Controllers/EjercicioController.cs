using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T3_Rosmery.DB;
using T3_Rosmery.Models;
using T3_Rosmery.PatronEstrategia;

namespace T3_Rosmery.Controllers
{
    [Authorize]
    public class EjercicioController : Controller
    {
        private readonly EjercicioContext context;
        private IRutina tipoRutina;

        public EjercicioController(EjercicioContext context)
        {
            this.context = context;
        }

        public IActionResult Index(int idRutina)
        {
            ViewBag.Ejercicios = context.Ejercicios.ToList();

            var rutina = context.DetalleRutinas.
                Where(o => o.IdRutinaUsuario == idRutina).
                Include(o => o.Ejercicios).
                ToList();

            return View(rutina);
        }

        [HttpGet]
        public ActionResult Rutinas()
        {
            var rutinaUsuario = context.RutinaUsuarios.
                Where(o => o.IdUsuario == LoggedUser().Id).
                ToList();
            return View(rutinaUsuario);
        }

        [HttpGet]
        public ActionResult CrearRutina()
        {
            ViewBag.Tipo = new List<string> { "Principiante", "Intermedio", "Avanzado" };
            return View(new RutinaUsuario());
        }
        [HttpPost]
        public ActionResult CrearRutina(RutinaUsuario rutina)
        {
            rutina.IdUsuario = LoggedUser().Id;
            if (ModelState.IsValid)
            {
                context.RutinaUsuarios.Add(rutina);
                context.SaveChanges();

                int idRutina = rutina.Id;
                if (idRutina != 0)
                {
                    var ejercicios = context.Ejercicios.ToList();
                    int ejercicio = ejercicios.Count();
                    switch (rutina.Tipo)
                    {
                        case "Principiante":
                            tipoRutina = new Principiante();
                            break;
                        case "Intermedio":
                            tipoRutina = new Intermedio();
                            break;
                        case "Avanzado":
                            tipoRutina = new Avanzado();
                            break;
                    }

                    var aplicar = tipoRutina.Rutina(idRutina, ejercicio);

                    context.DetalleRutinas.AddRange(aplicar);
                    context.SaveChanges();
                }
                return RedirectToAction("Rutinas");
            }
            else
            {
                ViewBag.Tipo = new List<string> { "Intermedio", "Principiante", "Avanzado" };
                return View(new RutinaUsuario());
            }
        }

        protected Usuario LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = context.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
            return user;
        }
    }
}
