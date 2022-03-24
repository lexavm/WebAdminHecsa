using System;
using System.Collections.Generic;

namespace WebAdminHecsa.sqlModels
{
    public partial class TblProveedor
    {
        public TblProveedor()
        {
            CatMarcas = new HashSet<CatMarca>();
            TblProveedorContactos = new HashSet<TblProveedorContacto>();
            TblProveedorDirecciones = new HashSet<TblProveedorDireccione>();
        }

        public Guid IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string Rfc { get; set; }
        public string GiroComercial { get; set; }
        public Guid IdEmpresa { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }

        public virtual TblEmpresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<CatMarca> CatMarcas { get; set; }
        public virtual ICollection<TblProveedorContacto> TblProveedorContactos { get; set; }
        public virtual ICollection<TblProveedorDireccione> TblProveedorDirecciones { get; set; }
    }
}
