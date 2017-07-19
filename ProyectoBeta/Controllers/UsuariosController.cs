using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoBeta.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ProyectoBeta.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Context _db;

        public UsuariosController(Context db)
        {
            _db = db;    
        }

        // GET: Usuarios
        public async Task<IActionResult> Index(string searchString)
        {

            var usuarios = from u in _db.Usuarios
                            select u;


            if (!String.IsNullOrEmpty(searchString))
            {
                usuarios = usuarios.Where(s => s.NombreUsuario.Contains(searchString));

            }
            return View(await _db.Usuarios.ToListAsync());

        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _db.Usuarios
                .SingleOrDefaultAsync(m => m.UsuarioId == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                _db.Usuarios.Add(usuarios);
                _db.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = usuarios.Nombre + " " + usuarios.Apellido + "Su registro se a completado";
            }

            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Usuarios usuarios)
        {
            var Cuenta = _db.Usuarios.Where(u => u.NombreUsuario == usuarios.NombreUsuario && u.Clave == usuarios.Clave).FirstOrDefault();

            if (Cuenta != null)
            {
                HttpContext.Session.SetString("UsuarioId", Cuenta.UsuarioId.ToString());
                HttpContext.Session.SetString("NombreUsuario", Cuenta.NombreUsuario);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Cuenta.NombreUsuario)
                };

                var Identidad = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(Identidad);
                HttpContext.Authentication.SignInAsync("CookiePolicy", principal);
                return RedirectToAction("Index", "Home");


            }

            else
            {
                ModelState.AddModelError("", "El nombre de usuario o la contrasena esta mal escrita");
            }

            return View();
        }

        public ActionResult Bienvenido()
        {
            if (HttpContext.Session.GetString("UsuarioId") != null)
            {
                ViewBag.NombreUsuario = HttpContext.Session.GetString("NombreUsuario");
                return View();
            }

            else
            {
                return RedirectToAction("Home");
            }
        }

        public ActionResult LogOut()
        {
            HttpContext.Authentication.SignOutAsync("CookiePolicy");
            HttpContext.Session.Clear();

            return RedirectToAction("Index" , "Home");
        }


    // POST: Usuarios/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("UsuarioId,Nombre,Apellido,Email,NombreUsuario,Clave,ConfirmarClave")] Usuarios usuarios)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _context.Add(usuarios);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction("Index");
    //        }
    //        return View(usuarios);
    //    }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _db.Usuarios.SingleOrDefaultAsync(m => m.UsuarioId == id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,Nombre,Apellido,Email,NombreUsuario,Clave,ConfirmarClave")] Usuarios usuarios)
        {
            if (id != usuarios.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(usuarios);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuarios.UsuarioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _db.Usuarios
                .SingleOrDefaultAsync(m => m.UsuarioId == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarios = await _db.Usuarios.SingleOrDefaultAsync(m => m.UsuarioId == id);
            _db.Usuarios.Remove(usuarios);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UsuariosExists(int id)
        {
            return _db.Usuarios.Any(e => e.UsuarioId == id);
        }
    }
}
