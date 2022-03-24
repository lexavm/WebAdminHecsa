using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAdminHecsa.sqlModels;

namespace WebAdminHecsa.Data
{
    public partial class nDbContext : DbContext
    {
        public nDbContext()
        {
        }

        public nDbContext(DbContextOptions<nDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatArea> CatAreas { get; set; }
        public virtual DbSet<CatCategorium> CatCategoria { get; set; }
        public virtual DbSet<CatCodigosPostale> CatCodigosPostales { get; set; }
        public virtual DbSet<CatDivisa> CatDivisas { get; set; }
        public virtual DbSet<CatEstatus> CatEstatus { get; set; }
        public virtual DbSet<CatGenero> CatGeneros { get; set; }
        public virtual DbSet<CatMarca> CatMarcas { get; set; }
        public virtual DbSet<CatPerfile> CatPerfiles { get; set; }
        public virtual DbSet<CatProducto> CatProductos { get; set; }
        public virtual DbSet<CatRole> CatRoles { get; set; }
        public virtual DbSet<CatTipoDireccion> CatTipoDireccions { get; set; }
        public virtual DbSet<CatTipoEnvio> CatTipoEnvios { get; set; }
        public virtual DbSet<CatTiposEstatus> CatTiposEstatuses { get; set; }
        public virtual DbSet<TblCliente> TblClientes { get; set; }
        public virtual DbSet<TblClienteContacto> TblClienteContactos { get; set; }
        public virtual DbSet<TblClienteDireccione> TblClienteDirecciones { get; set; }
        public virtual DbSet<TblCotizacionGeneral> TblCotizacionGenerals { get; set; }
        public virtual DbSet<TblEmpresa> TblEmpresas { get; set; }
        public virtual DbSet<TblEmpresaFiscale> TblEmpresaFiscales { get; set; }
        public virtual DbSet<TblProveedor> TblProveedors { get; set; }
        public virtual DbSet<TblProveedorContacto> TblProveedorContactos { get; set; }
        public virtual DbSet<TblProveedorDireccione> TblProveedorDirecciones { get; set; }
        public virtual DbSet<TblUsuario> TblUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=95.111.249.203;Database=DevAdminHecsa; User ID=sa;Password=D3s4rr01l0; Integrated Security=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatArea>(entity =>
            {
                entity.HasKey(e => e.IdArea);

                entity.ToTable("CatArea");

                entity.Property(e => e.AreaDesc).IsRequired();

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.CatAreas)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CatArea_TblEmpresa");
            });

            modelBuilder.Entity<CatCategorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.Property(e => e.CategoriaDesc).IsRequired();

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.CatCategoria)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CatCategoria_FK");
            });

            modelBuilder.Entity<CatCodigosPostale>(entity =>
            {
                entity.HasKey(e => e.IdCodigosPostales);

                entity.Property(e => e.CCp)
                    .HasMaxLength(10)
                    .HasColumnName("c_CP");

                entity.Property(e => e.CCveCiudad)
                    .HasMaxLength(10)
                    .HasColumnName("c_cve_ciudad");

                entity.Property(e => e.CEstado)
                    .HasMaxLength(10)
                    .HasColumnName("c_estado");

                entity.Property(e => e.CMnpio)
                    .HasMaxLength(10)
                    .HasColumnName("c_mnpio");

                entity.Property(e => e.COficina)
                    .HasMaxLength(10)
                    .HasColumnName("c_oficina");

                entity.Property(e => e.CTipoAsenta)
                    .HasMaxLength(10)
                    .HasColumnName("c_tipo_asenta");

                entity.Property(e => e.DAsenta)
                    .HasMaxLength(300)
                    .HasColumnName("d_asenta");

                entity.Property(e => e.DCiudad)
                    .HasMaxLength(300)
                    .HasColumnName("d_ciudad");

                entity.Property(e => e.DCodigo)
                    .HasMaxLength(10)
                    .HasColumnName("d_codigo");

                entity.Property(e => e.DCp)
                    .HasMaxLength(10)
                    .HasColumnName("d_CP");

                entity.Property(e => e.DEstado)
                    .HasMaxLength(300)
                    .HasColumnName("d_estado");

                entity.Property(e => e.DMnpio)
                    .HasMaxLength(300)
                    .HasColumnName("D_mnpio");

                entity.Property(e => e.DTipoAsenta)
                    .HasMaxLength(300)
                    .HasColumnName("d_tipo_asenta");

                entity.Property(e => e.DZona)
                    .HasMaxLength(300)
                    .HasColumnName("d_zona");

                entity.Property(e => e.IdAsentaCpcons)
                    .HasMaxLength(10)
                    .HasColumnName("id_asenta_cpcons");
            });

            modelBuilder.Entity<CatDivisa>(entity =>
            {
                entity.HasKey(e => e.IdDivisa);

                entity.ToTable("CatDivisa");

                entity.Property(e => e.DivisaDesc).IsRequired();
            });

            modelBuilder.Entity<CatEstatus>(entity =>
            {
                entity.HasKey(e => e.IdEstatusRegistro);

                entity.ToTable("CatEstatus");

                entity.Property(e => e.EstatusDesc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatGenero>(entity =>
            {
                entity.HasKey(e => e.IdGenero);

                entity.ToTable("CatGenero");

                entity.Property(e => e.GeneroDesc).IsRequired();
            });

            modelBuilder.Entity<CatMarca>(entity =>
            {
                entity.HasKey(e => e.IdMarca);

                entity.ToTable("CatMarca");

                entity.Property(e => e.MarcaDesc).IsRequired();

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.CatMarcas)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CatMarca_TblProveedor");
            });

            modelBuilder.Entity<CatPerfile>(entity =>
            {
                entity.HasKey(e => e.IdPerfil);

                entity.ToTable("CatPerfile");

                entity.Property(e => e.PerfilDesc).IsRequired();
            });

            modelBuilder.Entity<CatProducto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.Property(e => e.CodigoExterno).IsRequired();

                entity.Property(e => e.Costo).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DescProducto).IsRequired();

                entity.Property(e => e.PorcentajePrecioUno).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ProductoPrecioUno).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.SubCosto).HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.CatProductos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CatProductos_CatCategoria");
            });

            modelBuilder.Entity<CatRole>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("CatRole");

                entity.Property(e => e.RolDesc).IsRequired();
            });

            modelBuilder.Entity<CatTipoDireccion>(entity =>
            {
                entity.HasKey(e => e.IdTipoDireccion);

                entity.ToTable("CatTipoDireccion");

                entity.Property(e => e.TipoDireccionDesc).IsRequired();
            });

            modelBuilder.Entity<CatTipoEnvio>(entity =>
            {
                entity.HasKey(e => e.IdTiposEnvio);

                entity.ToTable("CatTipoEnvio");

                entity.Property(e => e.TiposEnvioDesc).IsRequired();
            });

            modelBuilder.Entity<CatTiposEstatus>(entity =>
            {
                entity.HasKey(e => e.IdTipoEstatus);

                entity.ToTable("CatTiposEstatus");

                entity.Property(e => e.TipoEstatusDesc).IsRequired();
            });

            modelBuilder.Entity<TblCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("TblCliente");

                entity.Property(e => e.IdCliente).ValueGeneratedNever();

                entity.Property(e => e.NombreCliente).IsRequired();

                entity.Property(e => e.Rfc).HasColumnName("RFC");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.TblClientes)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblCliente_TblEmpresa");
            });

            modelBuilder.Entity<TblClienteContacto>(entity =>
            {
                entity.HasKey(e => e.IdClienteContacto);

                entity.ToTable("TblClienteContacto");

                entity.Property(e => e.CorreoElectronico).IsRequired();

                entity.Property(e => e.NombreClienteContacto).IsRequired();

                entity.Property(e => e.Telefono).IsRequired();

                entity.Property(e => e.TelefonoMovil).IsRequired();

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TblClienteContactos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblClienteContacto_TblCliente");
            });

            modelBuilder.Entity<TblClienteDireccione>(entity =>
            {
                entity.HasKey(e => e.IdClienteDirecciones);

                entity.Property(e => e.CorreoElectronico).IsRequired();

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TblClienteDirecciones)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblClienteDirecciones_TblCliente");

                entity.HasOne(d => d.IdTipoDireccionNavigation)
                    .WithMany(p => p.TblClienteDirecciones)
                    .HasForeignKey(d => d.IdTipoDireccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblClienteDirecciones_CatTipoDireccion");
            });

            modelBuilder.Entity<TblCotizacionGeneral>(entity =>
            {
                entity.HasKey(e => e.IdCotizacionGeneral);

                entity.ToTable("TblCotizacionGeneral");

                entity.Property(e => e.IdCotizacionGeneral).ValueGeneratedNever();

                entity.Property(e => e.Rfccliente).HasColumnName("RFCCliente");

                entity.HasOne(d => d.IdDivisaNavigation)
                    .WithMany(p => p.TblCotizacionGenerals)
                    .HasForeignKey(d => d.IdDivisa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblCotizacionGeneral_CatDivisa");

                entity.HasOne(d => d.IdEmpresaFiscalesNavigation)
                    .WithMany(p => p.TblCotizacionGenerals)
                    .HasForeignKey(d => d.IdEmpresaFiscales)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblCotizacionGeneral_TblEmpresaFiscales");

                entity.HasOne(d => d.IdTiposEnvioNavigation)
                    .WithMany(p => p.TblCotizacionGenerals)
                    .HasForeignKey(d => d.IdTiposEnvio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblCotizacionGeneral_CatTipoEnvio");
            });

            modelBuilder.Entity<TblEmpresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa);

                entity.ToTable("TblEmpresa");

                entity.Property(e => e.IdEmpresa).ValueGeneratedNever();

                entity.Property(e => e.CorreoElectronico).IsRequired();

                entity.Property(e => e.NombreEmpresa).IsRequired();

                entity.Property(e => e.Rfc).HasColumnName("RFC");

                entity.Property(e => e.Telefono).IsRequired();

                entity.HasOne(d => d.IdEstatusRegistroNavigation)
                    .WithMany(p => p.TblEmpresas)
                    .HasForeignKey(d => d.IdEstatusRegistro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblEmpresa_CatEstatus");
            });

            modelBuilder.Entity<TblEmpresaFiscale>(entity =>
            {
                entity.HasKey(e => e.IdEmpresaFiscales);

                entity.Property(e => e.IdEmpresaFiscales).ValueGeneratedNever();

                entity.Property(e => e.CorreoElectronico).IsRequired();

                entity.Property(e => e.NombreFiscal).IsRequired();

                entity.Property(e => e.Rfc)
                    .IsRequired()
                    .HasColumnName("RFC");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.TblEmpresaFiscales)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblEmpresaFiscales_TblEmpresa");
            });

            modelBuilder.Entity<TblProveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor);

                entity.ToTable("TblProveedor");

                entity.Property(e => e.IdProveedor).ValueGeneratedNever();

                entity.Property(e => e.NombreProveedor).IsRequired();

                entity.Property(e => e.Rfc).HasColumnName("RFC");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.TblProveedors)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblProveedor_TblEmpresa");
            });

            modelBuilder.Entity<TblProveedorContacto>(entity =>
            {
                entity.HasKey(e => e.IdProveedorContacto);

                entity.ToTable("TblProveedorContacto");

                entity.Property(e => e.CorreoElectronico).IsRequired();

                entity.Property(e => e.NombreProveedorContacto).IsRequired();

                entity.Property(e => e.Telefono).IsRequired();

                entity.Property(e => e.TelefonoMovil).IsRequired();

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.TblProveedorContactos)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblProveedorContacto_TblProveedor");
            });

            modelBuilder.Entity<TblProveedorDireccione>(entity =>
            {
                entity.HasKey(e => e.IdProveedorDirecciones);

                entity.Property(e => e.Calle).IsRequired();

                entity.Property(e => e.CodigoPostal).IsRequired();

                entity.Property(e => e.CorreoElectronico).IsRequired();

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.TblProveedorDirecciones)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblProveedorDirecciones_TblProveedor");
            });

            modelBuilder.Entity<TblUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("TblUsuario");

                entity.Property(e => e.IdUsuario).ValueGeneratedNever();

                entity.Property(e => e.ApellidoMaterno).IsRequired();

                entity.Property(e => e.ApellidoPaterno).IsRequired();

                entity.Property(e => e.CorreoAcceso).IsRequired();

                entity.Property(e => e.Nombres).IsRequired();

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.TblUsuarios)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblUsuario_CatArea");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.TblUsuarios)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblUsuario_CatGenero");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.TblUsuarios)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblUsuario_CatPerfile");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.TblUsuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblUsuario_CatRole");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
