using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoBeta.Models;
using Microsoft.AspNetCore.Authorization;
using ProyectoBeta.BLL;

namespace ProyectoBeta.Controllers
{
    [Authorize(ActiveAuthenticationSchemes = "CookiePolicy")]
    public class MedicinasController : Controller
    {
        private readonly Context _context;

        public MedicinasController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var medicinas = from m in _context.Medicinas
                            select m;
            var categoria = from c in _context.Categorias
                            select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                medicinas = medicinas.Where(s => s.Nombre.Contains(searchString));

            }
            return View(await medicinas.ToListAsync());
        }

        [HttpGet]
        public JsonResult LastIndex()
        {
            int id = MedicinasBLL.Identity();
            if (id > 1 || MedicinasBLL.GetLista().Count > 0)
                ++id;
            return Json(id);
        }
        //[HttpPost]
        //public string Index(string searchString, bool notUsed)
        //{
        //    return "From [HttpPost]Index: filter on " + searchString;
        //}

        //[HttpGet]
        //public IActionResult Listar()
        //{
        //    List<Medicinas> listado = MedicinasBLL.GetLista();
        //    if (listado.Count > 0)
        //        return Json(listado);
        //    return Json(null);
        //}

        //[HttpGet]
        //public IActionResult Buscar(int? medicinaId)
        //{
        //    var medicina = MedicinasBLL.Buscar(medicinaId);
        //    return Json(medicina);
        //}

        [HttpGet]
        public JsonResult Buscar(int? medicinaId)
        {
            Medicinas med = MedicinasBLL.Buscar(medicinaId);
            if (med != null)
            {
                return Json(med);
            }
            else
            {
                return Json(false);
            }
        }

        [HttpPost]
        public JsonResult Guardar(Medicinas med)
        {
            bool resultado = false;
            if (ModelState.IsValid)
            {
                resultado = MedicinasBLL.Guardar(med);
            }
            return Json(resultado);
        }

        [HttpPost]
        public JsonResult Modificar(Laboratorios lab)
        {
            var existe = (LaboratoriosBLL.Buscar(lab.LaboratorioId) != null);
            if (existe)
            {
                existe = LaboratoriosBLL.Modificar(lab);
                return Json(existe);
            }
            else
            {
                return Json(null);
            }
        }

        //[HttpPost]
        //public JsonResult Modificar(Medicinas med)
        //{
        //    bool resultado = false;
        //    if (ModelState.IsValid)
        //    {
        //        if (MedicinasBLL.Buscar(med.MedicinaId) != null)
        //            resultado = MedicinasBLL.Modificar(med);
        //    }
        //    return Json(resultado);
        //}

        //[HttpPost]
        //public JsonResult Eliminar(Medicinas med)
        //{
        //    bool resultado = false;
        //    if (ModelState.IsValid)
        //    {
        //        if (MedicinasBLL.Buscar(med.MedicinaId) != null)
        //            resultado = MedicinasBLL.Eliminar(med);
        //    }
        //    return Json(resultado);
        //}

        [HttpGet]
        public JsonResult Lista(int id)
        {
            var listado = MedicinasBLL.GetLista();
            return Json(listado);
        }

        //[HttpPost]
        //public JsonResult Guardar(Medicinas med)
        //{
        //    int id = 0;
        //    if (ModelState.IsValid)
        //    {
        //        if (MedicinasBLL.Guardar(med))
        //        {
        //            id = med.MedicinaId;
        //        }
        //    }
        //    else
        //    {
        //        id = +1;
        //    }
        //    return Json(id);
        //}

        // GET: Medicinas
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Medicinas.ToListAsync());
        //}

        // GET: Medicinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicinas = await _context.Medicinas
                .SingleOrDefaultAsync(m => m.MedicinaId == id);
            if (medicinas == null)
            {
                return NotFound();
            }

            return View(medicinas);
        }

        // GET: Medicinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicinaId,Nombre,Descripcion,PrecioVenta,PrecioCompra,FechaVencimiento,CantidadExistencia,LaboratorioId,Especificaciones,CategoriaId")] Medicinas medicinas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicinas);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(medicinas);
        }

        // GET: Medicinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicinas = await _context.Medicinas.SingleOrDefaultAsync(m => m.MedicinaId == id);
            if (medicinas == null)
            {
                return NotFound();
            }
            return View(medicinas);
        }

        // POST: Medicinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicinaId,Nombre,Descripcion,PrecioVenta,PrecioCompra,FechaVencimiento,CantidadExistencia,LaboratorioId,Especificaciones,CategoriaId")] Medicinas medicinas)
        {
            if (id != medicinas.MedicinaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicinas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicinasExists(medicinas.MedicinaId))
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
            return View(medicinas);
        }

        // GET: Medicinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicinas = await _context.Medicinas
                .SingleOrDefaultAsync(m => m.MedicinaId == id);
            if (medicinas == null)
            {
                return NotFound();
            }

            return View(medicinas);
        }

        // POST: Medicinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicinas = await _context.Medicinas.SingleOrDefaultAsync(m => m.MedicinaId == id);
            _context.Medicinas.Remove(medicinas);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MedicinasExists(int id)
        {
            return _context.Medicinas.Any(e => e.MedicinaId == id);
        }
    }
}
