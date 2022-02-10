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
    public class TblEmpresasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;

        public TblEmpresasController(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: TblEmpresas
        public async Task<IActionResult> Index()
        {
            var ValidaEstatus = _context.CatEstatus.ToList();

            if (ValidaEstatus.Count == 2)
            {
                ViewBag.EstatusFlag = 1;
            }
            else
            {
                ViewBag.EstatusFlag = 0;
                _notyf.Information("Favor de registrar los Estatus para la Aplicación", 5);
            }
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
        public async Task<IActionResult> Create([Bind("IdEmpresa,NombreEmpresa,GiroComercial,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono")] TblEmpresa tblEmpresa)
        {
            if (ModelState.IsValid)
            {
                var vEmpresa = _context.TblEmpresa.ToList();
                if (vEmpresa.Count == 0)
                {
                    var DuplicadosEstatus = _context.TblEmpresa
                                         .Where(s => s.NombreEmpresa == tblEmpresa.NombreEmpresa)
                                         .ToList();

                    if (DuplicadosEstatus.Count == 0)
                    {
                        tblEmpresa.FechaRegistro = DateTime.Now;
                        tblEmpresa.NombreEmpresa = tblEmpresa.NombreEmpresa.ToString().ToUpper();
                        tblEmpresa.GiroComercial = !string.IsNullOrEmpty(tblEmpresa.GiroComercial) ? tblEmpresa.GiroComercial.ToUpper() : tblEmpresa.GiroComercial;
                        tblEmpresa.IdEstatusRegistro = 1;
                        var strColonia = _context.CatCodigosPostales.Where(s => s.id_asenta_cpcons == tblEmpresa.Colonia).FirstOrDefault();
                        tblEmpresa.IdColonia = !string.IsNullOrEmpty(tblEmpresa.Colonia) ? tblEmpresa.Colonia : tblEmpresa.Colonia;
                        tblEmpresa.Colonia = !string.IsNullOrEmpty(tblEmpresa.Colonia) ? strColonia.d_asenta.ToUpper() : tblEmpresa.Colonia;
                        tblEmpresa.Calle = !string.IsNullOrEmpty(tblEmpresa.Calle) ? tblEmpresa.Calle.ToUpper() : tblEmpresa.Calle;
                        tblEmpresa.LocalidadMunicipio = !string.IsNullOrEmpty(tblEmpresa.LocalidadMunicipio) ? tblEmpresa.LocalidadMunicipio.ToUpper() : tblEmpresa.LocalidadMunicipio;
                        tblEmpresa.Ciudad = !string.IsNullOrEmpty(tblEmpresa.Ciudad) ? tblEmpresa.Ciudad.ToUpper() : tblEmpresa.Ciudad;
                        tblEmpresa.Estado = !string.IsNullOrEmpty(tblEmpresa.Estado) ? tblEmpresa.Estado.ToUpper() : tblEmpresa.Estado;
                        _context.SaveChanges();
                        _context.Add(tblEmpresa);
                        await _context.SaveChangesAsync();
                         _notyf.Success("Registro creado con éxito", 5);
                    }
                    else
                    {
                        _notyf.Warning("Favor de validar, existe una Estatus con el mismo nombre", 5);
                    }
                }
                else
                {
                    _notyf.Error("Solo se permite crear 1 Empresa", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblEmpresa);
        }

        // GET: TblEmpresas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

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
        public async Task<IActionResult> Edit(Guid id, [Bind("IdEmpresa,NombreEmpresa,RFC,GiroComercial,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono,IdEstatusRegistro")] TblEmpresa tblEmpresa)
        {
            if (id != tblEmpresa.IdEmpresa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tblEmpresa.FechaRegistro = DateTime.Now;
                    tblEmpresa.NombreEmpresa = tblEmpresa.NombreEmpresa.ToString().ToUpper();
                    tblEmpresa.GiroComercial = !string.IsNullOrEmpty(tblEmpresa.GiroComercial) ? tblEmpresa.GiroComercial.ToUpper() : tblEmpresa.GiroComercial;
                    tblEmpresa.IdEstatusRegistro = 1;
                    var strColonia = _context.CatCodigosPostales.Where(s => s.id_asenta_cpcons == tblEmpresa.Colonia).FirstOrDefault();
                    tblEmpresa.IdColonia = !string.IsNullOrEmpty(tblEmpresa.Colonia) ? tblEmpresa.Colonia : tblEmpresa.Colonia;
                    tblEmpresa.Colonia = !string.IsNullOrEmpty(tblEmpresa.Colonia) ? strColonia.d_asenta.ToUpper() : tblEmpresa.Colonia;
                    tblEmpresa.Calle = !string.IsNullOrEmpty(tblEmpresa.Calle) ? tblEmpresa.Calle.ToUpper() : tblEmpresa.Calle;
                    tblEmpresa.LocalidadMunicipio = !string.IsNullOrEmpty(tblEmpresa.LocalidadMunicipio) ? tblEmpresa.LocalidadMunicipio.ToUpper() : tblEmpresa.LocalidadMunicipio;
                    tblEmpresa.Ciudad = !string.IsNullOrEmpty(tblEmpresa.Ciudad) ? tblEmpresa.Ciudad.ToUpper() : tblEmpresa.Ciudad;
                    tblEmpresa.Estado = !string.IsNullOrEmpty(tblEmpresa.Estado) ? tblEmpresa.Estado.ToUpper() : tblEmpresa.Estado;
                    _context.SaveChanges();
                    _context.Update(tblEmpresa);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
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
            tblEmpresa.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblEmpresaExists(Guid id)
        {
            return _context.TblEmpresa.Any(e => e.IdEmpresa == id);
        }
    }
}