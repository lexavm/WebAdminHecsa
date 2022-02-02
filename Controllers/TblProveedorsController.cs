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
    public class TblProveedorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TblProveedorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TblProveedors
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblProveedor.ToListAsync());
        }

        // GET: TblProveedors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedor = await _context.TblProveedor
                .FirstOrDefaultAsync(m => m.IdProveedor == id);
            if (tblProveedor == null)
            {
                return NotFound();
            }

            return View(tblProveedor);
        }

        // GET: TblProveedors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblProveedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProveedor,NombreProveedor,RFC,GiroComercial,CorreoElectronico,Telefono,IdEmpresa,NombreEmpresa,FechaRegistro,IdEstatusRegistro")] TblProveedor tblProveedor)
        {
            if (ModelState.IsValid)
            {
                tblProveedor.IdProveedor = Guid.NewGuid();
                _context.Add(tblProveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblProveedor);
        }

        // GET: TblProveedors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedor = await _context.TblProveedor.FindAsync(id);
            if (tblProveedor == null)
            {
                return NotFound();
            }
            return View(tblProveedor);
        }

        // POST: TblProveedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdProveedor,NombreProveedor,RFC,GiroComercial,CorreoElectronico,Telefono,IdEmpresa,NombreEmpresa,FechaRegistro,IdEstatusRegistro")] TblProveedor tblProveedor)
        {
            if (id != tblProveedor.IdProveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProveedorExists(tblProveedor.IdProveedor))
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
            return View(tblProveedor);
        }

        // GET: TblProveedors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedor = await _context.TblProveedor
                .FirstOrDefaultAsync(m => m.IdProveedor == id);
            if (tblProveedor == null)
            {
                return NotFound();
            }

            return View(tblProveedor);
        }

        // POST: TblProveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblProveedor = await _context.TblProveedor.FindAsync(id);
            _context.TblProveedor.Remove(tblProveedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProveedorExists(Guid id)
        {
            return _context.TblProveedor.Any(e => e.IdProveedor == id);
        }
    }
}
