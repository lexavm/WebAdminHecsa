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
    public class TblProveedorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;

        public TblProveedorsController(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: TblProveedors
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
                }
                else
                {
                    ViewBag.EmpresaFlag = 0;
                    _notyf.Information("Favor de registrar los datos de la Empresa para la Aplicación", 5);
                }
            }
            else
            {
                ViewBag.EstatusFlag = 0;
                _notyf.Information("Favor de registrar los Estatus para la Aplicación", 5);
            }
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
        public async Task<IActionResult> Create([Bind("IdProveedor,NombreProveedor,RFC,GiroComercial,CorreoElectronico,Telefono")] TblProveedor tblProveedor)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.TblProveedor
                                .Where(s => s.NombreProveedor == tblProveedor.NombreProveedor)
                                .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    var idEmpresa = _context.TblEmpresa.FirstOrDefault();
                    tblProveedor.FechaRegistro = DateTime.Now;
                    tblProveedor.NombreProveedor = tblProveedor.NombreProveedor.ToString().ToUpper();
                    tblProveedor.GiroComercial = !string.IsNullOrEmpty(tblProveedor.GiroComercial) ? tblProveedor.GiroComercial.ToUpper() : tblProveedor.GiroComercial;
                    tblProveedor.RFC = !string.IsNullOrEmpty(tblProveedor.RFC) ? tblProveedor.RFC.ToUpper() : tblProveedor.RFC;
                    tblProveedor.IdEstatusRegistro = 1;
                    tblProveedor.IdEmpresa = idEmpresa.IdEmpresa;
                    tblProveedor.NombreEmpresa = idEmpresa.NombreEmpresa;
                    _context.SaveChanges();
                    _context.Add(tblProveedor);
                    await _context.SaveChangesAsync();
                     _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe Proveedor con el mismo nombre y el mismo RFC", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblProveedor);
        }

        // GET: TblProveedors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;
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
        public async Task<IActionResult> Edit(Guid id, [Bind("IdProveedor,NombreProveedor,RFC,GiroComercial,CorreoElectronico,Telefono,IdEstatusRegistro")] TblProveedor tblProveedor)
        {
            if (id != tblProveedor.IdProveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var idEmpresa = _context.TblEmpresa.FirstOrDefault();
                    tblProveedor.FechaRegistro = DateTime.Now;
                    tblProveedor.NombreProveedor = tblProveedor.NombreProveedor.ToString().ToUpper();
                    tblProveedor.GiroComercial = !string.IsNullOrEmpty(tblProveedor.GiroComercial) ? tblProveedor.GiroComercial.ToUpper() : tblProveedor.GiroComercial;
                    tblProveedor.RFC = !string.IsNullOrEmpty(tblProveedor.RFC) ? tblProveedor.RFC.ToUpper() : tblProveedor.RFC;
                    tblProveedor.IdEstatusRegistro = 1;
                    tblProveedor.IdEmpresa = idEmpresa.IdEmpresa;
                    tblProveedor.NombreEmpresa = idEmpresa.NombreEmpresa;
                    _context.Update(tblProveedor);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
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
            tblProveedor.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblProveedorExists(Guid id)
        {
            return _context.TblProveedor.Any(e => e.IdProveedor == id);
        }
    }
}
