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
    public class CatGeneroesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatGeneroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CatGeneroes
        public async Task<IActionResult> Index()
        {
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
        public async Task<IActionResult> Create([Bind("IdGenero,GeneroDesc,FechaRegistro,IdEstatusRegistro")] CatGenero catGenero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catGenero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catGenero);
        }

        // GET: CatGeneroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
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
        public async Task<IActionResult> Edit(int id, [Bind("IdGenero,GeneroDesc,FechaRegistro,IdEstatusRegistro")] CatGenero catGenero)
        {
            if (id != catGenero.IdGenero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catGenero);
                    await _context.SaveChangesAsync();
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
            _context.CatGenero.Remove(catGenero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatGeneroExists(int id)
        {
            return _context.CatGenero.Any(e => e.IdGenero == id);
        }
    }
}
