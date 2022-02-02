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
    public class TblClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TblClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TblClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblCliente.ToListAsync());
        }

        // GET: TblClientes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCliente = await _context.TblCliente
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (tblCliente == null)
            {
                return NotFound();
            }

            return View(tblCliente);
        }

        // GET: TblClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,NombreCliente,RFC,GiroComercial,CorreoElectronico,IdEmpresa,NombreEmpresa,FechaRegistro,IdEstatusRegistro")] TblCliente tblCliente)
        {
            if (ModelState.IsValid)
            {
                tblCliente.IdCliente = Guid.NewGuid();
                _context.Add(tblCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCliente);
        }

        // GET: TblClientes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCliente = await _context.TblCliente.FindAsync(id);
            if (tblCliente == null)
            {
                return NotFound();
            }
            return View(tblCliente);
        }

        // POST: TblClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCliente,NombreCliente,RFC,GiroComercial,CorreoElectronico,IdEmpresa,NombreEmpresa,FechaRegistro,IdEstatusRegistro")] TblCliente tblCliente)
        {
            if (id != tblCliente.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblClienteExists(tblCliente.IdCliente))
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
            return View(tblCliente);
        }

        // GET: TblClientes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCliente = await _context.TblCliente
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (tblCliente == null)
            {
                return NotFound();
            }

            return View(tblCliente);
        }

        // POST: TblClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblCliente = await _context.TblCliente.FindAsync(id);
            _context.TblCliente.Remove(tblCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblClienteExists(Guid id)
        {
            return _context.TblCliente.Any(e => e.IdCliente == id);
        }
    }
}
