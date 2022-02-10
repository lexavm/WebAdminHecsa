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
                            _notyf.Information("Favor de registrar los datos de Perfil para la Aplicación", 5);
                        }
                    }
                    else
                    {
                        ViewBag.ProveedorFlag = 0;
                        _notyf.Information("Favor de registrar los datos de la Proveedor para la Aplicación", 5);
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
            List<TblProveedor> ListaProveedor = new List<TblProveedor>();
            ListaProveedor = (from c in _context.TblProveedor select c).Distinct().ToList();
            ViewBag.ListaProveedor = ListaProveedor;

            List<CatPerfil> ListaPerfil = new List<CatPerfil>();
            ListaPerfil = (from c in _context.CatPerfile select c).Distinct().ToList();
            ViewBag.ListaPerfil = ListaPerfil;

            return View();
        }

        // POST: TblProveedorContactoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProveedorContacto,IdPerfil,NombreProveedorContacto,CorreoElectronico,Telefono,TelefonoMovil,IdProveedor")] TblProveedorContacto tblProveedorContacto)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.TblProveedorContacto
                      .Where(s => s.NombreProveedorContacto == tblProveedorContacto.NombreProveedorContacto)
                      .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    var fProveedor = (from c in _context.TblProveedor where c.IdProveedor == tblProveedorContacto.IdProveedor select c).Distinct().ToList();
                    var fPerfil = (from c in _context.CatPerfile where c.IdPerfil == tblProveedorContacto.IdPerfil select c).Distinct().ToList();
                    tblProveedorContacto.NombreProveedorContacto = tblProveedorContacto.NombreProveedorContacto.ToString().ToUpper();
                    tblProveedorContacto.FechaRegistro = DateTime.Now;
                    tblProveedorContacto.IdEstatusRegistro = 1;
                    tblProveedorContacto.NombreProveedor = fProveedor[0].NombreProveedor;
                    tblProveedorContacto.PerfilDesc = fPerfil[0].PerfilDesc;

                    _context.SaveChanges();
                    _context.Add(tblProveedorContacto);
                    await _context.SaveChangesAsync();
                     _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Warning("Favor de validar, existe un Contacto con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblProveedorContacto);
        }

        // GET: TblProveedorContactoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<TblProveedor> ListaProveedor = new List<TblProveedor>();
            ListaProveedor = (from c in _context.TblProveedor select c).Distinct().ToList();
            ViewBag.ListaProveedor = ListaProveedor;

            List<CatPerfil> ListaPerfil = new List<CatPerfil>();
            ListaPerfil = (from c in _context.CatPerfile select c).Distinct().ToList();
            ViewBag.ListaPerfil = ListaPerfil;

            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

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
        public async Task<IActionResult> Edit(int id, [Bind("IdProveedorContacto,IdPerfil,NombreProveedorContacto,CorreoElectronico,Telefono,TelefonoMovil,IdProveedor,IdEstatusRegistro")] TblProveedorContacto tblProveedorContacto)
        {
            if (id != tblProveedorContacto.IdProveedorContacto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fProveedor = (from c in _context.TblProveedor where c.IdProveedor == tblProveedorContacto.IdProveedor select c).Distinct().ToList();
                    var fPerfil = (from c in _context.CatPerfile where c.IdPerfil == tblProveedorContacto.IdPerfil select c).Distinct().ToList();
                    tblProveedorContacto.NombreProveedorContacto = tblProveedorContacto.NombreProveedorContacto.ToString().ToUpper();
                    tblProveedorContacto.FechaRegistro = DateTime.Now;
                    tblProveedorContacto.IdEstatusRegistro = 1;
                    tblProveedorContacto.NombreProveedor = fProveedor[0].NombreProveedor;
                    tblProveedorContacto.PerfilDesc = fPerfil[0].PerfilDesc;
                    _context.SaveChanges();
                    _context.Update(tblProveedorContacto);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
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
            tblProveedorContacto.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblProveedorContactoExists(int id)
        {
            return _context.TblProveedorContacto.Any(e => e.IdProveedorContacto == id);
        }
    }
}