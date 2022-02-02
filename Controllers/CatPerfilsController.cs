using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAdminHecsa.Data;
using WebAdminHecsa.Models;

namespace WebAdminHecsa.Controllers
{
    public class CatPerfilsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatPerfilsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CatPerfils
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatPerfile.ToListAsync());
        }

        // GET: CatPerfils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catPerfil = await _context.CatPerfile
                .FirstOrDefaultAsync(m => m.IdPerfil == id);
            if (catPerfil == null)
            {
                return NotFound();
            }

            return View(catPerfil);
        }

        // GET: CatPerfils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatPerfils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPerfil,PerfilDesc,FechaRegistro,IdEstatusRegistro")] CatPerfil catPerfil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catPerfil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catPerfil);
        }

        // GET: CatPerfils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catPerfil = await _context.CatPerfile.FindAsync(id);
            if (catPerfil == null)
            {
                return NotFound();
            }
            return View(catPerfil);
        }

        // POST: CatPerfils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPerfil,PerfilDesc,FechaRegistro,IdEstatusRegistro")] CatPerfil catPerfil)
        {
            if (id != catPerfil.IdPerfil)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catPerfil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatPerfilExists(catPerfil.IdPerfil))
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
            return View(catPerfil);
        }

        // GET: CatPerfils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catPerfil = await _context.CatPerfile
                .FirstOrDefaultAsync(m => m.IdPerfil == id);
            if (catPerfil == null)
            {
                return NotFound();
            }

            return View(catPerfil);
        }

        // POST: CatPerfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catPerfil = await _context.CatPerfile.FindAsync(id);
            _context.CatPerfile.Remove(catPerfil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatPerfilExists(int id)
        {
            return _context.CatPerfile.Any(e => e.IdPerfil == id);
        }
    }
}
