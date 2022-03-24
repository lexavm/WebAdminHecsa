using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAdminHecsa.Data;
using WebAdminHecsa.sqlModels;

namespace WebAdminHecsa.Controllers
{
    public class CatEstatusController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;

        public CatEstatusController(nDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: CatEstatus
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
            return View(await _context.CatEstatus.ToListAsync());
        }

        // GET: CatEstatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catEstatus = await _context.CatEstatus
                .FirstOrDefaultAsync(m => m.IdEstatusRegistro == id);
            if (catEstatus == null)
            {
                return NotFound();
            }

            return View(catEstatus);
        }

        // GET: CatEstatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatEstatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstatusRegistro,EstatusDesc")] CatEstatus catEstatus)
        {
            if (ModelState.IsValid)
            {
                var vDuplicados = _context.CatEstatus
                       .Where(s => s.EstatusDesc == catEstatus.EstatusDesc)
                       .ToList();

                if (vDuplicados.Count == 0)
                {
                    catEstatus.FechaRegistro = DateTime.Now;
                    catEstatus.EstatusDesc = catEstatus.EstatusDesc.ToString().ToUpper();
                    catEstatus.IdEstatusRegistro = 1;
                    _context.SaveChanges();

                    _context.Add(catEstatus);
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

            return View(catEstatus);
        }

        // GET: CatEstatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catEstatus = await _context.CatEstatus.FindAsync(id);
            if (catEstatus == null)
            {
                return NotFound();
            }
            return View(catEstatus);
        }

        // POST: CatEstatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstatusRegistro,EstatusDesc")] CatEstatus catEstatus)
        {
            if (id != catEstatus.IdEstatusRegistro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    catEstatus.FechaRegistro = DateTime.Now;
                    catEstatus.EstatusDesc = catEstatus.EstatusDesc.ToString().ToUpper();
                    catEstatus.IdEstatusRegistro = catEstatus.IdEstatusRegistro;
                    _context.SaveChanges();
                    _context.Update(catEstatus);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatEstatusExists(catEstatus.IdEstatusRegistro))
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
            return View(catEstatus);
        }

        // GET: CatEstatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catEstatus = await _context.CatEstatus
                .FirstOrDefaultAsync(m => m.IdEstatusRegistro == id);
            if (catEstatus == null)
            {
                return NotFound();
            }

            return View(catEstatus);
        }

        // POST: CatEstatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catEstatus = await _context.CatEstatus.FindAsync(id);
            catEstatus.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatEstatusExists(int id)
        {
            return _context.CatEstatus.Any(e => e.IdEstatusRegistro == id);
        }
    }
}