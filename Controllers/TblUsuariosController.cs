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
    public class TblUsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;

        public TblUsuariosController(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: TblUsuarios
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
                    ViewBag.EmpresaFlag = 0;
                    _notyf.Information("Favor de registrar los datos de la Empresa para la Aplicación", 5);
                }
            }
            else
            {
                ViewBag.EstatusFlag = 0;
                _notyf.Information("Favor de registrar los Estatus para la Aplicación", 5);
            }

            return View(await _context.TblUsuario.ToListAsync());
        }

        // GET: TblUsuarios/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUsuario = await _context.TblUsuario
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (tblUsuario == null)
            {
                return NotFound();
            }

            return View(tblUsuario);
        }

        // GET: TblUsuarios/Create
        public IActionResult Create()
        {

            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            List<CatArea> ListaArea = new List<CatArea>();
            ListaArea = (from c in _context.CatArea select c).Distinct().ToList();
            ViewBag.ListaArea = ListaArea;

            List<CatGenero> ListaGenero = new List<CatGenero>();
            ListaGenero = (from c in _context.CatGenero select c).Distinct().ToList();
            ViewBag.ListaGenero = ListaGenero;

            List<CatPerfil> ListaPerfil = new List<CatPerfil>();
            ListaPerfil = (from c in _context.CatPerfile select c).Distinct().ToList();
            ViewBag.ListaPerfil = ListaPerfil;

            List<CatRole> ListaRol = new List<CatRole>();
            ListaRol = (from c in _context.CatRole select c).Distinct().ToList();
            ViewBag.ListaRol = ListaRol;

            return View();
        }

        // POST: TblUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,IdGenero,IdArea,IdPerfil,IdRol,FechaNacimiento,Nombres,ApellidoPaterno,ApellidoMaterno,CorreoAcceso")] TblUsuario tblUsuario)
        {
            if (ModelState.IsValid)
            {
                var vDuplicados = _context.TblUsuario
                                .Where(s => s.Nombres == tblUsuario.Nombres && s.ApellidoPaterno == tblUsuario.ApellidoPaterno && s.ApellidoMaterno == tblUsuario.ApellidoMaterno)
                                .ToList();

                if (vDuplicados.Count == 0)
                {
                    var idEmpresa = _context.TblEmpresa.FirstOrDefault();
                    tblUsuario.FechaRegistro = DateTime.Now;
                    tblUsuario.IdEstatusRegistro = 1;
                    tblUsuario.IdEmpresa = idEmpresa.IdEmpresa;
                    tblUsuario.NombreEmpresa = idEmpresa.NombreEmpresa;
                    tblUsuario.Nombres = tblUsuario.Nombres.ToUpper();
                    tblUsuario.ApellidoPaterno = tblUsuario.ApellidoPaterno.ToUpper();
                    tblUsuario.ApellidoMaterno = tblUsuario.ApellidoMaterno.ToUpper();
                    tblUsuario.IdUsuario = Guid.NewGuid();
                    _context.Add(tblUsuario);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe Usuario con el mismo nombre.", 5);
                }
               
                return RedirectToAction(nameof(Index));
            }
            return View(tblUsuario);
        }

        // GET: TblUsuarios/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            List<CatArea> ListaArea = new List<CatArea>();
            ListaArea = (from c in _context.CatArea select c).Distinct().ToList();
            ViewBag.ListaArea = ListaArea;

            List<CatGenero> ListaGenero = new List<CatGenero>();
            ListaGenero = (from c in _context.CatGenero select c).Distinct().ToList();
            ViewBag.ListaGenero = ListaGenero;

            List<CatPerfil> ListaPerfil = new List<CatPerfil>();
            ListaPerfil = (from c in _context.CatPerfile select c).Distinct().ToList();
            ViewBag.ListaPerfil = ListaPerfil;

            List<CatRole> ListaRol = new List<CatRole>();
            ListaRol = (from c in _context.CatRole select c).Distinct().ToList();
            ViewBag.ListaRol = ListaRol;

    
            if (id == null)
            {
                return NotFound();
            }

            var tblUsuario = await _context.TblUsuario.FindAsync(id);
            if (tblUsuario == null)
            {
                return NotFound();
            }
            return View(tblUsuario);
        }

        // POST: TblUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdUsuario,IdGenero,IdArea,IdPerfil,IdRol,FechaNacimiento,Nombres,ApellidoPaterno,ApellidoMaterno,CorreoAcceso,IdEstatusRegistro")] TblUsuario tblUsuario)
        {
            if (id != tblUsuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var idEmpresa = _context.TblEmpresa.FirstOrDefault();
                    tblUsuario.FechaRegistro = DateTime.Now;
                    tblUsuario.IdEstatusRegistro = 1;
                    tblUsuario.IdEmpresa = idEmpresa.IdEmpresa;
                    tblUsuario.NombreEmpresa = idEmpresa.NombreEmpresa;
                    tblUsuario.Nombres = tblUsuario.Nombres.ToUpper();
                    tblUsuario.ApellidoPaterno = tblUsuario.ApellidoPaterno.ToUpper();
                    tblUsuario.ApellidoMaterno = tblUsuario.ApellidoMaterno.ToUpper();
                    _context.Update(tblUsuario);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUsuarioExists(tblUsuario.IdUsuario))
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
            return View(tblUsuario);
        }

        // GET: TblUsuarios/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUsuario = await _context.TblUsuario
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (tblUsuario == null)
            {
                return NotFound();
            }

            return View(tblUsuario);
        }

        // POST: TblUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblUsuario = await _context.TblUsuario.FindAsync(id);
            tblUsuario.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblUsuarioExists(Guid id)
        {
            return _context.TblUsuario.Any(e => e.IdUsuario == id);
        }
    }
}
