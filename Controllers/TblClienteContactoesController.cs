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
    public class TblClienteContactoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TblClienteContactoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TblClienteContactoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblClienteContacto.ToListAsync());
        }

        // GET: TblClienteContactoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClienteContacto = await _context.TblClienteContacto
                .FirstOrDefaultAsync(m => m.IdClienteContacto == id);
            if (tblClienteContacto == null)
            {
                return NotFound();
            }

            return View(tblClienteContacto);
        }

        // GET: TblClienteContactoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblClienteContactoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClienteContacto,NombreClienteContacto,CorreoElectronico,Telefono,IdCliente,NombreCliente,FechaRegistro,IdEstatusRegistro")] TblClienteContacto tblClienteContacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblClienteContacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblClienteContacto);
        }

        // GET: TblClienteContactoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClienteContacto = await _context.TblClienteContacto.FindAsync(id);
            if (tblClienteContacto == null)
            {
                return NotFound();
            }
            return View(tblClienteContacto);
        }

        // POST: TblClienteContactoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClienteContacto,NombreClienteContacto,CorreoElectronico,Telefono,IdCliente,NombreCliente,FechaRegistro,IdEstatusRegistro")] TblClienteContacto tblClienteContacto)
        {
            if (id != tblClienteContacto.IdClienteContacto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblClienteContacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblClienteContactoExists(tblClienteContacto.IdClienteContacto))
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
            return View(tblClienteContacto);
        }

        // GET: TblClienteContactoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClienteContacto = await _context.TblClienteContacto
                .FirstOrDefaultAsync(m => m.IdClienteContacto == id);
            if (tblClienteContacto == null)
            {
                return NotFound();
            }

            return View(tblClienteContacto);
        }

        // POST: TblClienteContactoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblClienteContacto = await _context.TblClienteContacto.FindAsync(id);
            _context.TblClienteContacto.Remove(tblClienteContacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblClienteContactoExists(int id)
        {
            return _context.TblClienteContacto.Any(e => e.IdClienteContacto == id);
        }
    }
}
