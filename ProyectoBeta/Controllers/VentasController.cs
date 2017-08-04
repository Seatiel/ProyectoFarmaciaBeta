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
    public class VentasController : Controller
    {
        private readonly Context _context;

        public VentasController(Context context)
        {
            _context = context;    
        }

        // GET: Ventas
        public IActionResult Index()
        {
            return View(VentasBLL.Listar());
        }

        [HttpGet]
        public JsonResult LastIndex()
        {
            int id = VentasBLL.Identity();
            if (id > 1 || VentasBLL.Listar().Count > 0)
                ++id;
            return Json(id);
        }

        [HttpGet]
        public JsonResult Buscar(int VentaId)
        {
            Ventas venta = VentasBLL.BuscarEncabezado(VentaId);
            return Json(venta);
        }

        [HttpPost]
        public JsonResult GuardarVentas(ClaseMaestra Venta)
        {
            bool resultado = false;
            if (ModelState.IsValid)
            {
                try
                {
                    DateTime now = DateTime.Now;
                    int y, m, d, h, min, s;                    
                    y = Venta.Encabezado.FechaVenta.Year;
                    m = Venta.Encabezado.FechaVenta.Month;
                    d = Venta.Encabezado.FechaVenta.Day;
                    h = now.Hour;
                    min = now.Minute;
                    s = now.Second;
                    Venta.Encabezado.FechaVenta = new DateTime(y, m, d, h, min, s);
                    resultado = VentasBLL.Guardar(Venta);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Json(resultado);
        }

        [HttpGet]
        public JsonResult ListaTiposVentas(int id)
        {
            var listado = TipoVentasBLL.GetLista();
            return Json(listado);
        }

        [HttpGet]
        public JsonResult ListaMedicinas(int id)
        {
            var listado = MedicinasBLL.GetLista();
            return Json(listado);
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas
                .SingleOrDefaultAsync(m => m.VentaId == id);
            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentaId,TipoVentaId,FechaVenta,Cantidad,SubTotal,ITBIS,Total")] Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventas);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ventas);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas.SingleOrDefaultAsync(m => m.VentaId == id);
            if (ventas == null)
            {
                return NotFound();
            }
            return View(ventas);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentaId,TipoVentaId,FechaVenta,Cantidad,SubTotal,ITBIS,Total")] Ventas ventas)
        {
            if (id != ventas.VentaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasExists(ventas.VentaId))
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
            return View(ventas);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas
                .SingleOrDefaultAsync(m => m.VentaId == id);
            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventas = await _context.Ventas.SingleOrDefaultAsync(m => m.VentaId == id);
            _context.Ventas.Remove(ventas);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VentasExists(int id)
        {
            return _context.Ventas.Any(e => e.VentaId == id);
        }
    }
}
