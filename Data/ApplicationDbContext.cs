using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAdminHecsa.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public DbSet<WebAdminHecsa.Models.CatCategoria> CatCategoria { get; set; }
        //public DbSet<WebAdminHecsa.Models.CatCodigosPostales> CatCodigosPostales { get; set; }
        //public DbSet<WebAdminHecsa.Models.CatDivisa> CatDivisa { get; set; }
        public DbSet<WebAdminHecsa.Models.CatEstatus> CatEstatus { get; set; }

        //public DbSet<WebAdminHecsa.Models.CatGenero> CatGenero { get; set; }
        //public DbSet<WebAdminHecsa.Models.CatMarca> CatMarca { get; set; }
        //public DbSet<WebAdminHecsa.Models.CatPerfile> CatPerfile { get; set; }
        //public DbSet<WebAdminHecsa.Models.CatProductos> CatProductos { get; set; }
        //public DbSet<WebAdminHecsa.Models.CatRole> CatRole { get; set; }
        //public DbSet<WebAdminHecsa.Models.CatTipoDireccion> CatTipoDireccion { get; set; }
        //public DbSet<WebAdminHecsa.Models.CatTiposEstatus> CatTiposEstatus { get; set; }
        //public DbSet<WebAdminHecsa.Models.TblCliente> TblCliente { get; set; }
        //public DbSet<WebAdminHecsa.Models.TblEmpresa> TblEmpresa { get; set; }
        //public DbSet<WebAdminHecsa.Models.TblEmpresaFiscales> TblEmpresaFiscales { get; set; }
        //public DbSet<WebAdminHecsa.Models.TblProveedor> TblProveedor { get; set; }
        //public DbSet<WebAdminHecsa.Models.TblProveedorContacto> TblProveedorContacto { get; set; }
        //public DbSet<WebAdminHecsa.Models.TblProveedorDirecciones> TblProveedorDirecciones { get; set; }
        //public DbSet<WebAdminHecsa.Models.TblUsuario> TblUsuario { get; set; }
    }
}
