using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAdminHecsa.Data;
using WebAdminHecsa.Models;

namespace WebAdminHecsa.Controllers
{

    public class TblProveedorContactoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;

        public TblProveedorContactoesController(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: TblProveedorContactoes
        public async Task<IActionResult> Index()
        {
            var ValidaEstatus = _context.CatEstatus.ToList();

            if (ValidaEstatus.Count == 2)
            {
                ViewBag.EstatusFlag = 1;
                var ValidaEmpresa = _context.TblEmpresa.ToList();

                if (ValidaEmpresa.Count == 1)
                {
                    ViewBag.EmpresaFlag = 1;
                    var ValidaProveedor = _context.TblProveedor.ToList();

                    if (ValidaProveedor.Count >= 1)
                    {
                        ViewBag.ProveedorFlag = 1;
                        var ValidaPerfil = _context.CatPerfile.ToList();

                        if (ValidaPerfil.Count >= 1)
                        {
                            ViewBag.PerfilFlag = 1;
                        }
                        else
                        {
                            ViewBag.PerfilFlag = 0;
                            _notyf.Warning("Favor de registrar los datos de Perfil para la Aplicación", 5);
                        }
                    }
                    else
                    {
                        ViewBag.ProveedorFlag = 0;
                        _notyf.Warning("Favor de registrar los datos de la Proveedor para la Aplicación", 5);
                    }
                }
                else
                {
                    ViewBag.EmpresaFlag = 0;
                    _notyf.Warning("Favor de registrar los datos de la Empresa para la Aplicación", 5);
                }
            }
            else
            {
                ViewBag.EstatusFlag = 0;
                _notyf.Warning("Favor de registrar los Estatus para la Aplicación", 5);
            }
            return View(await _context.TblProveedorContacto.ToListAsync());
        }

        // GET: TblProveedorContactoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedorContacto = await _context.TblProveedorContacto
                .FirstOrDefaultAsync(m => m.IdProveedorContacto == id);
            if (tblProveedorContacto == null)
            {
                return NotFound();
            }

            return View(tblProveedorContacto);
        }

        // GET: TblProveedorContactoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblProveedorContactoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProveedorContacto,NombreProveedorContacto,CorreoElectronico,Telefono,IdProveedor,NombreProveedor")] TblProveedorContacto tblProveedorContacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblProveedorContacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblProveedorContacto);
        }

        // GET: TblProveedorContactoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedorContacto = await _context.TblProveedorContacto.FindAsync(id);
            if (tblProveedorContacto == null)
            {
                return NotFound();
            }
            return View(tblProveedorContacto);
        }

        // POST: TblProveedorContactoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProveedorContacto,NombreProveedorContacto,CorreoElectronico,Telefono,IdProveedor,NombreProveedor,IdEstatusRegistro")] TblProveedorContacto tblProveedorContacto)
        {
            if (id != tblProveedorContacto.IdProveedorContacto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProveedorContacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProveedorContactoExists(tblProveedorContacto.IdProveedorContacto))
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
            return View(tblProveedorContacto);
        }

        // GET: TblProveedorContactoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedorContacto = await _context.TblProveedorContacto
                .FirstOrDefaultAsync(m => m.IdProveedorContacto == id);
            if (tblProveedorContacto == null)
            {
                return NotFound();
            }

            return View(tblProveedorContacto);
        }

        // POST: TblProveedorContactoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProveedorContacto = await _context.TblProveedorContacto.FindAsync(id);
            _context.TblProveedorContacto.Remove(tblProveedorContacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProveedorContactoExists(int id)
        {
            return _context.TblProveedorContacto.Any(e => e.IdProveedorContacto == id);
        }
    }
}
