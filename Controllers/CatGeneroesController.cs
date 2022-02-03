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
    public class CatGeneroesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;

        public CatGeneroesController(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: CatGeneroes
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
                _notyf.Warning("Favor de registrar los Estatus para la Aplicación", 5);
            }
            return View(await _context.CatGenero.ToListAsync());
        }

        // GET: CatGeneroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catGenero = await _context.CatGenero
                .FirstOrDefaultAsync(m => m.IdGenero == id);
            if (catGenero == null)
            {
                return NotFound();
            }

            return View(catGenero);
        }

        // GET: CatGeneroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatGeneroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGenero,GeneroDesc")] CatGenero catGenero)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.CatEstatus
                       .Where(s => s.EstatusDesc == catGenero.GeneroDesc && s.EstatusDesc == catGenero.GeneroDesc)
                       .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    catGenero.FechaRegistro = DateTime.Now;
                    catGenero.GeneroDesc = catGenero.GeneroDesc.ToString().ToUpper();
                    catGenero.IdEstatusRegistro = 1;
                    _context.SaveChanges();

                    _context.Add(catGenero);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro guardado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Warning("Favor de validar, existe una Estatus con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }

            return View(catGenero);
        }

        // GET: CatGeneroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catGenero = await _context.CatGenero.FindAsync(id);
            if (catGenero == null)
            {
                return NotFound();
            }
            return View(catGenero);
        }

        // POST: CatGeneroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGenero,GeneroDesc,IdEstatusRegistro")] CatGenero catGenero)
        {
            if (id != catGenero.IdGenero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    catGenero.FechaRegistro = DateTime.Now;
                    catGenero.GeneroDesc = catGenero.GeneroDesc.ToString().ToUpper();
                    catGenero.IdEstatusRegistro = catGenero.IdEstatusRegistro;
                    _context.SaveChanges();
                    _context.Update(catGenero);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatGeneroExists(catGenero.IdGenero))
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
            return View(catGenero);
        }

        // GET: CatGeneroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catGenero = await _context.CatGenero
                .FirstOrDefaultAsync(m => m.IdGenero == id);
            if (catGenero == null)
            {
                return NotFound();
            }

            return View(catGenero);
        }

        // POST: CatGeneroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catGenero = await _context.CatGenero.FindAsync(id);
            catGenero.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Success("Registro Desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatGeneroExists(int id)
        {
            return _context.CatGenero.Any(e => e.IdGenero == id);
        }
    }
}
