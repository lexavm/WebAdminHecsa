using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAdminHecsa.Data;
using WebAdminHecsa.sqlModels;

namespace WebAdminHecsa.Controllers
{
    public class CatAreasController : Controller
    {
        private readonly nDbContext _context;

        public CatAreasController(nDbContext context)
        {
            _context = context;
        }

        // GET: CatAreas
        public async Task<IActionResult> Index()
        {
            var nDbContext = _context.CatAreas.Include(c => c.IdEmpresaNavigation);
            return View(await nDbContext.ToListAsync());
        }

        // GET: CatAreas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catArea = await _context.CatAreas
                .Include(c => c.IdEmpresaNavigation)
                .FirstOrDefaultAsync(m => m.IdArea == id);
            if (catArea == null)
            {
                return NotFound();
            }

            return View(catArea);
        }

        // GET: CatAreas/Create
        public IActionResult Create()
        {
            ViewData["IdEmpresa"] = new SelectList(_context.TblEmpresas, "IdEmpresa", "CorreoElectronico");
            return View();
        }

        // POST: CatAreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArea,AreaDesc,IdEmpresa,FechaRegistro,IdEstatusRegistro")] CatArea catArea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catArea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpresa"] = new SelectList(_context.TblEmpresas, "IdEmpresa", "CorreoElectronico", catArea.IdEmpresa);
            return View(catArea);
        }

        // GET: CatAreas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catArea = await _context.CatAreas.FindAsync(id);
            if (catArea == null)
            {
                return NotFound();
            }
            ViewData["IdEmpresa"] = new SelectList(_context.TblEmpresas, "IdEmpresa", "CorreoElectronico", catArea.IdEmpresa);
            return View(catArea);
        }

        // POST: CatAreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArea,AreaDesc,IdEmpresa,FechaRegistro,IdEstatusRegistro")] CatArea catArea)
        {
            if (id != catArea.IdArea)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catArea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatAreaExists(catArea.IdArea))
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
            ViewData["IdEmpresa"] = new SelectList(_context.TblEmpresas, "IdEmpresa", "CorreoElectronico", catArea.IdEmpresa);
            return View(catArea);
        }

        // GET: CatAreas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catArea = await _context.CatAreas
                .Include(c => c.IdEmpresaNavigation)
                .FirstOrDefaultAsync(m => m.IdArea == id);
            if (catArea == null)
            {
                return NotFound();
            }

            return View(catArea);
        }

        // POST: CatAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catArea = await _context.CatAreas.FindAsync(id);
            _context.CatAreas.Remove(catArea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatAreaExists(int id)
        {
            return _context.CatAreas.Any(e => e.IdArea == id);
        }
    }
}
