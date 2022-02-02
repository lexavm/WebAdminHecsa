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
    public class TblEmpresaFiscalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TblEmpresaFiscalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TblEmpresaFiscales
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblEmpresaFiscales.ToListAsync());
        }

        // GET: TblEmpresaFiscales/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmpresaFiscales = await _context.TblEmpresaFiscales
                .FirstOrDefaultAsync(m => m.IdEmpresaFiscales == id);
            if (tblEmpresaFiscales == null)
            {
                return NotFound();
            }

            return View(tblEmpresaFiscales);
        }

        // GET: TblEmpresaFiscales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblEmpresaFiscales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpresaFiscales,NombreFiscal,RFC,RegimenFiscal,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,Telefono,IdEmpresa,NombreEmpresa,FechaRegistro,IdEstatusRegistro")] TblEmpresaFiscales tblEmpresaFiscales)
        {
            if (ModelState.IsValid)
            {
                tblEmpresaFiscales.IdEmpresaFiscales = Guid.NewGuid();
                _context.Add(tblEmpresaFiscales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblEmpresaFiscales);
        }

        // GET: TblEmpresaFiscales/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmpresaFiscales = await _context.TblEmpresaFiscales.FindAsync(id);
            if (tblEmpresaFiscales == null)
            {
                return NotFound();
            }
            return View(tblEmpresaFiscales);
        }

        // POST: TblEmpresaFiscales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdEmpresaFiscales,NombreFiscal,RFC,RegimenFiscal,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,Telefono,IdEmpresa,NombreEmpresa,FechaRegistro,IdEstatusRegistro")] TblEmpresaFiscales tblEmpresaFiscales)
        {
            if (id != tblEmpresaFiscales.IdEmpresaFiscales)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblEmpresaFiscales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblEmpresaFiscalesExists(tblEmpresaFiscales.IdEmpresaFiscales))
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
            return View(tblEmpresaFiscales);
        }

        // GET: TblEmpresaFiscales/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmpresaFiscales = await _context.TblEmpresaFiscales
                .FirstOrDefaultAsync(m => m.IdEmpresaFiscales == id);
            if (tblEmpresaFiscales == null)
            {
                return NotFound();
            }

            return View(tblEmpresaFiscales);
        }

        // POST: TblEmpresaFiscales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblEmpresaFiscales = await _context.TblEmpresaFiscales.FindAsync(id);
            _context.TblEmpresaFiscales.Remove(tblEmpresaFiscales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblEmpresaFiscalesExists(Guid id)
        {
            return _context.TblEmpresaFiscales.Any(e => e.IdEmpresaFiscales == id);
        }
    }
}
