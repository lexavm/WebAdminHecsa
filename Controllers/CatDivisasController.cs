using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAdminHecsa.Data;
using WebAdminHecsa.Models;

namespace WebAdminHecsa.Controllers
{
    public class CatDivisasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;

        public CatDivisasController(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: CatDivisas
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
            return View(await _context.CatDivisa.ToListAsync());
        }

        // GET: CatDivisas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catDivisa = await _context.CatDivisa
                .FirstOrDefaultAsync(m => m.IdDivisa == id);
            if (catDivisa == null)
            {
                return NotFound();
            }

            return View(catDivisa);
        }

        // GET: CatDivisas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatDivisas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDivisa,DivisaDesc")] CatDivisa catDivisa)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.CatDivisa
                       .Where(s => s.DivisaDesc == catDivisa.DivisaDesc)
                       .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    catDivisa.FechaRegistro = DateTime.Now;
                    catDivisa.DivisaDesc = catDivisa.DivisaDesc.ToString().ToUpper();
                    catDivisa.IdEstatusRegistro = 1;
                    _context.SaveChanges();

                    _context.Add(catDivisa);
                    await _context.SaveChangesAsync();
                     _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Information("Favor de validar, existe una Estatus con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }

            return View(catDivisa);
        }

        // GET: CatDivisas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catDivisa = await _context.CatDivisa.FindAsync(id);
            if (catDivisa == null)
            {
                return NotFound();
            }
            return View(catDivisa);
        }

        // POST: CatDivisas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDivisa,DivisaDesc,IdEstatusRegistro")] CatDivisa catDivisa)
        {
            if (id != catDivisa.IdDivisa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    catDivisa.FechaRegistro = DateTime.Now;
                    catDivisa.DivisaDesc = catDivisa.DivisaDesc.ToString().ToUpper();
                    catDivisa.IdEstatusRegistro = catDivisa.IdEstatusRegistro;
                    _context.SaveChanges();
                    _context.Update(catDivisa);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatDivisaExists(catDivisa.IdDivisa))
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
            return View(catDivisa);
        }

        // GET: CatDivisas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catDivisa = await _context.CatDivisa
                .FirstOrDefaultAsync(m => m.IdDivisa == id);
            if (catDivisa == null)
            {
                return NotFound();
            }

            return View(catDivisa);
        }

        // POST: CatDivisas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catDivisa = await _context.CatDivisa.FindAsync(id);
            catDivisa.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatDivisaExists(int id)
        {
            return _context.CatDivisa.Any(e => e.IdDivisa == id);
        }
    }
}