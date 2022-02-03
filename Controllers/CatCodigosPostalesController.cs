﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebAdminHecsa.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using WebAdminHecsa.Models;
using System.Data;
using System.Collections.Generic;

namespace WebAdminHecsa.Controllers
{
    public class CatCodigosPostalesController : Controller
    {
        private readonly ApplicationDbContext _context;
        [System.Obsolete]
        private IHostingEnvironment Environment;

        [System.Obsolete]
        public CatCodigosPostalesController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        public CatCodigosPostalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CatCodigosPostales
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        [System.Obsolete]
        public IActionResult Index(List<IFormFile> postedFiles)
        {
            List<CatCodigosPostales> cpModel = new List<CatCodigosPostales>();
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult FiltroCodigosPostales(string id)
        {
            var fcatCodigosPostales = _context.CatCodigosPostales
                       .Where(s => s.d_codigo == id)
                       .ToList();

            return Json(fcatCodigosPostales);
        }
        // GET: CatCodigosPostales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catCodigosPostales = await _context.CatCodigosPostales
                .FirstOrDefaultAsync(m => m.IdCodigosPostales == id);
            if (catCodigosPostales == null)
            {
                return NotFound();
            }

            return View(catCodigosPostales);
        }

        // GET: CatCodigosPostales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatCodigosPostales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCodigosPostales,d_codigo,d_asenta,d_tipo_asenta,D_mnpio,d_estado,d_ciudad,d_CP,c_estado,c_oficina,c_CP,c_tipo_asenta,c_mnpio,id_asenta_cpcons,d_zona,c_cve_ciudad")] CatCodigosPostales catCodigosPostales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catCodigosPostales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catCodigosPostales);
        }

        // GET: CatCodigosPostales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catCodigosPostales = await _context.CatCodigosPostales.FindAsync(id);
            if (catCodigosPostales == null)
            {
                return NotFound();
            }
            return View(catCodigosPostales);
        }

        // POST: CatCodigosPostales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCodigosPostales,d_codigo,d_asenta,d_tipo_asenta,D_mnpio,d_estado,d_ciudad,d_CP,c_estado,c_oficina,c_CP,c_tipo_asenta,c_mnpio,id_asenta_cpcons,d_zona,c_cve_ciudad")] CatCodigosPostales catCodigosPostales)
        {
            if (id != catCodigosPostales.IdCodigosPostales)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catCodigosPostales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatCodigosPostalesExists(catCodigosPostales.IdCodigosPostales))
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
            return View(catCodigosPostales);
        }

        // GET: CatCodigosPostales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catCodigosPostales = await _context.CatCodigosPostales
                .FirstOrDefaultAsync(m => m.IdCodigosPostales == id);
            if (catCodigosPostales == null)
            {
                return NotFound();
            }

            return View(catCodigosPostales);
        }

        // POST: CatCodigosPostales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catCodigosPostales = await _context.CatCodigosPostales.FindAsync(id);
            _context.CatCodigosPostales.Remove(catCodigosPostales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatCodigosPostalesExists(int id)
        {
            return _context.CatCodigosPostales.Any(e => e.IdCodigosPostales == id);
        }
    }
}