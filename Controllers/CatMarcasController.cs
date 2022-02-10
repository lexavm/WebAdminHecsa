using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAdminHecsa.Data;
using WebAdminHecsa.Models;

namespace WebAdminHecsa.Controllers
{
    public class CatMarcasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;

        public CatMarcasController(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: CatMarcas
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
                    }
                    else
                    {
                        ViewBag.ProveedorFlag = 0;
                        _notyf.Information("Favor de registrar los datos de Proveedores para la Aplicación", 5);
                    }
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
            return View(await _context.CatMarca.ToListAsync());
        }

        // GET: CatMarcas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catMarca = await _context.CatMarca
                .FirstOrDefaultAsync(m => m.IdMarca == id);
            if (catMarca == null)
            {
                return NotFound();
            }

            return View(catMarca);
        }

        // GET: CatMarcas/Create
        public IActionResult Create()
        {
            List<TblProveedor> ListaProveedor = new List<TblProveedor>();
            ListaProveedor = (from c in _context.TblProveedor select c).Distinct().ToList();
            ViewBag.ListaProveedor = ListaProveedor;
            return View();
        }

        // POST: CatMarcas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMarca,MarcaDesc,IdProveedor,ProveedorDesc")] CatMarca catMarca)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.CatMarca
               .Where(s => s.MarcaDesc == catMarca.MarcaDesc)
               .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    var fProveedor = (from c in _context.TblProveedor where c.IdProveedor == catMarca.IdProveedor select c).Distinct().ToList();
                    catMarca.FechaRegistro = DateTime.Now;
                    catMarca.IdEstatusRegistro = 1;
                    catMarca.ProveedorDesc = fProveedor[0].NombreProveedor;
                    catMarca.MarcaDesc = !string.IsNullOrEmpty(catMarca.MarcaDesc) ? catMarca.MarcaDesc.ToUpper() : catMarca.MarcaDesc;

                    _context.SaveChanges();
                    _context.Add(catMarca);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Warning("Favor de validar, existe una Marca con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }

            return View(catMarca);
        }

        // GET: CatMarcas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<TblProveedor> ListaProveedor = new List<TblProveedor>();
            ListaProveedor = (from c in _context.TblProveedor select c).Distinct().ToList();
            ViewBag.ListaProveedor = ListaProveedor;

            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var catMarca = await _context.CatMarca.FindAsync(id);
            if (catMarca == null)
            {
                return NotFound();
            }
            return View(catMarca);
        }

        // POST: CatMarcas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMarca,MarcaDesc,IdProveedor,IdEstatusRegistro")] CatMarca catMarca)
        {
            if (id != catMarca.IdMarca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var fProveedor = (from c in _context.TblProveedor where c.IdProveedor == catMarca.IdProveedor select c).Distinct().ToList();
                    catMarca.FechaRegistro = DateTime.Now;
                    catMarca.IdEstatusRegistro = 1;
                    catMarca.ProveedorDesc = fProveedor[0].NombreProveedor;
                    catMarca.MarcaDesc = !string.IsNullOrEmpty(catMarca.MarcaDesc) ? catMarca.MarcaDesc.ToUpper() : catMarca.MarcaDesc;
                    _context.SaveChanges();
                    _context.Add(catMarca);
                    _context.Update(catMarca);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatMarcaExists(catMarca.IdMarca))
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
            return View(catMarca);
        }

        // GET: CatMarcas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catMarca = await _context.CatMarca
                .FirstOrDefaultAsync(m => m.IdMarca == id);
            if (catMarca == null)
            {
                return NotFound();
            }

            return View(catMarca);
        }

        // POST: CatMarcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catMarca = await _context.CatMarca.FindAsync(id);
            catMarca.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatMarcaExists(int id)
        {
            return _context.CatMarca.Any(e => e.IdMarca == id);
        }
    }
}