using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoBeta.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProyectoBeta.Controllers
{
    [Authorize(ActiveAuthenticationSchemes = "CookiePolicy")]
    public class LaboratoriosController : Controller
    {
        private readonly Context _context;

        public LaboratoriosController(Context context)
        {
            _context = context;    
        }

        [HttpGet]
        public JsonResult Lista(int id)
        {
            var listado = LaboratoriosBLL.GetLista();

            return Json(listado);
        }

        [HttpGet]
        public JsonResult LastIndex()
        {
            int id = LaboratoriosBLL.Identity();
            if (id > 1 || LaboratoriosBLL.GetLista().Count > 0)
                ++id;
            return Json(id);
        }

        [HttpGet]
        public ActionResult BuscarFecha(DateTime Desde, DateTime Hasta)
        {
            return Json(LaboratoriosBLL.GetListaFecha(Desde, Hasta));
        }

        [HttpGet]
        public JsonResult Buscar(int id)
        {
            Laboratorios lab = LaboratoriosBLL.Buscar(id);
            if (lab != null)
            {
                return Json(lab);
            }
            else
            {
                return Json(false);
            }
        }

        // GET: Laboratorios
        public async Task<IActionResult> Index(string searchString)
        {
            var laboratorios = from l in _context.Laboratorios
                            select l;
            if (!String.IsNullOrEmpty(searchString))
            {
                laboratorios = laboratorios.Where(s => s.Nombre.Contains(searchString));
            }
            return View(await laboratorios.ToListAsync());
        }

        [HttpPost]
        public JsonResult Guardar(Laboratorios lab)
        {
            bool resultado = false;
            if (ModelState.IsValid)
            {
                try
                {
                    DateTime now = DateTime.Now;
                    int y, m, d, h, min, s;
                    y = lab.FechaIngreso.Year;
                    m = lab.FechaIngreso.Month;
                    d = lab.FechaIngreso.Day;
                    h = now.Hour;
                    min = now.Minute;
                    s = now.Second;
                    lab.FechaIngreso = new DateTime(y, m, d, h, min, s);
                    resultado = LaboratoriosBLL.Guardar(lab);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Json(resultado);
        }

        [HttpPost]
        public IActionResult Eliminar(Laboratorios lab)
        {
            bool resultado = false;
            if (ModelState.IsValid)
            {
                if (LaboratoriosBLL.Buscar(lab.LaboratorioId) != null)
                    resultado = LaboratoriosBLL.Eliminar(lab);
            }
            return Json(resultado);
        }

        [HttpPost]
        public IActionResult Modificar(Laboratorios lab)
        {
            bool resultado = false;
            if (ModelState.IsValid)
            {
                if (LaboratoriosBLL.Buscar(lab.LaboratorioId) != null)
                    resultado = LaboratoriosBLL.Modificar(lab);
            }
            return Json(resultado);
        }

        // GET: Laboratorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratorios = await _context.Laboratorios
                .SingleOrDefaultAsync(m => m.LaboratorioId == id);
            if (laboratorios == null)
            {
                return NotFound();
            }

            return View(laboratorios);
        }

        // GET: Laboratorios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Laboratorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LaboratorioId,Nombre,FechaIngreso")] Laboratorios laboratorios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laboratorios);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(laboratorios);
        }

        // GET: Laboratorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratorios = await _context.Laboratorios.SingleOrDefaultAsync(m => m.LaboratorioId == id);
            if (laboratorios == null)
            {
                return NotFound();
            }
            return View(laboratorios);
        }

        // POST: Laboratorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LaboratorioId,Nombre,FechaIngreso")] Laboratorios laboratorios)
        {
            if (id != laboratorios.LaboratorioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laboratorios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaboratoriosExists(laboratorios.LaboratorioId))
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
            return View(laboratorios);
        }

        // GET: Laboratorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratorios = await _context.Laboratorios
                .SingleOrDefaultAsync(m => m.LaboratorioId == id);
            if (laboratorios == null)
            {
                return NotFound();
            }

            return View(laboratorios);
        }

        // POST: Laboratorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laboratorios = await _context.Laboratorios.SingleOrDefaultAsync(m => m.LaboratorioId == id);
            _context.Laboratorios.Remove(laboratorios);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LaboratoriosExists(int id)
        {
            return _context.Laboratorios.Any(e => e.LaboratorioId == id);
        }
    }
}
