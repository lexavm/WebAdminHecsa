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
    public class TblClienteDireccionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TblClienteDireccionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TblClienteDirecciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblClienteDirecciones.ToListAsync());
        }

        // GET: TblClienteDirecciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClienteDirecciones = await _context.TblClienteDirecciones
                .FirstOrDefaultAsync(m => m.IdClienteDirecciones == id);
            if (tblClienteDirecciones == null)
            {
                return NotFound();
            }

            return View(tblClienteDirecciones);
        }

        // GET: TblClienteDirecciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblClienteDirecciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClienteDirecciones,IdTipoDireccion,TipoDireccionDesc,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,Telefono,IdCliente,NombreCliente,FechaRegistro,IdEstatusRegistro")] TblClienteDirecciones tblClienteDirecciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblClienteDirecciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblClienteDirecciones);
        }

        // GET: TblClienteDirecciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClienteDirecciones = await _context.TblClienteDirecciones.FindAsync(id);
            if (tblClienteDirecciones == null)
            {
                return NotFound();
            }
            return View(tblClienteDirecciones);
        }

        // POST: TblClienteDirecciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClienteDirecciones,IdTipoDireccion,TipoDireccionDesc,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,Telefono,IdCliente,NombreCliente,FechaRegistro,IdEstatusRegistro")] TblClienteDirecciones tblClienteDirecciones)
        {
            if (id != tblClienteDirecciones.IdClienteDirecciones)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblClienteDirecciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblClienteDireccionesExists(tblClienteDirecciones.IdClienteDirecciones))
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
            return View(tblClienteDirecciones);
        }

        // GET: TblClienteDirecciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClienteDirecciones = await _context.TblClienteDirecciones
                .FirstOrDefaultAsync(m => m.IdClienteDirecciones == id);
            if (tblClienteDirecciones == null)
            {
                return NotFound();
            }

            return View(tblClienteDirecciones);
        }

        // POST: TblClienteDirecciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblClienteDirecciones = await _context.TblClienteDirecciones.FindAsync(id);
            _context.TblClienteDirecciones.Remove(tblClienteDirecciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblClienteDireccionesExists(int id)
        {
            return _context.TblClienteDirecciones.Any(e => e.IdClienteDirecciones == id);
        }
    }
}
