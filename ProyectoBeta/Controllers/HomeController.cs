using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoBeta.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ProyectoBeta.Controllers
{
    public class HomeController : Controller
    {
        private Context _db;

        public HomeController(Context db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Usuarios.ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        //public ActionResult Registro()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Registro(Usuarios usuarios)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Usuarios.Add(usuarios);
        //        _db.SaveChanges();

        //        ModelState.Clear();
        //        ViewBag.Message = usuarios.Nombre + " " + usuarios.Apellido + "Su registro se a completado";
        //    }

        //    return View();
        //}

        //public ActionResult LogIn()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult LogIn(Usuarios usuarios)
        //{
        //    var Cuenta = _db.Usuarios.Where(u => u.NombreUsuario == usuarios.NombreUsuario && u.Clave == usuarios.Clave).FirstOrDefault();

        //    if (Cuenta != null)
        //    {
        //        HttpContext.Session.SetString("UsuarioId", Cuenta.UsuarioId.ToString());
        //        HttpContext.Session.SetString("NombreUsuario", Cuenta.NombreUsuario);

        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, Cuenta.NombreUsuario)
        //        };

        //        var Identidad = new ClaimsIdentity(claims, "login");

        //        ClaimsPrincipal principal = new ClaimsPrincipal(Identidad);
        //        HttpContext.Authentication.SignInAsync("CookiePolicy", principal);
        //        return RedirectToAction("Index");


        //    }

        //    else
        //    {
        //        ModelState.AddModelError("", "El nombre de usuario o la contrasena esta mal escrita");
        //    }

        //    return View();
        //}
        
        //public ActionResult Welcome()
        //{
        //    if(HttpContext.Session.GetString("UsuarioId") != null)
        //    {
        //        ViewBag.NombreUsuario = HttpContext.Session.GetString("NombreUsuario");
        //        return View();
        //    }

        //    else
        //    {
        //        return RedirectToAction("LogIn");
        //    }
        //}

        //public ActionResult LogOut()
        //{
        //    HttpContext.Authentication.SignOutAsync("CookiePolicy");
        //    HttpContext.Session.Clear();

        //    return RedirectToAction("Index");
        //}

    }
}

