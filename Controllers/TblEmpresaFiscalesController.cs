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
    public class TblEmpresaFiscalesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;

        public TblEmpresaFiscalesController(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: TblEmpresaFiscales
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
                    _notyf.Warning("Favor de registrar los datos de la Empresa para la Aplicación", 5);
                }
            }
            else
            {
                ViewBag.EstatusFlag = 0;
                _notyf.Warning("Favor de registrar los Estatus para la Aplicación", 5);
            }
            return View(await _context.TblEmpresaFiscales.ToListAsync());
        }

        // GET: TblEmpresaFiscales/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmpresaFiscales = await _context.TblEmpresaFiscales
                .FirstOrDefaultAsync(m => m.IdEmpresaFiscales == id);
            if (tblEmpresaFiscales == null)
            {
                return NotFound();
            }

            return View(tblEmpresaFiscales);
        }

        // GET: TblEmpresaFiscales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblEmpresaFiscales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpresaFiscales,NombreFiscal,RFC,RegimenFiscal,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,Telefono")] TblEmpresaFiscales tblEmpresaFiscales)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.TblEmpresaFiscales
                       .Where(s => s.NombreFiscal == tblEmpresaFiscales.NombreFiscal)
                       .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    if (tblEmpresaFiscales.Colonia == null)
                    {
                        var idEmpresa = _context.TblEmpresa.FirstOrDefault();
                        tblEmpresaFiscales.IdEmpresaFiscales = Guid.NewGuid();
                        tblEmpresaFiscales.IdEmpresa = idEmpresa.IdEmpresa;
                        tblEmpresaFiscales.NombreEmpresa = idEmpresa.NombreEmpresa;
                        tblEmpresaFiscales.FechaRegistro = DateTime.Now;
                        tblEmpresaFiscales.NombreFiscal = tblEmpresaFiscales.NombreFiscal.ToString().ToUpper();
                        tblEmpresaFiscales.IdEstatusRegistro = 1;
                    }
                    else
                    {
                        var strColonia = _context.CatCodigosPostales.Where(s => s.id_asenta_cpcons == tblEmpresaFiscales.Colonia).FirstOrDefault();
                        tblEmpresaFiscales.IdColonia = tblEmpresaFiscales.Colonia;
                        tblEmpresaFiscales.Colonia = strColonia.d_asenta;
                    }

                    _context.Add(tblEmpresaFiscales);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro guardado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Warning("Favor de validar, existe una Estatus con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblEmpresaFiscales);
        }
        // GET: TblEmpresaFiscales/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            var results = (from ta in _context.CatCodigosPostales
                           select ta.d_estado).Distinct().ToList();

            List<string> Estados = new List<string>();
            Estados = results;
            ViewBag.ListaEstados = Estados;
            if (id == null)
            {
                return NotFound();
            }

            var tblEmpresaFiscales = await _context.TblEmpresaFiscales.FindAsync(id);
            if (tblEmpresaFiscales == null)
            {
                return NotFound();
            }
            return View(tblEmpresaFiscales);
        }

        // POST: TblEmpresaFiscales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdEmpresaFiscales,NombreFiscal,RFC,RegimenFiscal,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,Telefono,IdEmpresa,NombreEmpresa,IdEstatusRegistro")] TblEmpresaFiscales tblEmpresaFiscales)
        {
            if (id != tblEmpresaFiscales.IdEmpresaFiscales)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblEmpresaFiscales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblEmpresaFiscalesExists(tblEmpresaFiscales.IdEmpresaFiscales))
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
            return View(tblEmpresaFiscales);
        }

        // GET: TblEmpresaFiscales/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmpresaFiscales = await _context.TblEmpresaFiscales
                .FirstOrDefaultAsync(m => m.IdEmpresaFiscales == id);
            if (tblEmpresaFiscales == null)
            {
                return NotFound();
            }

            return View(tblEmpresaFiscales);
        }

        // POST: TblEmpresaFiscales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblEmpresaFiscales = await _context.TblEmpresaFiscales.FindAsync(id);
            _context.TblEmpresaFiscales.Remove(tblEmpresaFiscales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblEmpresaFiscalesExists(Guid id)
        {
            return _context.TblEmpresaFiscales.Any(e => e.IdEmpresaFiscales == id);
        }
    }
}