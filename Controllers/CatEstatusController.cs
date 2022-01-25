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
    public class CatEstatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatEstatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CatEstatus
        public async Task<IActionResult> Index()
        {
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
                .FirstOrDefaultAsync(m => m.IdEstatus == id);
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
        public async Task<IActionResult> Create([Bind("IdEstatus,EstatusDesc,FechaRegistro,IdEstatusRegistro")] CatEstatus catEstatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catEstatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catEstatus);
        }

        // GET: CatEstatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
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
        public async Task<IActionResult> Edit(int id, [Bind("IdEstatus,EstatusDesc,FechaRegistro,IdEstatusRegistro")] CatEstatus catEstatus)
        {
            if (id != catEstatus.IdEstatus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catEstatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatEstatusExists(catEstatus.IdEstatus))
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
                .FirstOrDefaultAsync(m => m.IdEstatus == id);
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
            _context.CatEstatus.Remove(catEstatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatEstatusExists(int id)
        {
            return _context.CatEstatus.Any(e => e.IdEstatus == id);
        }
    }
}
