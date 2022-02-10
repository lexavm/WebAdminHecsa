using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAdminHecsa.Data;
using WebAdminHecsa.Models;

namespace WebAdminHecsa.Controllers
{
    public class CatTipoEnviosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;
        public CatTipoEnviosController(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: CatTipoEnvios
        public async Task<IActionResult> Index()
        {
            var ValidaEstatus = _context.CatEstatus.ToList();

            if (ValidaEstatus.Count == 2)
            {
                ViewBag.EstatusFlag = 1;
            }
            else
            {
                ViewBag.EstatusFlag = 0;
                _notyf.Information("Favor de registrar los Estatus para la Aplicación", 5);
            }
            return View(await _context.CatTipoEnvio.ToListAsync());
        }

        // GET: CatTipoEnvios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoEnvio = await _context.CatTipoEnvio
                .FirstOrDefaultAsync(m => m.IdTiposEnvio == id);
            if (catTipoEnvio == null)
            {
                return NotFound();
            }

            return View(catTipoEnvio);
        }

        // GET: CatTipoEnvios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoEnvios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTiposEnvio,TiposEnvioDesc")] CatTipoEnvio catTipoEnvio)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.CatTipoEnvio
                       .Where(s => s.TiposEnvioDesc == catTipoEnvio.TiposEnvioDesc)
                       .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    catTipoEnvio.FechaRegistro = DateTime.Now;
                    catTipoEnvio.TiposEnvioDesc = catTipoEnvio.TiposEnvioDesc.ToString().ToUpper();
                    catTipoEnvio.IdEstatusRegistro = 1;
                    _context.SaveChanges();

                    _context.Add(catTipoEnvio);
                    await _context.SaveChangesAsync();
                     _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Warning("Favor de validar, existe una Estatus con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catTipoEnvio);
        }

        // GET: CatTipoEnvios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var catTipoEnvio = await _context.CatTipoEnvio.FindAsync(id);
            if (catTipoEnvio == null)
            {
                return NotFound();
            }
            return View(catTipoEnvio);
        }

        // POST: CatTipoEnvios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTiposEnvio,TiposEnvioDesc,IdEstatusRegistro")] CatTipoEnvio catTipoEnvio)
        {
            if (id != catTipoEnvio.IdTiposEnvio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    catTipoEnvio.FechaRegistro = DateTime.Now;
                    catTipoEnvio.TiposEnvioDesc = catTipoEnvio.TiposEnvioDesc.ToString().ToUpper();
                    catTipoEnvio.IdEstatusRegistro = catTipoEnvio.IdEstatusRegistro;
                    _context.SaveChanges();
                    _context.Update(catTipoEnvio);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoEnvioExists(catTipoEnvio.IdTiposEnvio))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catTipoEnvio);
        }

        // GET: CatTipoEnvios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoEnvio = await _context.CatTipoEnvio
                .FirstOrDefaultAsync(m => m.IdTiposEnvio == id);
            if (catTipoEnvio == null)
            {
                return NotFound();
            }

            return View(catTipoEnvio);
        }

        // POST: CatTipoEnvios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTipoEnvio = await _context.CatTipoEnvio.FindAsync(id);
            catTipoEnvio.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoEnvioExists(int id)
        {
            return _context.CatTipoEnvio.Any(e => e.IdTiposEnvio == id);
        }
    }
}
