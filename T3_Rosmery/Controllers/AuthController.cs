using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using T3_Rosmery.DB;
using T3_Rosmery.Models;

namespace T3_Rosmery.Controllers
{
    public class AuthController : Controller
    {
        private readonly EjercicioContext context;

        public AuthController(EjercicioContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = context.Usuarios
                .Where(o => o.Username == username && o.Password == password)
                .FirstOrDefault();
            if (user != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("Login", "Usuario o contraseña incorrectos.");
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return View("Login");
        }
        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(Usuario user, string passwordConf)
        {
            if (user.Password != passwordConf)
                ModelState.AddModelError("PasswordConf", "Las contraseñas no coinciden");

            if (ModelState.IsValid)
            {
                context.Usuarios.Add(user);
                context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View("Registrar", user);
        }
    }
}
