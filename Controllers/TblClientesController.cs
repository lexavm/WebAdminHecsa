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
    public class TblClientesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;
        public TblClientesController(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: TblClientes
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
            return View(await _context.TblCliente.ToListAsync());
        }
        [HttpGet]
        public ActionResult FiltroCliente(Guid id)
        {
            var fCliente = (from tC in _context.TblCliente
                            join tCd in _context.TblClienteDirecciones on tC.IdCliente equals tCd.IdCliente
                            where tC.IdCliente == id
                            select new
                            {
                                IdCliente = tC.IdCliente,
                                NombreCliente = tC.NombreCliente,
                                DireccionCliente = tCd.Calle + "," + tCd.CodigoPostal + "," + tCd.Colonia + "," + tCd.Ciudad + "," + tCd.Estado + "," + tCd.CorreoElectronico + "," + tCd.Telefono

                            }).Distinct().ToList();


            return Json(fCliente);
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
        public async Task<IActionResult> Create([Bind("IdCliente,NombreCliente,RFC,GiroComercial")] TblCliente tblCliente)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.TblCliente
                                          .Where(s => s.NombreCliente == tblCliente.NombreCliente)
                                          .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    var vEmpresa = _context.TblEmpresa.ToList();
                    tblCliente.FechaRegistro = DateTime.Now;
                    tblCliente.NombreCliente = tblCliente.NombreCliente.ToString().ToUpper();
                    tblCliente.GiroComercial = !string.IsNullOrEmpty(tblCliente.GiroComercial) ? tblCliente.GiroComercial.ToUpper() : tblCliente.GiroComercial;
                    tblCliente.RFC = !string.IsNullOrEmpty(tblCliente.RFC) ? tblCliente.RFC.ToUpper() : tblCliente.RFC;
                    tblCliente.IdEmpresa = vEmpresa[0].IdEmpresa;
                    tblCliente.NombreEmpresa = vEmpresa[0].NombreEmpresa;
                    tblCliente.IdEstatusRegistro = 1;

                    _context.SaveChanges();
                    _context.Add(tblCliente);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una Estatus con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblCliente);
        }

        // GET: TblClientes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

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
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCliente,NombreCliente,RFC,GiroComercial,IdEstatusRegistro")] TblCliente tblCliente)
        {
            if (id != tblCliente.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var vEmpresa = _context.TblEmpresa.ToList();
                    tblCliente.FechaRegistro = DateTime.Now;
                    tblCliente.NombreCliente = tblCliente.NombreCliente.ToString().ToUpper();
                    tblCliente.GiroComercial = !string.IsNullOrEmpty(tblCliente.GiroComercial) ? tblCliente.GiroComercial.ToUpper() : tblCliente.GiroComercial;
                    tblCliente.RFC = !string.IsNullOrEmpty(tblCliente.RFC) ? tblCliente.RFC.ToUpper() : tblCliente.RFC;
                    tblCliente.IdEmpresa = vEmpresa[0].IdEmpresa;
                    tblCliente.NombreEmpresa = vEmpresa[0].NombreEmpresa;

                    _context.Update(tblCliente);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
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
            tblCliente.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblClienteExists(Guid id)
        {
            return _context.TblCliente.Any(e => e.IdCliente == id);
        }
    }
}
