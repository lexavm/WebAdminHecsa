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
    public class TblCotizacionGeneralsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;

        public TblCotizacionGeneralsController(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: TblCotizacionGenerals
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
                    var ValidaEmpresaFiscales = _context.TblEmpresaFiscales.ToList();

                    if (ValidaEmpresaFiscales.Count >= 1)
                    {
                        ViewBag.EmpresaFiscalesFlag = 1;
                        var ValidaCliente = _context.TblCliente.ToList();

                        if (ValidaCliente.Count >= 1)
                        {
                            ViewBag.ClienteFlag = 1;
                            var ValidaGenero = _context.CatGenero.ToList();

                            if (ValidaGenero.Count >= 1)
                            {
                                ViewBag.GeneroFlag = 1;
                                var ValidaArea = _context.CatArea.ToList();

                                if (ValidaArea.Count >= 1)
                                {
                                    ViewBag.AreaFlag = 1;
                                    var ValidaPerfil = _context.CatPerfile.ToList();

                                    if (ValidaPerfil.Count >= 1)
                                    {
                                        ViewBag.PerfilFlag = 1;
                                        var ValidaRol = _context.CatRole.ToList();

                                        if (ValidaRol.Count >= 1)
                                        {
                                            ViewBag.RolFlag = 1;
                                        }
                                        else
                                        {
                                            ViewBag.RolFlag = 0;
                                            _notyf.Information("Favor de registrar los datos de Rol para la Aplicación", 5);
                                        }
                                    }
                                    else
                                    {
                                        ViewBag.PerfilFlag = 0;
                                        _notyf.Information("Favor de registrar los datos de Perfil para la Aplicación", 5);
                                    }
                                }
                                else
                                {
                                    ViewBag.AreaFlag = 0;
                                    _notyf.Information("Favor de registrar los datos de Area para la Aplicación", 5);
                                }
                            }
                            else
                            {
                                ViewBag.vGeneroFlag = 0;
                                _notyf.Information("Favor de registrar los datos de Genero para la Aplicación", 5);
                            }
                        }
                        else
                        {
                            ViewBag.ClienteFlag = 0;
                            _notyf.Information("Favor de registrar los datos de la Cliente para la Aplicación", 5);
                        }

                    }
                    else
                    {
                        ViewBag.EmpresaFiscalesFlag = 0;
                        _notyf.Information("Favor de registrar los datos Empresa Fiscales para la Aplicación", 5);
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
            return View(await _context.TblCotizacionGeneral.ToListAsync());
        }

        // GET: TblCotizacionGenerals/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCotizacionGeneral = await _context.TblCotizacionGeneral
                .FirstOrDefaultAsync(m => m.IdCotizacionGeneral == id);
            if (tblCotizacionGeneral == null)
            {
                return NotFound();
            }

            return View(tblCotizacionGeneral);
        }

        // GET: TblCotizacionGenerals/Create
        public IActionResult Create()
        {
            List<TblEmpresaFiscales> ListaEfiscales = new List<TblEmpresaFiscales>();
            ListaEfiscales = (from c in _context.TblEmpresaFiscales select c).Distinct().ToList();
            ViewBag.ListaEfiscales = ListaEfiscales;

            List<TblCliente> ListaCliente = new List<TblCliente>();
            ListaCliente = (from c in _context.TblCliente select c).Distinct().ToList();
            ViewBag.ListaCliente = ListaCliente;

            return View();
        }

        // POST: TblCotizacionGenerals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCotizacionGeneral,NumeroCotizacion,IdEmpresaFiscales,NombreFiscal,EmpresaGeneral,EmpresaContacto,IdCliente,NombreCliente,RFCCliente,MediosCliente,DireccionCliente,DireccionContacto,ClienteContacto")] TblCotizacionGeneral tblCotizacionGeneral)
        {
            if (ModelState.IsValid)
            {
                tblCotizacionGeneral.IdCotizacionGeneral = Guid.NewGuid();
                _context.Add(tblCotizacionGeneral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCotizacionGeneral);
        }

        // GET: TblCotizacionGenerals/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCotizacionGeneral = await _context.TblCotizacionGeneral.FindAsync(id);
            if (tblCotizacionGeneral == null)
            {
                return NotFound();
            }
            return View(tblCotizacionGeneral);
        }

        // POST: TblCotizacionGenerals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCotizacionGeneral,NumeroCotizacion,IdEmpresaFiscales,NombreFiscal,EmpresaGeneral,EmpresaContacto,IdCliente,NombreCliente,RFCCliente,MediosCliente,DireccionCliente,DireccionContacto,ClienteContacto")] TblCotizacionGeneral tblCotizacionGeneral)
        {
            if (id != tblCotizacionGeneral.IdCotizacionGeneral)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCotizacionGeneral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCotizacionGeneralExists(tblCotizacionGeneral.IdCotizacionGeneral))
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
            return View(tblCotizacionGeneral);
        }

        // GET: TblCotizacionGenerals/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCotizacionGeneral = await _context.TblCotizacionGeneral
                .FirstOrDefaultAsync(m => m.IdCotizacionGeneral == id);
            if (tblCotizacionGeneral == null)
            {
                return NotFound();
            }

            return View(tblCotizacionGeneral);
        }

        // POST: TblCotizacionGenerals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblCotizacionGeneral = await _context.TblCotizacionGeneral.FindAsync(id);
            _context.TblCotizacionGeneral.Remove(tblCotizacionGeneral);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCotizacionGeneralExists(Guid id)
        {
            return _context.TblCotizacionGeneral.Any(e => e.IdCotizacionGeneral == id);
        }
    }
}
