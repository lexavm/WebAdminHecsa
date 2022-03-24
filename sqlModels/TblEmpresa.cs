using System;
using System.Collections.Generic;

namespace WebAdminHecsa.sqlModels
{
    public partial class TblEmpresa
    {
        public TblEmpresa()
        {
            CatAreas = new HashSet<CatArea>();
            TblClientes = new HashSet<TblCliente>();
            TblEmpresaFiscales = new HashSet<TblEmpresaFiscale>();
            TblProveedors = new HashSet<TblProveedor>();
        }

        public Guid IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string Rfc { get; set; }
        public string GiroComercial { get; set; }
        public string Calle { get; set; }
        public string CodigoPostal { get; set; }
        public string IdColonia { get; set; }
        public string Colonia { get; set; }
        public string LocalidadMunicipio { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }

        public virtual CatEstatus IdEstatusRegistroNavigation { get; set; }
        public virtual ICollection<CatArea> CatAreas { get; set; }
        public virtual ICollection<TblCliente> TblClientes { get; set; }
        public virtual ICollection<TblEmpresaFiscale> TblEmpresaFiscales { get; set; }
        public virtual ICollection<TblProveedor> TblProveedors { get; set; }
    }
}
