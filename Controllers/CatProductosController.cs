﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAdminHecsa.Data;
using WebAdminHecsa.Models;

namespace WebAdminHecsa.Controllers
{
    public class CatProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CatProductos
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatProductos.ToListAsync());
        }

        // GET: CatProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catProductos = await _context.CatProductos
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (catProductos == null)
            {
                return NotFound();
            }

            return View(catProductos);
        }

        // GET: CatProductos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto,CodigoInterno,CodigoExterno,IdMarca,MarcaDesc,IdCategoria,CategoriaDesc,DescProducto,CantidadMinima,CantidadInicial,ProductoPrecio,PorcentajeGanancia,PorcentajeVenta,SubCosto,Costo,FechaRegistro,IdEstatusRegistro")] CatProducto catProductos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catProductos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catProductos);
        }

        // GET: CatProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catProductos = await _context.CatProductos.FindAsync(id);
            if (catProductos == null)
            {
                return NotFound();
            }
            return View(catProductos);
        }

        // POST: CatProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,CodigoInterno,CodigoExterno,IdMarca,MarcaDesc,IdCategoria,CategoriaDesc,DescProducto,CantidadMinima,CantidadInicial,ProductoPrecio,PorcentajeGanancia,PorcentajeVenta,SubCosto,Costo,FechaRegistro,IdEstatusRegistro")] CatProducto catProductos)
        {
            if (id != catProductos.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catProductos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatProductosExists(catProductos.IdProducto))
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
            return View(catProductos);
        }

        // GET: CatProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catProductos = await _context.CatProductos
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (catProductos == null)
            {
                return NotFound();
            }

            return View(catProductos);
        }

        // POST: CatProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catProductos = await _context.CatProductos.FindAsync(id);
            _context.CatProductos.Remove(catProductos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatProductosExists(int id)
        {
            return _context.CatProductos.Any(e => e.IdProducto == id);
        }
    }
}