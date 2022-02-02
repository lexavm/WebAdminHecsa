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
    public class CatTiposEstatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatTiposEstatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CatTiposEstatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatTiposEstatus.ToListAsync());
        }

        // GET: CatTiposEstatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTiposEstatus = await _context.CatTiposEstatus
                .FirstOrDefaultAsync(m => m.IdTipoEstatus == id);
            if (catTiposEstatus == null)
            {
                return NotFound();
            }

            return View(catTiposEstatus);
        }

        // GET: CatTiposEstatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTiposEstatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoEstatus,TipoEstatusDesc,FechaRegistro,IdEstatusRegistro")] CatTiposEstatus catTiposEstatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catTiposEstatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catTiposEstatus);
        }

        // GET: CatTiposEstatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTiposEstatus = await _context.CatTiposEstatus.FindAsync(id);
            if (catTiposEstatus == null)
            {
                return NotFound();
            }
            return View(catTiposEstatus);
        }

        // POST: CatTiposEstatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoEstatus,TipoEstatusDesc,FechaRegistro,IdEstatusRegistro")] CatTiposEstatus catTiposEstatus)
        {
            if (id != catTiposEstatus.IdTipoEstatus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catTiposEstatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTiposEstatusExists(catTiposEstatus.IdTipoEstatus))
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
            return View(catTiposEstatus);
        }

        // GET: CatTiposEstatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTiposEstatus = await _context.CatTiposEstatus
                .FirstOrDefaultAsync(m => m.IdTipoEstatus == id);
            if (catTiposEstatus == null)
            {
                return NotFound();
            }

            return View(catTiposEstatus);
        }

        // POST: CatTiposEstatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTiposEstatus = await _context.CatTiposEstatus.FindAsync(id);
            _context.CatTiposEstatus.Remove(catTiposEstatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatTiposEstatusExists(int id)
        {
            return _context.CatTiposEstatus.Any(e => e.IdTipoEstatus == id);
        }
    }
}
