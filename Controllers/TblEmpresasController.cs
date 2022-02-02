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
    public class TblEmpresasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TblEmpresasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TblEmpresas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblEmpresa.ToListAsync());
        }

        // GET: TblEmpresas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmpresa = await _context.TblEmpresa
                .FirstOrDefaultAsync(m => m.IdEmpresa == id);
            if (tblEmpresa == null)
            {
                return NotFound();
            }

            return View(tblEmpresa);
        }

        // GET: TblEmpresas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblEmpresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpresa,NombreEmpresa,RFC,GiroComercial,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono,FechaRegistro,IdEstatusRegistro")] TblEmpresa tblEmpresa)
        {
            if (ModelState.IsValid)
            {
                tblEmpresa.IdEmpresa = Guid.NewGuid();
                _context.Add(tblEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblEmpresa);
        }

        // GET: TblEmpresas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmpresa = await _context.TblEmpresa.FindAsync(id);
            if (tblEmpresa == null)
            {
                return NotFound();
            }
            return View(tblEmpresa);
        }

        // POST: TblEmpresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdEmpresa,NombreEmpresa,RFC,GiroComercial,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono,FechaRegistro,IdEstatusRegistro")] TblEmpresa tblEmpresa)
        {
            if (id != tblEmpresa.IdEmpresa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblEmpresaExists(tblEmpresa.IdEmpresa))
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
            return View(tblEmpresa);
        }

        // GET: TblEmpresas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmpresa = await _context.TblEmpresa
                .FirstOrDefaultAsync(m => m.IdEmpresa == id);
            if (tblEmpresa == null)
            {
                return NotFound();
            }

            return View(tblEmpresa);
        }

        // POST: TblEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblEmpresa = await _context.TblEmpresa.FindAsync(id);
            _context.TblEmpresa.Remove(tblEmpresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblEmpresaExists(Guid id)
        {
            return _context.TblEmpresa.Any(e => e.IdEmpresa == id);
        }
    }
}
