using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoBeta.Models;

namespace ProyectoBeta.Controllers
{
    public class VentasDetallesController : Controller
    {
        private readonly Context _context;

        public VentasDetallesController(Context context)
        {
            _context = context;    
        }

        // GET: VentasDetalles
        public IActionResult Index()
        {
            return View(VentasDetallesBLL.Listar());
        }

        // GET: VentasDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasDetalle = await _context.VentasDetalle
                .SingleOrDefaultAsync(m => m.DetalleId == id);
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
        public async Task<IActionResult> Create([Bind("DetalleId,VentaId,MedicinaId,Medicina,Cantidad,Precio,Monto,Descuento")] VentasDetalle ventasDetalle)
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

            var ventasDetalle = await _context.VentasDetalle.SingleOrDefaultAsync(m => m.DetalleId == id);
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
        public async Task<IActionResult> Edit(int id, [Bind("DetalleId,VentaId,MedicinaId,Medicina,Cantidad,Precio,Monto,Descuento")] VentasDetalle ventasDetalle)
        {
            if (id != ventasDetalle.DetalleId)
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
                    if (!VentasDetalleExists(ventasDetalle.DetalleId))
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
                .SingleOrDefaultAsync(m => m.DetalleId == id);
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
            var ventasDetalle = await _context.VentasDetalle.SingleOrDefaultAsync(m => m.DetalleId == id);
            _context.VentasDetalle.Remove(ventasDetalle);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VentasDetalleExists(int id)
        {
            return _context.VentasDetalle.Any(e => e.DetalleId == id);
        }
    }
}
