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
    public class CatMarcasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;

        public CatMarcasController(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: CatMarcas
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
            return View(await _context.CatMarca.ToListAsync());
        }

        // GET: CatMarcas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catMarca = await _context.CatMarca
                .FirstOrDefaultAsync(m => m.IdMarca == id);
            if (catMarca == null)
            {
                return NotFound();
            }

            return View(catMarca);
        }

        // GET: CatMarcas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatMarcas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMarca,MarcaDesc,IdProveedor,ProveedorDesc,FechaRegistro,IdEstatusRegistro")] CatMarca catMarca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catMarca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catMarca);
        }

        // GET: CatMarcas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catMarca = await _context.CatMarca.FindAsync(id);
            if (catMarca == null)
            {
                return NotFound();
            }
            return View(catMarca);
        }

        // POST: CatMarcas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMarca,MarcaDesc,IdProveedor,ProveedorDesc,FechaRegistro,IdEstatusRegistro")] CatMarca catMarca)
        {
            if (id != catMarca.IdMarca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catMarca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatMarcaExists(catMarca.IdMarca))
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
            return View(catMarca);
        }

        // GET: CatMarcas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catMarca = await _context.CatMarca
                .FirstOrDefaultAsync(m => m.IdMarca == id);
            if (catMarca == null)
            {
                return NotFound();
            }

            return View(catMarca);
        }

        // POST: CatMarcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catMarca = await _context.CatMarca.FindAsync(id);
            _context.CatMarca.Remove(catMarca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatMarcaExists(int id)
        {
            return _context.CatMarca.Any(e => e.IdMarca == id);
        }
    }
}
