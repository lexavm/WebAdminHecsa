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
    public class TblProveedorDireccionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TblProveedorDireccionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TblProveedorDirecciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblProveedorDirecciones.ToListAsync());
        }

        // GET: TblProveedorDirecciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedorDirecciones = await _context.TblProveedorDirecciones
                .FirstOrDefaultAsync(m => m.IdProveedorDirecciones == id);
            if (tblProveedorDirecciones == null)
            {
                return NotFound();
            }

            return View(tblProveedorDirecciones);
        }

        // GET: TblProveedorDirecciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblProveedorDirecciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProveedorDirecciones,IdTipoDireccion,TipoDireccionDesc,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,Telefono,IdProveedor,NombreProveedor,FechaRegistro,IdEstatusRegistro")] TblProveedorDirecciones tblProveedorDirecciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblProveedorDirecciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblProveedorDirecciones);
        }

        // GET: TblProveedorDirecciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedorDirecciones = await _context.TblProveedorDirecciones.FindAsync(id);
            if (tblProveedorDirecciones == null)
            {
                return NotFound();
            }
            return View(tblProveedorDirecciones);
        }

        // POST: TblProveedorDirecciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProveedorDirecciones,IdTipoDireccion,TipoDireccionDesc,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,Telefono,IdProveedor,NombreProveedor,FechaRegistro,IdEstatusRegistro")] TblProveedorDirecciones tblProveedorDirecciones)
        {
            if (id != tblProveedorDirecciones.IdProveedorDirecciones)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProveedorDirecciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProveedorDireccionesExists(tblProveedorDirecciones.IdProveedorDirecciones))
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
            return View(tblProveedorDirecciones);
        }

        // GET: TblProveedorDirecciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedorDirecciones = await _context.TblProveedorDirecciones
                .FirstOrDefaultAsync(m => m.IdProveedorDirecciones == id);
            if (tblProveedorDirecciones == null)
            {
                return NotFound();
            }

            return View(tblProveedorDirecciones);
        }

        // POST: TblProveedorDirecciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProveedorDirecciones = await _context.TblProveedorDirecciones.FindAsync(id);
            _context.TblProveedorDirecciones.Remove(tblProveedorDirecciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProveedorDireccionesExists(int id)
        {
            return _context.TblProveedorDirecciones.Any(e => e.IdProveedorDirecciones == id);
        }
    }
}
