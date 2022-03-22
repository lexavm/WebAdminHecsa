using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAdminHecsa.Data.Configuracion;
using WebAdminHecsa.Models;

namespace WebAdminHecsa.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CatCategoria> CatCategoria { get; set; }
        public DbSet<CatCodigosPostales> CatCodigosPostales { get; set; }
        public DbSet<CatDivisa> CatDivisa { get; set; }
        public DbSet<CatEstatus> CatEstatus { get; set; }
        public DbSet<CatTipoEnvio> CatTipoEnvio { get; set; }
        public DbSet<CatGenero> CatGenero { get; set; }
        public DbSet<CatMarca> CatMarca { get; set; }
        public DbSet<CatPerfil> CatPerfile { get; set; }
        public DbSet<CatProductos> CatProductos { get; set; }
        public DbSet<CatRole> CatRole { get; set; }
        public DbSet<CatTipoDireccion> CatTipoDireccion { get; set; }
        public DbSet<CatTiposEstatus> CatTiposEstatus { get; set; }
        public DbSet<TblCliente> TblCliente { get; set; }
        public DbSet<TblEmpresa> TblEmpresa { get; set; }
        public DbSet<TblEmpresaFiscales> TblEmpresaFiscales { get; set; }
        public DbSet<TblProveedor> TblProveedor { get; set; }
        public DbSet<TblProveedorContacto> TblProveedorContacto { get; set; }
        public DbSet<TblProveedorDirecciones> TblProveedorDirecciones { get; set; }
        public DbSet<TblUsuario> TblUsuario { get; set; }
        public DbSet<TblClienteContacto> TblClienteContacto { get; set; }
        public DbSet<TblClienteDirecciones> TblClienteDirecciones { get; set; }
        public DbSet<CatArea> CatArea { get; set; }

        public DbSet<TblCotizacionGeneral> TblCotizacionGeneral { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Ignore<IdentityUserLogin<string>>();
            //modelBuilder.Ignore<IdentityUserRole<string>>();
            //modelBuilder.Ignore<IdentityUserClaim<string>>();
            //modelBuilder.Ignore<IdentityUserToken<string>>();
            //modelBuilder.Ignore<IdentityUser<string>>();
            modelBuilder.ApplyConfiguration(new EstatusConfiguracion());

        }
    }
}
