using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAdminHecsa.Data;
using WebAdminHecsa.sqlModels;

namespace WebAdminHecsa.Controllers
{
    public class CatRolesController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;

        public CatRolesController(nDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: CatRoles
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
            return View(await _context.CatRoles.ToListAsync());
        }

        // GET: CatRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catRole = await _context.CatRoles
                .FirstOrDefaultAsync(m => m.IdRol == id);
            if (catRole == null)
            {
                return NotFound();
            }

            return View(catRole);
        }

        // GET: CatRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRol,RolDesc")] CatRole catRole)
        {
            if (ModelState.IsValid)
            {
                var vDuplicados = _context.CatRoles
                        .Where(s => s.RolDesc == catRole.RolDesc)
                        .ToList();

                if (vDuplicados.Count == 0)
                {
                    catRole.FechaRegistro = DateTime.Now;
                    catRole.RolDesc = catRole.RolDesc.ToString().ToUpper();
                    catRole.IdEstatusRegistro = 1;
                    _context.SaveChanges();

                    _context.Add(catRole);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Warning("Favor de validar, existe una Estatus con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catRole);
        }

        // GET: CatRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var catRole = await _context.CatRoles.FindAsync(id);
            if (catRole == null)
            {
                return NotFound();
            }
            return View(catRole);
        }

        // POST: CatRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRol,RolDesc,IdEstatusRegistro")] CatRole catRole)
        {
            if (id != catRole.IdRol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    catRole.FechaRegistro = DateTime.Now;
                    catRole.RolDesc = catRole.RolDesc.ToString().ToUpper();
                    catRole.IdEstatusRegistro = catRole.IdEstatusRegistro;
                    _context.SaveChanges();
                    _context.Update(catRole);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatRoleExists(catRole.IdRol))
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
            return View(catRole);
        }

        // GET: CatRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catRole = await _context.CatRoles
                .FirstOrDefaultAsync(m => m.IdRol == id);
            if (catRole == null)
            {
                return NotFound();
            }

            return View(catRole);
        }

        // POST: CatRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catRole = await _context.CatRoles.FindAsync(id);
            catRole.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatRoleExists(int id)
        {
            return _context.CatRoles.Any(e => e.IdRol == id);
        }
    }
}