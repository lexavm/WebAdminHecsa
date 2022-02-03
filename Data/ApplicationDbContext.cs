﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAdminHecsa.Models;

namespace WebAdminHecsa.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebAdminHecsa.Models.CatCategoria> CatCategoria { get; set; }
        public DbSet<WebAdminHecsa.Models.CatCodigosPostales> CatCodigosPostales { get; set; }
        public DbSet<WebAdminHecsa.Models.CatDivisa> CatDivisa { get; set; }
        public DbSet<WebAdminHecsa.Models.CatEstatus> CatEstatus { get; set; }
        public DbSet<WebAdminHecsa.Models.CatTipoEnvio> CatTipoEnvio { get; set; }
        public DbSet<WebAdminHecsa.Models.CatGenero> CatGenero { get; set; }
        public DbSet<WebAdminHecsa.Models.CatMarca> CatMarca { get; set; }
        public DbSet<WebAdminHecsa.Models.CatPerfil> CatPerfile { get; set; }
        public DbSet<WebAdminHecsa.Models.CatProducto> CatProductos { get; set; }
        public DbSet<WebAdminHecsa.Models.CatRole> CatRole { get; set; }
        public DbSet<WebAdminHecsa.Models.CatTipoDireccion> CatTipoDireccion { get; set; }
        public DbSet<WebAdminHecsa.Models.CatTiposEstatus> CatTiposEstatus { get; set; }
        public DbSet<WebAdminHecsa.Models.TblCliente> TblCliente { get; set; }
        public DbSet<WebAdminHecsa.Models.TblEmpresa> TblEmpresa { get; set; }
        public DbSet<WebAdminHecsa.Models.TblEmpresaFiscales> TblEmpresaFiscales { get; set; }
        public DbSet<WebAdminHecsa.Models.TblProveedor> TblProveedor { get; set; }
        public DbSet<WebAdminHecsa.Models.TblProveedorContacto> TblProveedorContacto { get; set; }
        public DbSet<WebAdminHecsa.Models.TblProveedorDirecciones> TblProveedorDirecciones { get; set; }
        public DbSet<WebAdminHecsa.Models.TblUsuario> TblUsuario { get; set; }
        public DbSet<WebAdminHecsa.Models.TblClienteContacto> TblClienteContacto { get; set; }
        public DbSet<WebAdminHecsa.Models.TblClienteDirecciones> TblClienteDirecciones { get; set; }
    }
}
