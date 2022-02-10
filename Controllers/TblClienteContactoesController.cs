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
    public class TblClienteContactoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;
        public TblClienteContactoesController(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: TblClienteContactoes
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
                    var ValidaCliente = _context.TblCliente.ToList();

                    if (ValidaCliente.Count >= 1)
                    {
                        ViewBag.ClienteFlag = 1;
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
                        ViewBag.ClienteFlag = 0;
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
            List<TblCliente> ListaCliente = new List<TblCliente>();
            ListaCliente = (from c in _context.TblCliente select c).Distinct().ToList();
            ViewBag.ListaCliente = ListaCliente;

            List<CatPerfil> ListaPerfil = new List<CatPerfil>();
            ListaPerfil = (from c in _context.CatPerfile select c).Distinct().ToList();
            ViewBag.ListaPerfil = ListaPerfil;

            return View();
        }

        // POST: TblClienteContactoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClienteContacto,NombreClienteContacto,CorreoElectronico,Telefono,TelefonoMovil,IdCliente,IdPerfil")] TblClienteContacto tblClienteContacto)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.TblClienteContacto
                       .Where(s => s.NombreClienteContacto == tblClienteContacto.NombreClienteContacto)
                       .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    var fCliente = (from c in _context.TblCliente where c.IdCliente == tblClienteContacto.IdCliente select c).Distinct().ToList();
                    var fPerfil = (from c in _context.CatPerfile where c.IdPerfil == tblClienteContacto.IdPerfil select c).Distinct().ToList();
                    tblClienteContacto.NombreClienteContacto = tblClienteContacto.NombreClienteContacto.ToString().ToUpper();
                    tblClienteContacto.FechaRegistro = DateTime.Now;
                    tblClienteContacto.IdEstatusRegistro = 1;
                    tblClienteContacto.NombreCliente = fCliente[0].NombreCliente;
                    tblClienteContacto.PerfilDesc = fPerfil[0].PerfilDesc;

                    _context.SaveChanges();
                    _context.Add(tblClienteContacto);
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
            return View(tblClienteContacto);
        }

        // GET: TblClienteContactoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<TblCliente> ListaCliente = new List<TblCliente>();
            ListaCliente = (from c in _context.TblCliente select c).Distinct().ToList();
            ViewBag.ListaCliente = ListaCliente;

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
        public async Task<IActionResult> Edit(int id, [Bind("IdClienteContacto,NombreClienteContacto,CorreoElectronico,Telefono,TelefonoMovil,IdCliente,IdPerfil,IdEstatusRegistro")] TblClienteContacto tblClienteContacto)
        {
            if (id != tblClienteContacto.IdClienteContacto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fCliente = (from c in _context.TblCliente where c.IdCliente == tblClienteContacto.IdCliente select c).Distinct().ToList();
                    var fPerfil = (from c in _context.CatPerfile where c.IdPerfil == tblClienteContacto.IdPerfil select c).Distinct().ToList();
                    tblClienteContacto.NombreClienteContacto = tblClienteContacto.NombreClienteContacto.ToString().ToUpper();
                    tblClienteContacto.FechaRegistro = DateTime.Now;
                    tblClienteContacto.IdEstatusRegistro = 1;
                    tblClienteContacto.NombreCliente = fCliente[0].NombreCliente;
                    tblClienteContacto.PerfilDesc = fPerfil[0].PerfilDesc;
                    _context.Update(tblClienteContacto);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
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
            tblClienteContacto.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblClienteContactoExists(int id)
        {
            return _context.TblClienteContacto.Any(e => e.IdClienteContacto == id);
        }
    }
}
