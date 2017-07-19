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
    public class VentasDetallesController : Controller
    {

        private readonly Context _context;

        public VentasDetallesController(Context context)
        {
            _context = context;    
        }

        [HttpPost]
        public JsonResult Save([FromBody]List<VentasDetalle> detalles)
        {
            bool resultado = VentasDetallesBLL.Insertar(detalles);
            return Json(resultado);
        }

        // GET: VentasDetalles
        public async Task<IActionResult> Index()
        {
            return View(await _context.VentasDetalle.ToListAsync());
        }

        // GET: VentasDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasDetalle = await _context.VentasDetalle
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ventasDetalle == null)
            {
                return NotFound();
            }

            return View(ventasDetalle);
        }

        // GET: VentasDetalles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VentasDetalles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VentaId,MedicinaId,Precio,Cantidad")] VentasDetalle ventasDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventasDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ventasDetalle);
        }

        // GET: VentasDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasDetalle = await _context.VentasDetalle.SingleOrDefaultAsync(m => m.Id == id);
            if (ventasDetalle == null)
            {
                return NotFound();
            }
            return View(ventasDetalle);
        }

        // POST: VentasDetalles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VentaId,MedicinaId,Precio,Cantidad")] VentasDetalle ventasDetalle)
        {
            if (id != ventasDetalle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventasDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasDetalleExists(ventasDetalle.Id))
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
            return View(ventasDetalle);
        }

        // GET: VentasDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasDetalle = await _context.VentasDetalle
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ventasDetalle == null)
            {
                return NotFound();
            }

            return View(ventasDetalle);
        }

        // POST: VentasDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventasDetalle = await _context.VentasDetalle.SingleOrDefaultAsync(m => m.Id == id);
            _context.VentasDetalle.Remove(ventasDetalle);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VentasDetalleExists(int id)
        {
            return _context.VentasDetalle.Any(e => e.Id == id);
        }
    }
}
