using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAdminHecsa.Migrations
{
    public partial class m01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatArea",
                columns: table => new
                {
                    IdArea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatArea", x => x.IdArea);
                });

            migrationBuilder.CreateTable(
                name: "CatCategoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMarca = table.Column<int>(type: "int", nullable: false),
                    MarcaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatCategoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "CatCodigosPostales",
                columns: table => new
                {
                    IdCodigosPostales = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    d_codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    d_asenta = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    d_tipo_asenta = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    D_mnpio = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    d_estado = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    d_ciudad = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    d_CP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    c_estado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    c_oficina = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    c_CP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    c_tipo_asenta = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    c_mnpio = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    id_asenta_cpcons = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    d_zona = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    c_cve_ciudad = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatCodigosPostales", x => x.IdCodigosPostales);
                });

            migrationBuilder.CreateTable(
                name: "CatDivisa",
                columns: table => new
                {
                    IdDivisa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisaDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatDivisa", x => x.IdDivisa);
                });

            migrationBuilder.CreateTable(
                name: "CatEstatus",
                columns: table => new
                {
                    IdEstatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstatusDesc = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatEstatus", x => x.IdEstatus);
                });

            migrationBuilder.CreateTable(
                name: "CatGenero",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneroDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatGenero", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "CatMarca",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProveedorDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatMarca", x => x.IdMarca);
                });

            migrationBuilder.CreateTable(
                name: "CatPerfile",
                columns: table => new
                {
                    IdPerfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfilDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatPerfile", x => x.IdPerfil);
                });

            migrationBuilder.CreateTable(
                name: "CatProductos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoInterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoExterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMarca = table.Column<int>(type: "int", nullable: false),
                    MarcaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    CategoriaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadMinima = table.Column<int>(type: "int", nullable: false),
                    CantidadInicial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductoPrecio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PorcentajeGanancia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PorcentajeVenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCosto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatProductos", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "CatRole",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatRole", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "CatTipoDireccion",
                columns: table => new
                {
                    IdTipoDireccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDireccionDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTipoDireccion", x => x.IdTipoDireccion);
                });

            migrationBuilder.CreateTable(
                name: "CatTipoEnvio",
                columns: table => new
                {
                    IdTiposEnvio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TiposEnvioDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTipoEnvio", x => x.IdTiposEnvio);
                });

            migrationBuilder.CreateTable(
                name: "CatTiposEstatus",
                columns: table => new
                {
                    IdTipoEstatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoEstatusDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTiposEstatus", x => x.IdTipoEstatus);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblCliente",
                columns: table => new
                {
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiroComercial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "TblClienteContacto",
                columns: table => new
                {
                    IdClienteContacto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerfil = table.Column<int>(type: "int", nullable: false),
                    PerfilDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreClienteContacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoMovil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblClienteContacto", x => x.IdClienteContacto);
                });

            migrationBuilder.CreateTable(
                name: "TblClienteDirecciones",
                columns: table => new
                {
                    IdClienteDirecciones = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoDireccion = table.Column<int>(type: "int", nullable: false),
                    TipoDireccionDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdColonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalidadMunicipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblClienteDirecciones", x => x.IdClienteDirecciones);
                });

            migrationBuilder.CreateTable(
                name: "TblCotizacionGeneral",
                columns: table => new
                {
                    IdCotizacionGeneral = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroCotizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEmpresaFiscales = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreFiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaGeneral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaContacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RFCCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediosCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionContacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteContacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCotizacionGeneral", x => x.IdCotizacionGeneral);
                });

            migrationBuilder.CreateTable(
                name: "TblEmpresa",
                columns: table => new
                {
                    IdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiroComercial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdColonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalidadMunicipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmpresa", x => x.IdEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "TblEmpresaFiscales",
                columns: table => new
                {
                    IdEmpresaFiscales = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreFiscal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegimenFiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdColonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalidadMunicipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmpresaFiscales", x => x.IdEmpresaFiscales);
                });

            migrationBuilder.CreateTable(
                name: "TblProveedor",
                columns: table => new
                {
                    IdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreProveedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiroComercial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProveedor", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "TblProveedorContacto",
                columns: table => new
                {
                    IdProveedorContacto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerfil = table.Column<int>(type: "int", nullable: false),
                    PerfilDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreProveedorContacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoMovil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreProveedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProveedorContacto", x => x.IdProveedorContacto);
                });

            migrationBuilder.CreateTable(
                name: "TblProveedorDirecciones",
                columns: table => new
                {
                    IdProveedorDirecciones = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoDireccion = table.Column<int>(type: "int", nullable: false),
                    TipoDireccionDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdColonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalidadMunicipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreProveedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProveedorDirecciones", x => x.IdProveedorDirecciones);
                });

            migrationBuilder.CreateTable(
                name: "TblUsuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdArea = table.Column<int>(type: "int", nullable: false),
                    IdGenero = table.Column<int>(type: "int", nullable: false),
                    IdPerfil = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CorreoAcceso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUsuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CatEstatus",
                columns: new[] { "IdEstatus", "EstatusDesc", "FechaRegistro", "IdEstatusRegistro" },
                values: new object[] { 1, "ACTIVO", new DateTime(2022, 2, 15, 23, 11, 33, 929, DateTimeKind.Local).AddTicks(3129), 1 });

            migrationBuilder.InsertData(
                table: "CatEstatus",
                columns: new[] { "IdEstatus", "EstatusDesc", "FechaRegistro", "IdEstatusRegistro" },
                values: new object[] { 2, "DESACTIVO", new DateTime(2022, 2, 15, 23, 11, 33, 929, DateTimeKind.Local).AddTicks(3156), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatArea");

            migrationBuilder.DropTable(
                name: "CatCategoria");

            migrationBuilder.DropTable(
                name: "CatCodigosPostales");

            migrationBuilder.DropTable(
                name: "CatDivisa");

            migrationBuilder.DropTable(
                name: "CatEstatus");

            migrationBuilder.DropTable(
                name: "CatGenero");

            migrationBuilder.DropTable(
                name: "CatMarca");

            migrationBuilder.DropTable(
                name: "CatPerfile");

            migrationBuilder.DropTable(
                name: "CatProductos");

            migrationBuilder.DropTable(
                name: "CatRole");

            migrationBuilder.DropTable(
                name: "CatTipoDireccion");

            migrationBuilder.DropTable(
                name: "CatTipoEnvio");

            migrationBuilder.DropTable(
                name: "CatTiposEstatus");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TblCliente");

            migrationBuilder.DropTable(
                name: "TblClienteContacto");

            migrationBuilder.DropTable(
                name: "TblClienteDirecciones");

            migrationBuilder.DropTable(
                name: "TblCotizacionGeneral");

            migrationBuilder.DropTable(
                name: "TblEmpresa");

            migrationBuilder.DropTable(
                name: "TblEmpresaFiscales");

            migrationBuilder.DropTable(
                name: "TblProveedor");

            migrationBuilder.DropTable(
                name: "TblProveedorContacto");

            migrationBuilder.DropTable(
                name: "TblProveedorDirecciones");

            migrationBuilder.DropTable(
                name: "TblUsuario");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
