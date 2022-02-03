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
    public class CatCategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;

        public CatCategoriasController(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: CatCategorias
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
            return View(await _context.CatCategoria.ToListAsync());
        }

        // GET: CatCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catCategoria = await _context.CatCategoria
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (catCategoria == null)
            {
                return NotFound();
            }

            return View(catCategoria);
        }

        // GET: CatCategorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoria,CategoriaDesc,IdMarca,MarcaDesc,FechaRegistro,IdEstatusRegistro")] CatCategoria catCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catCategoria);
        }

        // GET: CatCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catCategoria = await _context.CatCategoria.FindAsync(id);
            if (catCategoria == null)
            {
                return NotFound();
            }
            return View(catCategoria);
        }

        // POST: CatCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoria,CategoriaDesc,IdMarca,MarcaDesc,FechaRegistro,IdEstatusRegistro")] CatCategoria catCategoria)
        {
            if (id != catCategoria.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatCategoriaExists(catCategoria.IdCategoria))
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
            return View(catCategoria);
        }

        // GET: CatCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catCategoria = await _context.CatCategoria
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (catCategoria == null)
            {
                return NotFound();
            }

            return View(catCategoria);
        }

        // POST: CatCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catCategoria = await _context.CatCategoria.FindAsync(id);
            _context.CatCategoria.Remove(catCategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatCategoriaExists(int id)
        {
            return _context.CatCategoria.Any(e => e.IdCategoria == id);
        }
    }
}
